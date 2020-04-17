using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;

namespace WebCrawler {
  public enum CrawlMode {Bfs, Dfs}

  public class Crawler {
    private readonly HashSet<Uri> visited = new HashSet<Uri>();
    private readonly WebClient client = new WebClient {Encoding = Encoding.UTF8};
    private readonly Limiter limiter = new Limiter(1000);
    private readonly Uri startUri;
    private readonly Func<bool> ctx;

    public delegate void InfoOutput(string info);
    public event InfoOutput OnInfoEmitted;

    static void Main(string[] args) {
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

    public Crawler(string start, bool standalone = true, Func<bool> context = null) : this(new Uri(start), standalone, context) { }

    public Crawler(Uri start, bool standalone = true, Func<bool> context = null) {
      if (standalone) {
        OnInfoEmitted += Console.WriteLine;
      }
      startUri = start;
      ctx = context ?? (() => false);
    }

    public void Start(int depth = -1, CrawlMode mode = CrawlMode.Bfs) {
      switch (mode) {
        case CrawlMode.Bfs:
          BfsCrawl(new List<Uri>{startUri}, depth);
          break;
        case CrawlMode.Dfs:
          DfsCrawl(startUri, depth);
          break;
        // never
        default:
          throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
      }
    }

    private void DfsCrawl(Uri url, int depth) {
      if (ctx()) {
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
      if (links == null || ctx()) {
        return;
      }
      foreach (var link in links) {
        DfsCrawl(link, depth == -1 ? depth : depth - 1);
      }
    }

    private void BfsCrawl(IEnumerable<Uri> urls, int depth) {
      if (ctx()) {
        return;
      }
      var nextUrls = urls.Select(url => {
          if (ctx()) {
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
            .Where(uri => uri.Authority == startUri.Authority && !visited.Contains(uri)) ?? Enumerable.Empty<Uri>();
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

    private HtmlDocument Download(string url) {
      limiter.Acquire();
      var page = client.DownloadString(url);
      var doc = new HtmlDocument();
      doc.LoadHtml(page);
      // TODO save page here
      return doc;
    }
  }

  // Now without thread safety
  internal class Limiter {
    private readonly int interval;
    private long last;

    public Limiter(int i) {
      interval = i;
    }

    public void Acquire() {
      var now = DateTime.Now.ToFileTime();
      var span = now - last;
      if (span >= interval) {
        last = now;
      }
      else {
        Thread.Sleep(interval - (int)span);
        last = DateTime.Now.ToFileTime();
      }
    }
  }
}
