namespace CrawlerGUI {
  partial class CrawlerGUI {
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
      this.MainGrid = new System.Windows.Forms.TableLayoutPanel();
      this.AddressPanel = new System.Windows.Forms.TableLayoutPanel();
      this.InputURL = new System.Windows.Forms.TextBox();
      this.LabelURL = new System.Windows.Forms.Label();
      this.ButtonStart = new System.Windows.Forms.Button();
      this.OptionPanel = new System.Windows.Forms.TableLayoutPanel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
      this.UseBFS = new System.Windows.Forms.RadioButton();
      this.UseDFS = new System.Windows.Forms.RadioButton();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.LabelDepth = new System.Windows.Forms.Label();
      this.DepthInput = new System.Windows.Forms.TextBox();
      this.StatusBox = new System.Windows.Forms.RichTextBox();
      this.MainGrid.SuspendLayout();
      this.AddressPanel.SuspendLayout();
      this.OptionPanel.SuspendLayout();
      this.panel1.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // MainGrid
      // 
      this.MainGrid.ColumnCount = 1;
      this.MainGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.MainGrid.Controls.Add(this.AddressPanel, 0, 0);
      this.MainGrid.Controls.Add(this.OptionPanel, 0, 1);
      this.MainGrid.Controls.Add(this.StatusBox, 0, 2);
      this.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MainGrid.Location = new System.Drawing.Point(0, 0);
      this.MainGrid.Name = "MainGrid";
      this.MainGrid.RowCount = 3;
      this.MainGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.MainGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.MainGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.MainGrid.Size = new System.Drawing.Size(669, 441);
      this.MainGrid.TabIndex = 0;
      // 
      // AddressPanel
      // 
      this.AddressPanel.ColumnCount = 3;
      this.AddressPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
      this.AddressPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.AddressPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
      this.AddressPanel.Controls.Add(this.InputURL, 1, 0);
      this.AddressPanel.Controls.Add(this.LabelURL, 0, 0);
      this.AddressPanel.Controls.Add(this.ButtonStart, 2, 0);
      this.AddressPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.AddressPanel.Location = new System.Drawing.Point(0, 0);
      this.AddressPanel.Margin = new System.Windows.Forms.Padding(0);
      this.AddressPanel.Name = "AddressPanel";
      this.AddressPanel.RowCount = 1;
      this.AddressPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.AddressPanel.Size = new System.Drawing.Size(669, 50);
      this.AddressPanel.TabIndex = 0;
      // 
      // InputURL
      // 
      this.InputURL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.InputURL.Location = new System.Drawing.Point(103, 11);
      this.InputURL.Margin = new System.Windows.Forms.Padding(3, 11, 3, 3);
      this.InputURL.Name = "InputURL";
      this.InputURL.Size = new System.Drawing.Size(463, 29);
      this.InputURL.TabIndex = 0;
      this.InputURL.Text = "http://";
      this.InputURL.KeyUp += new System.Windows.Forms.KeyEventHandler(this.InputURL_KeyUp);
      // 
      // LabelURL
      // 
      this.LabelURL.AutoSize = true;
      this.LabelURL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LabelURL.ForeColor = System.Drawing.Color.Red;
      this.LabelURL.Location = new System.Drawing.Point(3, 0);
      this.LabelURL.Name = "LabelURL";
      this.LabelURL.Size = new System.Drawing.Size(94, 50);
      this.LabelURL.TabIndex = 1;
      this.LabelURL.Text = "StartURL:";
      this.LabelURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // ButtonStart
      // 
      this.ButtonStart.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ButtonStart.Enabled = false;
      this.ButtonStart.Location = new System.Drawing.Point(572, 11);
      this.ButtonStart.Margin = new System.Windows.Forms.Padding(3, 11, 6, 11);
      this.ButtonStart.Name = "ButtonStart";
      this.ButtonStart.Size = new System.Drawing.Size(91, 28);
      this.ButtonStart.TabIndex = 2;
      this.ButtonStart.Text = "Start";
      this.ButtonStart.UseVisualStyleBackColor = true;
      this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
      // 
      // OptionPanel
      // 
      this.OptionPanel.ColumnCount = 2;
      this.OptionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.OptionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.OptionPanel.Controls.Add(this.panel1, 0, 0);
      this.OptionPanel.Controls.Add(this.tableLayoutPanel1, 1, 0);
      this.OptionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.OptionPanel.Location = new System.Drawing.Point(0, 50);
      this.OptionPanel.Margin = new System.Windows.Forms.Padding(0);
      this.OptionPanel.Name = "OptionPanel";
      this.OptionPanel.RowCount = 1;
      this.OptionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.OptionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.OptionPanel.Size = new System.Drawing.Size(669, 50);
      this.OptionPanel.TabIndex = 1;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.tableLayoutPanel3);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(6, 3);
      this.panel1.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(325, 44);
      this.panel1.TabIndex = 0;
      // 
      // tableLayoutPanel3
      // 
      this.tableLayoutPanel3.ColumnCount = 2;
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel3.Controls.Add(this.UseBFS, 0, 0);
      this.tableLayoutPanel3.Controls.Add(this.UseDFS, 1, 0);
      this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 1;
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
      this.tableLayoutPanel3.Size = new System.Drawing.Size(325, 44);
      this.tableLayoutPanel3.TabIndex = 0;
      // 
      // UseBFS
      // 
      this.UseBFS.AutoSize = true;
      this.UseBFS.Checked = true;
      this.UseBFS.Dock = System.Windows.Forms.DockStyle.Fill;
      this.UseBFS.Location = new System.Drawing.Point(3, 3);
      this.UseBFS.Name = "UseBFS";
      this.UseBFS.Size = new System.Drawing.Size(156, 38);
      this.UseBFS.TabIndex = 0;
      this.UseBFS.TabStop = true;
      this.UseBFS.Text = "BFS";
      this.UseBFS.UseVisualStyleBackColor = true;
      // 
      // UseDFS
      // 
      this.UseDFS.AutoSize = true;
      this.UseDFS.Dock = System.Windows.Forms.DockStyle.Fill;
      this.UseDFS.Location = new System.Drawing.Point(165, 3);
      this.UseDFS.Name = "UseDFS";
      this.UseDFS.Size = new System.Drawing.Size(157, 38);
      this.UseDFS.TabIndex = 1;
      this.UseDFS.Text = "DFS";
      this.UseDFS.UseVisualStyleBackColor = true;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.LabelDepth, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.DepthInput, 1, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(337, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(329, 44);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // LabelDepth
      // 
      this.LabelDepth.AutoSize = true;
      this.LabelDepth.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LabelDepth.ForeColor = System.Drawing.Color.Green;
      this.LabelDepth.Location = new System.Drawing.Point(3, 0);
      this.LabelDepth.Name = "LabelDepth";
      this.LabelDepth.Size = new System.Drawing.Size(64, 44);
      this.LabelDepth.TabIndex = 0;
      this.LabelDepth.Text = "Depth:";
      this.LabelDepth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // DepthInput
      // 
      this.DepthInput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DepthInput.Location = new System.Drawing.Point(73, 9);
      this.DepthInput.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
      this.DepthInput.Name = "DepthInput";
      this.DepthInput.Size = new System.Drawing.Size(253, 29);
      this.DepthInput.TabIndex = 1;
      this.DepthInput.Text = "-1";
      this.DepthInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DepthInput_KeyUp);
      // 
      // StatusBox
      // 
      this.StatusBox.DetectUrls = false;
      this.StatusBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.StatusBox.Location = new System.Drawing.Point(3, 103);
      this.StatusBox.Name = "StatusBox";
      this.StatusBox.ReadOnly = true;
      this.StatusBox.Size = new System.Drawing.Size(663, 335);
      this.StatusBox.TabIndex = 2;
      this.StatusBox.Text = "";
      // 
      // CrawlerGUI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(669, 441);
      this.Controls.Add(this.MainGrid);
      this.MinimumSize = new System.Drawing.Size(400, 300);
      this.Name = "CrawlerGUI";
      this.Text = "Crawler";
      this.MainGrid.ResumeLayout(false);
      this.AddressPanel.ResumeLayout(false);
      this.AddressPanel.PerformLayout();
      this.OptionPanel.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.tableLayoutPanel3.ResumeLayout(false);
      this.tableLayoutPanel3.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainGrid;
        private System.Windows.Forms.TableLayoutPanel AddressPanel;
        private System.Windows.Forms.TextBox InputURL;
        private System.Windows.Forms.Label LabelURL;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.TableLayoutPanel OptionPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton UseBFS;
        private System.Windows.Forms.RadioButton UseDFS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LabelDepth;
        private System.Windows.Forms.TextBox DepthInput;
        private System.Windows.Forms.RichTextBox StatusBox;
    }
}

