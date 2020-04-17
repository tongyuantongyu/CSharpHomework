using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WebCrawler;

namespace CrawlerGUI {
  public partial class CrawlerGUI : Form {
    private bool validUrl;
    private Uri startURI;

    private bool validDepth = true;
    private int depth = -1;

    private bool running;
    private bool stopping;
    private Thread crawlerThread;

    private Action canceller;
    // public bool ValidConfig => validUrl && validDepth;

    private static (Func<bool>, Action) Context()
    {
      var fired = false;
      return (() => fired, () => fired = true);
    }

    public CrawlerGUI() {
      InitializeComponent();
      // ButtonStart.DataBindings.Add(
      //   "Enabled",
      //   this,
      //   "ValidConfig",
      //   false,
      //   DataSourceUpdateMode.OnPropertyChanged);
    }

    private void InputURL_KeyUp(object sender, KeyEventArgs e) {
      try {
        startURI = new Uri(InputURL.Text);
        if (!string.IsNullOrWhiteSpace(startURI.Authority)) {
          LabelURL.ForeColor = Color.Green;
          validUrl = true;
          ButtonStart.Enabled = validUrl && validDepth && !stopping;
          return;
        }
      }
      catch (Exception) {
        // ignored
      }

      validUrl = false;
      ButtonStart.Enabled = validUrl && validDepth && !stopping;
      LabelURL.ForeColor = Color.Red;
    }

    private void DepthInput_KeyUp(object sender, KeyEventArgs e) {
      // ReSharper disable once AssignmentInConditionalExpression
      if (validDepth = int.TryParse(DepthInput.Text, out depth)) {
        LabelDepth.ForeColor = Color.Green;
      }
      else {
        LabelDepth.ForeColor = Color.Red;
      }
      ButtonStart.Enabled = validUrl && validDepth && !stopping;
    }

    private void ButtonStart_Click(object sender, EventArgs e) {
      if (!running) {
        StatusBox.Text = string.Empty;
        var mode = UseBFS.Checked ? CrawlMode.Bfs : CrawlMode.Dfs;
        Func<bool> context;
        (context, canceller) = Context();
        var crawler = new Crawler(startURI, false, context);
        crawler.OnInfoEmitted += info => Invoke((MethodInvoker) delegate {
          StatusBox.SelectionStart = StatusBox.Text.Length;
          StatusBox.SelectedText = info + "\r\n";
        });
        // crawler.OnInfoEmitted += info => StatusBox.Text += info + '\n';
        void CrawlerStart() => crawler.Start(depth, mode);
        crawlerThread = new Thread(CrawlerStart);
        crawlerThread.Start();
        running = true;
        ButtonStart.Text = "Stop";
      }
      else {
        stopping = true;
        ButtonStart.Enabled = false;
        canceller();

        void CrawlerJoiner() {
          crawlerThread.Join();
          Invoke((MethodInvoker) delegate {
            stopping = false;
            ButtonStart.Enabled = validUrl && validDepth;
            StatusBox.Text += "Stopped.";
            running = false;
            ButtonStart.Text = "Start";
          });
        }

        var joinerThread = new Thread(CrawlerJoiner);
        joinerThread.Start();
      }
    }
  }
}