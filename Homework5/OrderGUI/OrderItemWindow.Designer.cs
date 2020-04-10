namespace OrderGUI {
  sealed partial class OrderItemWindow {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.statusPanel = new System.Windows.Forms.Panel();
      this.statusLabel = new System.Windows.Forms.Label();
      this.mainPanel = new System.Windows.Forms.Panel();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.buttonCommit = new System.Windows.Forms.Button();
      this.operationInput = new System.Windows.Forms.TextBox();
      this.listBox = new System.Windows.Forms.GroupBox();
      this.itemsView = new System.Windows.Forms.DataGridView();
      this.statusPanel.SuspendLayout();
      this.mainPanel.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.listBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.itemsView)).BeginInit();
      this.SuspendLayout();
      // 
      // statusPanel
      // 
      this.statusPanel.Controls.Add(this.statusLabel);
      this.statusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.statusPanel.Location = new System.Drawing.Point(0, 440);
      this.statusPanel.Name = "statusPanel";
      this.statusPanel.Size = new System.Drawing.Size(882, 30);
      this.statusPanel.TabIndex = 0;
      // 
      // statusLabel
      // 
      this.statusLabel.AutoSize = true;
      this.statusLabel.Dock = System.Windows.Forms.DockStyle.Left;
      this.statusLabel.Location = new System.Drawing.Point(0, 0);
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(84, 22);
      this.statusLabel.TabIndex = 0;
      this.statusLabel.Text = "Loading...";
      // 
      // mainPanel
      // 
      this.mainPanel.Controls.Add(this.tableLayoutPanel1);
      this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainPanel.Location = new System.Drawing.Point(0, 0);
      this.mainPanel.Name = "mainPanel";
      this.mainPanel.Size = new System.Drawing.Size(882, 440);
      this.mainPanel.TabIndex = 1;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.operationInput, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.listBox, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(882, 440);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 3;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.Controls.Add(this.buttonCommit, 1, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 393);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(876, 44);
      this.tableLayoutPanel2.TabIndex = 0;
      // 
      // buttonCommit
      // 
      this.buttonCommit.Dock = System.Windows.Forms.DockStyle.Fill;
      this.buttonCommit.Location = new System.Drawing.Point(391, 3);
      this.buttonCommit.Name = "buttonCommit";
      this.buttonCommit.Size = new System.Drawing.Size(94, 38);
      this.buttonCommit.TabIndex = 0;
      this.buttonCommit.Text = "Commit";
      this.buttonCommit.UseVisualStyleBackColor = true;
      this.buttonCommit.Click += new System.EventHandler(this.buttonCommit_Click);
      // 
      // operationInput
      // 
      this.operationInput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.operationInput.Location = new System.Drawing.Point(3, 363);
      this.operationInput.Name = "operationInput";
      this.operationInput.Size = new System.Drawing.Size(876, 29);
      this.operationInput.TabIndex = 1;
      this.operationInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.operationInput_KeyUp);
      // 
      // listBox
      // 
      this.listBox.Controls.Add(this.itemsView);
      this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listBox.Location = new System.Drawing.Point(3, 3);
      this.listBox.Name = "listBox";
      this.listBox.Size = new System.Drawing.Size(876, 354);
      this.listBox.TabIndex = 2;
      this.listBox.TabStop = false;
      this.listBox.Text = "OrderItems";
      // 
      // itemsView
      // 
      this.itemsView.AllowUserToAddRows = false;
      this.itemsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.itemsView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.itemsView.Location = new System.Drawing.Point(3, 25);
      this.itemsView.Name = "itemsView";
      this.itemsView.RowHeadersWidth = 51;
      this.itemsView.RowTemplate.Height = 31;
      this.itemsView.Size = new System.Drawing.Size(870, 326);
      this.itemsView.TabIndex = 0;
      this.itemsView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.itemsView_UserDeletingRow);
      // 
      // OrderItemWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(882, 470);
      this.Controls.Add(this.mainPanel);
      this.Controls.Add(this.statusPanel);
      this.ImeMode = System.Windows.Forms.ImeMode.Off;
      this.Name = "OrderItemWindow";
      this.Text = "Edit OrderItem";
      this.statusPanel.ResumeLayout(false);
      this.statusPanel.PerformLayout();
      this.mainPanel.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.listBox.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.itemsView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel statusPanel;
    private System.Windows.Forms.Label statusLabel;
    private System.Windows.Forms.Panel mainPanel;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Button buttonCommit;
    private System.Windows.Forms.TextBox operationInput;
    private System.Windows.Forms.GroupBox listBox;
    private System.Windows.Forms.DataGridView itemsView;
  }
}