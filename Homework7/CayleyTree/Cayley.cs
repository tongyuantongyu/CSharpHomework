using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows;
using System.Windows.Forms;

namespace CayleyTree {
  public partial class Cayley : Form {
    private readonly double _dpiX, _dpiY;
    private readonly Func<int, int> dx, dy;
    private int angleLeft = 30;
    private int angleRight = 20;
    private Graphics graphics;
    private int iterateTimes = 10;
    private int mainLength = 100;
    private Size orgSize;
    private Pen p = Pens.Black;
    private int ratioLeft = 35;
    private int ratioRight = 30;
    private int xOrg = 200, yOrg = 500;

    public Cayley() {
      _dpiX = Screen.PrimaryScreen.Bounds.Width / SystemParameters.PrimaryScreenWidth;
      _dpiY = Screen.PrimaryScreen.Bounds.Width / SystemParameters.PrimaryScreenWidth;

      dx = pos => (int) (pos * _dpiX);
      dy = pos => (int) (pos * _dpiY);

      InitializeComponent();
      // this.AutoScaleBaseSize = new Size(6, 14);
      // this.ClientSize = new Size(800, 500);
      trackBarLA.Value = angleLeft;
      trackBarRA.Value = angleRight;
      trackBarLR.Value = ratioLeft;
      trackBarRR.Value = ratioRight;
      trackBarItTimes.Value = iterateTimes;
      trackBarML.Value = mainLength;
      orgSize = ClientSize;
      SizeChanged += (_, e) => {
        xOrg += (int) ((ClientSize.Width - orgSize.Width) / (_dpiX * 2));
        yOrg += +(int) ((ClientSize.Height - orgSize.Height) / _dpiY);
        Canvas.Size = new Size(
          Canvas.Size.Width + ClientSize.Width - orgSize.Width,
          Canvas.Size.Height + ClientSize.Height - orgSize.Height);
        Canvas.Refresh();
        foreach (Control control in Controls)
          if (control.Name != "Canvas") {
            control.Location = new Point(
              control.Location.X + ClientSize.Width - orgSize.Width,
              control.Location.Y);
          }

        orgSize = ClientSize;
      };
    }

    private double th1 => angleLeft * Math.PI / 180;
    private double th2 => angleRight * Math.PI / 180;
    private double per1 => ratioLeft * 0.02;
    private double per2 => ratioRight * 0.02;

    private void CanvasPaint(object sender, PaintEventArgs e) {
      graphics = e.Graphics;
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      DrawCayleyTree(iterateTimes, dx(xOrg), dy(yOrg), dy(mainLength), -Math.PI / 2);
    }


    private void DrawCayleyTree(int n,
      double x0, double y0, double leng, double th) {
      if (n == 0) {
        return;
      }

      var x1 = x0 + leng * Math.Cos(th);
      var y1 = y0 + leng * Math.Sin(th);

      DrawLine(x0, y0, x1, y1);

      if ((int) x0 == (int) x1 && (int) y0 == (int) y1) {
        return;
      }

      DrawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
      DrawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
    }

    private void DrawLine(double x0, double y0, double x1, double y1) {
      graphics.DrawLine(
        p,
        (int) x0, (int) y0, (int) x1, (int) y1);
    }

    private void trackBarItTimes_Scroll(object sender, EventArgs e) {
      // if (!(sender is Control control)) {
      //   return;
      // }
      //
      // Controls.Find(control.Name, false);
      iterateTimes = trackBarItTimes.Value;
      Canvas.Refresh();
    }

    private void trackBarLA_Scroll(object sender, EventArgs e) {
      angleLeft = trackBarLA.Value;
      Canvas.Refresh();
    }

    private void trackBarRA_Scroll(object sender, EventArgs e) {
      angleRight = trackBarRA.Value;
      Canvas.Refresh();
    }

    private void trackBarLR_Scroll(object sender, EventArgs e) {
      ratioLeft = trackBarLR.Value;
      Canvas.Refresh();
    }

    private void trackBarRR_Scroll(object sender, EventArgs e) {
      ratioRight = trackBarRR.Value;
      Canvas.Refresh();
    }

    private void trackBarML_Scroll(object sender, EventArgs e) {
      mainLength = trackBarML.Value;
      Canvas.Refresh();
    }

    private void labelColor_Click(object sender, EventArgs e) {
      var colorDialog = new ColorDialog {AllowFullOpen = false, ShowHelp = true, Color = labelColor.ForeColor};
      if (colorDialog.ShowDialog() != DialogResult.OK) {
        return;
      }

      labelColor.ForeColor = colorDialog.Color;
      p = new Pen(colorDialog.Color);
      Canvas.Refresh();
    }
  }
}