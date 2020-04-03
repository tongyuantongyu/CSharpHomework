using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace CayleyTree {
  partial class Cayley {
    /// <summary>
    /// 必需的设计器变量。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 清理所有正在使用的资源。
    /// </summary>
    /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows 窗体设计器生成的代码

    /// <summary>
    /// 设计器支持所需的方法 - 不要修改
    /// 使用代码编辑器修改此方法的内容。
    /// </summary>
    private void InitializeComponent() {
      this.Canvas = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.trackBarLA = new System.Windows.Forms.TrackBar();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.trackBarRA = new System.Windows.Forms.TrackBar();
      this.trackBarLR = new System.Windows.Forms.TrackBar();
      this.trackBarRR = new System.Windows.Forms.TrackBar();
      this.label5 = new System.Windows.Forms.Label();
      this.trackBarItTimes = new System.Windows.Forms.TrackBar();
      this.label6 = new System.Windows.Forms.Label();
      this.trackBarML = new System.Windows.Forms.TrackBar();
      this.colorPicker = new System.Windows.Forms.ColorDialog();
      this.labelColor = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarLA)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarRA)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarLR)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarRR)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarItTimes)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarML)).BeginInit();
      this.SuspendLayout();
      // 
      // Canvas
      // 
      this.Canvas.Location = new System.Drawing.Point(dx(12), dy(12));
      this.Canvas.Name = "Canvas";
      this.Canvas.Size = new System.Drawing.Size(dx(460), dy(500));
      this.Canvas.TabIndex = 1;
      this.Canvas.TabStop = false;
      this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPaint);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(dx(483), dy(17));
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(dx(127), dy(15));
      this.label1.TabIndex = 2;
      this.label1.Text = "LeftBranchAngle";
      // 
      // trackBarLA
      // 
      this.trackBarLA.LargeChange = 15;
      this.trackBarLA.Location = new System.Drawing.Point(dx(634), dy(12));
      this.trackBarLA.Maximum = 90;
      this.trackBarLA.Name = "trackBarLA";
      this.trackBarLA.Size = new System.Drawing.Size(dx(154), dy(56));
      this.trackBarLA.SmallChange = 5;
      this.trackBarLA.TabIndex = 3;
      this.trackBarLA.Scroll += new System.EventHandler(this.trackBarLA_Scroll);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(dx(483), dy(58));
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(dx(135), dy(15));
      this.label2.TabIndex = 4;
      this.label2.Text = "RightBranchAngle";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(dx(483), dy(127));
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(dx(135), dy(15));
      this.label3.TabIndex = 5;
      this.label3.Text = "LeftIterateRatio";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(dx(483), dy(170));
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(dx(135), dy(15));
      this.label4.TabIndex = 6;
      this.label4.Text = "RightIterateRatio";
      // 
      // trackBarRA
      // 
      this.trackBarRA.LargeChange = 15;
      this.trackBarRA.Location = new System.Drawing.Point(dx(634), dy(53));
      this.trackBarRA.Maximum = 90;
      this.trackBarRA.Name = "trackBarRA";
      this.trackBarRA.Size = new System.Drawing.Size(dx(154), dy(56));
      this.trackBarRA.SmallChange = 5;
      this.trackBarRA.TabIndex = 7;
      this.trackBarRA.Scroll += new System.EventHandler(this.trackBarRA_Scroll);
      // 
      // trackBarLR
      // 
      this.trackBarLR.Location = new System.Drawing.Point(dx(634), dy(122));
      this.trackBarLR.Maximum = 50;
      this.trackBarLR.Name = "trackBarLR";
      this.trackBarLR.Size = new System.Drawing.Size(dx(154), dy(56));
      this.trackBarLR.TabIndex = 8;
      this.trackBarLR.Scroll += new System.EventHandler(this.trackBarLR_Scroll);
      // 
      // trackBarRR
      // 
      this.trackBarRR.Location = new System.Drawing.Point(dx(634), dy(165));
      this.trackBarRR.Maximum = 50;
      this.trackBarRR.Name = "trackBarRR";
      this.trackBarRR.Size = new System.Drawing.Size(dx(154), dy(56));
      this.trackBarRR.TabIndex = 9;
      this.trackBarRR.Scroll += new System.EventHandler(this.trackBarRR_Scroll);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(dx(483), dy(237));
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(dy(103), dy(15));
      this.label5.TabIndex = 10;
      this.label5.Text = "IterateTimes";
      // 
      // trackBarItTimes
      // 
      this.trackBarItTimes.Location = new System.Drawing.Point(dx(634), dy(231));
      this.trackBarItTimes.Maximum = 20;
      this.trackBarItTimes.Name = "trackBarItTimes";
      this.trackBarItTimes.Size = new System.Drawing.Size(dx(154), dy(56));
      this.trackBarItTimes.TabIndex = 11;
      this.trackBarItTimes.Scroll += new System.EventHandler(this.trackBarItTimes_Scroll);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(dx(483), dy(302));
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(dx(87), dy(15));
      this.label6.TabIndex = 12;
      this.label6.Text = "MainLength";
      // 
      // trackBarML
      // 
      this.trackBarML.LargeChange = 50;
      this.trackBarML.Location = new System.Drawing.Point(dx(634), dy(302));
      this.trackBarML.Maximum = 200;
      this.trackBarML.Minimum = 50;
      this.trackBarML.Name = "trackBarML";
      this.trackBarML.Size = new System.Drawing.Size(dx(154), dy(56));
      this.trackBarML.SmallChange = 10;
      this.trackBarML.TabIndex = 13;
      this.trackBarML.Value = 50;
      this.trackBarML.Scroll += new System.EventHandler(this.trackBarML_Scroll);
      // 
      // labelColor
      // 
      this.labelColor.AutoSize = true;
      this.labelColor.Location = new System.Drawing.Point(dx(483), dy(377));
      this.labelColor.Name = "labelColor";
      this.labelColor.Size = new System.Drawing.Size(dx(175), dy(15));
      this.labelColor.TabIndex = 14;
      this.labelColor.Text = "Click to change color";
      this.labelColor.Click += new System.EventHandler(this.labelColor_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(dx(800), dy(425));
      this.Controls.Add(this.labelColor);
      this.Controls.Add(this.trackBarML);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.trackBarItTimes);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.trackBarRR);
      this.Controls.Add(this.trackBarLR);
      this.Controls.Add(this.trackBarRA);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.trackBarLA);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.Canvas);
      this.Name = "CayleyTree";
      this.Text = "CayleyTree";
      ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarLA)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarRA)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarLR)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarRR)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarItTimes)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarML)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.PictureBox Canvas;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TrackBar trackBarLA;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TrackBar trackBarRA;
    private System.Windows.Forms.TrackBar trackBarLR;
    private System.Windows.Forms.TrackBar trackBarRR;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TrackBar trackBarItTimes;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TrackBar trackBarML;
    private System.Windows.Forms.ColorDialog colorPicker;
    private System.Windows.Forms.Label labelColor;
  }
}

