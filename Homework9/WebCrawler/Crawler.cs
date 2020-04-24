using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebCrawler {
  public enum CrawlMode {
    Bfs,
    Dfs
  }

  public class Crawler {
    public delegate void InfoOutput(string info);

    private readonly HttpClient client = new HttpClient();

    private readonly CancellationToken ctx;

    // private readonly Limiter limiter = new Limiter(1000);
    private readonly Uri startUri;
    private readonly ConcurrentBag<Uri> visited = new ConcurrentBag<Uri>();

    public Crawler(string start, bool standalone = true, CancellationToken context = default) : this(new Uri(start),
      standalone, context) { }

    public Crawler(Uri start, bool standalone = true, CancellationToken context = default) {
      if (standalone) {
        OnInfoEmitted += Console.WriteLine;
      }

      startUri = start;
      ctx = context;
    }

    public event InfoOutput OnInfoEmitted;

    private static void Main(string[] args) {
      var startUrl = @"https://www.cnblogs.com/dstang2000/";
      if (args.Length > 0 && (args[0].StartsWith("http://") || args[0].StartsWith("https://"))) {
        startUrl = args[0];
      }

      Console.WriteLine($"Start crawling at {startUrl}.");
      var crawler = new Crawler(startUrl);
      crawler.Start();
      Console.WriteLine($"Finished crawling at {startUrl}.");
      Console.ReadLine();
    }

    public void Start(int depth = -1, CrawlMode mode = CrawlMode.Bfs, int thread = 1) {
      switch (mode) {
        case CrawlMode.Bfs:
          if (thread == 1) {
            BfsCrawl(new List<Uri> {startUri}, depth);
          }
          else {
            var semaphore = new SemaphoreSlim(thread, thread);
            BfsCrawlParallel(new List<Uri> {startUri}, depth, thread, semaphore);
          }
          break;
        case CrawlMode.Dfs:
          if (thread == 1) {
            DfsCrawl(startUri, depth);
          }
          else {
            var semaphore = new SemaphoreSlim(thread, thread);
            DfsCrawlParallel(startUri, depth, thread, semaphore);
          }
          break;
        // never
        default:
          throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
      }
    }

    private void DfsCrawl(Uri url, int depth) {
      if (ctx.IsCancellationRequested) {
        return;
      }

      if (visited.Contains(url)) {
        OnInfoEmitted?.Invoke($"Url {url} visited. Skip.");
        return;
      }

      HtmlDocument doc;
      try {
        visited.Add(url);
        doc = Download(url.ToString());
        OnInfoEmitted?.Invoke($"Url {url} Crawled.");
      }
      catch (Exception e) {
        OnInfoEmitted?.Invoke($"Failed on crawling {url}: {e.GetType().Name}: {e.Message}");
        return;
      }

      if (depth == 0) {
        return;
      }

      // Select <a>, <area>, <link> element with "href" attribute
      var nodes1 = doc.DocumentNode.SelectNodes("//a[@href] | //area[@href] | //link[@href]");
      // Extract value of href attribute (links)
      var links = nodes1?.Select(node => node.Attributes["href"]?.Value)
        // remove those with empty value
        .Where(link => !string.IsNullOrWhiteSpace(link))
        // Parse to absolute URI
        .Select(link => new Uri(url, link))
        // Filter out cross origin links and visited links
        .Where(uri => uri.Authority == startUri.Authority && !visited.Contains(uri))
        // Remove duplicate
        .Distinct();
      if (links == null || ctx.IsCancellationRequested) {
        return;
      }

      foreach (var link in links) DfsCrawl(link, depth == -1 ? depth : depth - 1);
    }

    private void BfsCrawl(IEnumerable<Uri> urls, int depth) {
      if (ctx.IsCancellationRequested) {
        return;
      }

      var nextUrls = urls.Select(url => {
          if (ctx.IsCancellationRequested) {
            return Enumerable.Empty<Uri>();
          }

          if (visited.Contains(url)) {
            OnInfoEmitted?.Invoke($"Url {url} visited. Skip.");
            return Enumerable.Empty<Uri>();
          }

          HtmlDocument doc;
          try {
            visited.Add(url);
            doc = Download(url.ToString());
            OnInfoEmitted?.Invoke($"Url {url} Crawled.");
          }
          catch (Exception e) {
            OnInfoEmitted?.Invoke($"Failed on crawling {url}: {e.GetType().Name}: {e.Message}");
            return Enumerable.Empty<Uri>();
          }

          var nodes1 = doc.DocumentNode.SelectNodes("//a[@href] | //area[@href] | //link[@href]");
          return nodes1?.Select(node => node.Attributes["href"]?.Value)
                   .Where(link => !string.IsNullOrWhiteSpace(link))
                   .Select(link => new Uri(url, link))
                   .Where(uri => uri.Authority == startUri.Authority && !visited.Contains(uri)) ??
                 Enumerable.Empty<Uri>();
        })
        // Flatten Enumerables
        .SelectMany(x => x)
        // Remove duplicate
        .Distinct()
        // Do crawling
        .ToList();
      if (depth == 0 || nextUrls.Count == 0) {
        return;
      }

      if (depth != -1) {
        depth--;
      }

      BfsCrawl(nextUrls, depth);
    }

    // A Bad Wheel :(

    // public void ParallelCrawl(Uri url, int depth, int thread) {
    //   var semaphore = new SemaphoreSlim(thread, thread);
    //   var tasks = new BlockingCollection<Uri>();
    //   var resultQueue = new BlockingCollection<IEnumerable<Uri>>();
    //   tasks.Add(url, ctx);
    //   var canceller = new CancellationTokenSource();
    //
    //   void ResultCollector() {
    //     while (!ctx.IsCancellationRequested) {
    //       try {
    //         var result = resultQueue.Take(canceller.Token);
    //         semaphore.Release();
    //         
    //         foreach (var uri in result.Where(uri => !visited.Contains(uri))) {
    //           tasks.Add(uri, ctx);
    //         }
    //       }
    //       catch (OperationCanceledException) {
    //         return;
    //       }
    //     }
    //   }
    //
    //   var resultCollectorThread = new Thread(ResultCollector);
    //   resultCollectorThread.Start();
    //
    //   while (!ctx.IsCancellationRequested && !(tasks.Count == 0 && semaphore.CurrentCount == thread)) {
    //     try {
    //       semaphore.Wait(ctx);
    //       var next = tasks.Take(ctx);
    //       void ParallelDownloader() {
    //         var urlInner = next.ToString();
    //         HtmlDocument doc;
    //         try {
    //           visited.Add(next);
    //           doc = Download(urlInner);
    //           OnInfoEmitted?.Invoke($"Url {urlInner} Crawled.");
    //         }
    //         catch (Exception e) {
    //           OnInfoEmitted?.Invoke($"Failed on crawling {url}: {e.GetType().Name}: {e.Message}");
    //           resultQueue.Add(Enumerable.Empty<Uri>(), canceller.Token);
    //           return;
    //         }
    //         var nodes1 = doc.DocumentNode.SelectNodes("//a[@href] | //area[@href] | //link[@href]");
    //         try {
    //           resultQueue.Add(nodes1?.Select(node => node.Attributes["href"]?.Value)
    //               .Where(link => !string.IsNullOrWhiteSpace(link))
    //               .Select(link => new Uri(url, link))
    //               .Where(uri => uri.Authority == startUri.Authority) ?? Enumerable.Empty<Uri>(),
    //             canceller.Token);
    //         }
    //         catch (OperationCanceledException) { }
    //       }
    //
    //       var crawlerThread = new Thread(ParallelDownloader);
    //       crawlerThread.Start();
    //     }
    //     catch (OperationCanceledException) {
    //       canceller.Cancel();
    //       break;
    //     }
    //   }
    //
    //   resultCollectorThread.Join();
    // }

    private void DfsCrawlParallel(Uri url, int depth, int thread, SemaphoreSlim semaphore) {
      if (ctx.IsCancellationRequested) {
        return;
      }

      if (visited.Contains(url)) {
        OnInfoEmitted?.Invoke($"Url {url} visited. Skip.");
        return;
      }

      HtmlDocument doc;
      try {
        visited.Add(url);
        semaphore.Wait(ctx);
        doc = Download(url.ToString());
        semaphore.Release();
        OnInfoEmitted?.Invoke($"Url {url} Crawled.");
      }
      catch (AggregateException e) {
        var innerE = e.InnerException;
        OnInfoEmitted?.Invoke($"Failed on crawling {url}: {innerE?.GetType().Name ?? "null"}: {innerE?.Message ?? "null"}");
        return;
      }
      catch (OperationCanceledException) {
        return;
      }
      catch (Exception e) {
        OnInfoEmitted?.Invoke($"Failed on crawling {url}: {e.GetType().Name}: {e.Message}");
        return;
      }

      if (depth == 0) {
        return;
      }

      // Select <a>, <area>, <link> element with "href" attribute
      var nodes1 = doc.DocumentNode.SelectNodes("//a[@href] | //area[@href] | //link[@href]");
      // Extract value of href attribute (links)
      var links = nodes1?.Select(node => node.Attributes["href"]?.Value)
        // remove those with empty value
        .Where(link => !string.IsNullOrWhiteSpace(link))
        // Parse to absolute URI
        .Select(link => new Uri(url, link))
        // Filter out cross origin links and visited links
        .Where(uri => uri.Authority == startUri.Authority && !visited.Contains(uri))
        // Remove duplicate
        .Distinct();
      if (links == null || ctx.IsCancellationRequested) {
        return;
      }

      Parallel.ForEach(links,
        new ParallelOptions {MaxDegreeOfParallelism = thread},
        link => DfsCrawl(link, depth == -1 ? depth : depth - 1)
      );
    }

    private void BfsCrawlParallel(IEnumerable<Uri> urls, int depth, int thread, SemaphoreSlim semaphore) {
      if (ctx.IsCancellationRequested) {
        return;
      }

      var nextUrls = urls.AsParallel().WithDegreeOfParallelism(thread).Select(url => {
          if (ctx.IsCancellationRequested) {
            return Enumerable.Empty<Uri>();
          }

          if (visited.Contains(url)) {
            OnInfoEmitted?.Invoke($"Url {url} visited. Skip.");
            return Enumerable.Empty<Uri>();
          }

          HtmlDocument doc;
          try {
            visited.Add(url);
            semaphore.Wait(ctx);
            doc = Download(url.ToString());
            semaphore.Release();
            OnInfoEmitted?.Invoke($"Url {url} Crawled.");
          }
          catch (OperationCanceledException) {
            return Enumerable.Empty<Uri>();
          }
          catch (AggregateException e) {
            var innerE = e.InnerException;
            OnInfoEmitted?.Invoke($"Failed on crawling {url}: {innerE?.GetType().Name ?? "null"}: {innerE?.Message ?? "null"}");
            return Enumerable.Empty<Uri>();
          }
          catch (Exception e) {
            OnInfoEmitted?.Invoke($"Failed on crawling {url}: {e.GetType().Name}: {e.Message}");
            return Enumerable.Empty<Uri>();
          }

          var nodes1 = doc.DocumentNode.SelectNodes("//a[@href] | //area[@href] | //link[@href]");
          return nodes1?.Select(node => node.Attributes["href"]?.Value)
                   .Where(link => !string.IsNullOrWhiteSpace(link))
                   .Select(link => new Uri(url, link))
                   .Where(uri => uri.Authority == startUri.Authority && !visited.Contains(uri)) ??
                 Enumerable.Empty<Uri>();
        })
        // Flatten Enumerables
        .SelectMany(x => x)
        // Remove duplicate
        .Distinct()
        // Do crawling
        .ToList();
      if (depth == 0 || nextUrls.Count == 0) {
        return;
      }

      if (depth != -1) {
        depth--;
      }

      BfsCrawlParallel(nextUrls, depth, thread, semaphore);
    }

    // private HtmlDocument Download(string url) {
    //   limiter.Acquire();
    //   var page = client.DownloadString(url);
    //   var doc = new HtmlDocument();
    //   doc.LoadHtml(page);
    //   
    //   return doc;
    // }

    // Make it cancellable, Semaphore has take the task of limiter
    private HtmlDocument Download(string url) {
      // limiter.Acquire();
      var page = client.GetStringAsync(url);
      var doc = new HtmlDocument();
      page.Wait(ctx);
      doc.LoadHtml(page.Result);
      // TODO save page here
      return doc;
    }
  }

  // Useless for Parallel

  // Now without thread safety
  // internal class Limiter {
  //   private readonly int interval;
  //   private long last;
  //
  //   public Limiter(int i) {
  //     interval = i;
  //   }
  //
  //   public void Acquire() {
  //     var now = DateTime.Now.ToFileTime();
  //     var span = now - last;
  //     if (span >= interval) {
  //       last = now;
  //     }
  //     else {
  //       Thread.Sleep(interval - (int)span);
  //       last = DateTime.Now.ToFileTime();
  //     }
  //   }
  // }
}