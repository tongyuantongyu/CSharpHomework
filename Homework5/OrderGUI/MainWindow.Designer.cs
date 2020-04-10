namespace OrderGUI {
  partial class MainWindow {
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
      this.statusPanel = new System.Windows.Forms.Panel();
      this.statusLabel = new System.Windows.Forms.Label();
      this.mainTable = new System.Windows.Forms.TableLayoutPanel();
      this.dataViewTable = new System.Windows.Forms.TableLayoutPanel();
      this.currentBox = new System.Windows.Forms.GroupBox();
      this.currentView = new System.Windows.Forms.DataGridView();
      this.panel1 = new System.Windows.Forms.Panel();
      this.operationInput = new System.Windows.Forms.TextBox();
      this.allBox = new System.Windows.Forms.GroupBox();
      this.allView = new System.Windows.Forms.DataGridView();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.buttonCreate = new System.Windows.Forms.Button();
      this.buttonQuery = new System.Windows.Forms.Button();
      this.buttonUpdate = new System.Windows.Forms.Button();
      this.buttonDelete = new System.Windows.Forms.Button();
      this.buttonImport = new System.Windows.Forms.Button();
      this.buttonExport = new System.Windows.Forms.Button();
      this.statusPanel.SuspendLayout();
      this.mainTable.SuspendLayout();
      this.dataViewTable.SuspendLayout();
      this.currentBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.currentView)).BeginInit();
      this.panel1.SuspendLayout();
      this.allBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.allView)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusPanel
      // 
      this.statusPanel.Controls.Add(this.statusLabel);
      this.statusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.statusPanel.Location = new System.Drawing.Point(0, 624);
      this.statusPanel.Name = "statusPanel";
      this.statusPanel.Size = new System.Drawing.Size(1031, 29);
      this.statusPanel.TabIndex = 0;
      // 
      // statusLabel
      // 
      this.statusLabel.AutoSize = true;
      this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.statusLabel.Location = new System.Drawing.Point(0, 0);
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(84, 22);
      this.statusLabel.TabIndex = 0;
      this.statusLabel.Text = "Loading...";
      // 
      // mainTable
      // 
      this.mainTable.ColumnCount = 2;
      this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
      this.mainTable.Controls.Add(this.dataViewTable, 0, 0);
      this.mainTable.Controls.Add(this.tableLayoutPanel1, 1, 0);
      this.mainTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainTable.Location = new System.Drawing.Point(0, 0);
      this.mainTable.Name = "mainTable";
      this.mainTable.RowCount = 1;
      this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.mainTable.Size = new System.Drawing.Size(1031, 624);
      this.mainTable.TabIndex = 1;
      // 
      // dataViewTable
      // 
      this.dataViewTable.ColumnCount = 1;
      this.dataViewTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.dataViewTable.Controls.Add(this.currentBox, 0, 0);
      this.dataViewTable.Controls.Add(this.allBox, 0, 1);
      this.dataViewTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataViewTable.Location = new System.Drawing.Point(3, 3);
      this.dataViewTable.Name = "dataViewTable";
      this.dataViewTable.RowCount = 2;
      this.dataViewTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
      this.dataViewTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
      this.dataViewTable.Size = new System.Drawing.Size(925, 618);
      this.dataViewTable.TabIndex = 0;
      // 
      // currentBox
      // 
      this.currentBox.Controls.Add(this.currentView);
      this.currentBox.Controls.Add(this.panel1);
      this.currentBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.currentBox.Location = new System.Drawing.Point(3, 3);
      this.currentBox.Name = "currentBox";
      this.currentBox.Size = new System.Drawing.Size(919, 426);
      this.currentBox.TabIndex = 0;
      this.currentBox.TabStop = false;
      this.currentBox.Text = "Current";
      // 
      // currentView
      // 
      this.currentView.AllowUserToAddRows = false;
      this.currentView.AllowUserToDeleteRows = false;
      this.currentView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.currentView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.currentView.Location = new System.Drawing.Point(3, 25);
      this.currentView.Name = "currentView";
      this.currentView.RowHeadersWidth = 51;
      this.currentView.RowTemplate.Height = 31;
      this.currentView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.currentView.Size = new System.Drawing.Size(913, 367);
      this.currentView.TabIndex = 1;
      this.currentView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.currentView_CellDoubleClick);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.operationInput);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(3, 392);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(913, 31);
      this.panel1.TabIndex = 0;
      // 
      // operationInput
      // 
      this.operationInput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.operationInput.Location = new System.Drawing.Point(0, 0);
      this.operationInput.Name = "operationInput";
      this.operationInput.Size = new System.Drawing.Size(913, 29);
      this.operationInput.TabIndex = 0;
      this.operationInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.operationInput_KeyUp);
      // 
      // allBox
      // 
      this.allBox.Controls.Add(this.allView);
      this.allBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.allBox.Location = new System.Drawing.Point(3, 435);
      this.allBox.Name = "allBox";
      this.allBox.Size = new System.Drawing.Size(919, 180);
      this.allBox.TabIndex = 1;
      this.allBox.TabStop = false;
      this.allBox.Text = "All";
      // 
      // allView
      // 
      this.allView.AllowUserToAddRows = false;
      this.allView.AllowUserToDeleteRows = false;
      this.allView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.allView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.allView.Location = new System.Drawing.Point(3, 25);
      this.allView.Name = "allView";
      this.allView.RowHeadersWidth = 51;
      this.allView.RowTemplate.Height = 31;
      this.allView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.allView.Size = new System.Drawing.Size(913, 152);
      this.allView.TabIndex = 0;
      this.allView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.allView_CellDoubleClick);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.buttonCreate, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.buttonQuery, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.buttonUpdate, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.buttonDelete, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.buttonImport, 0, 4);
      this.tableLayoutPanel1.Controls.Add(this.buttonExport, 0, 5);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(934, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 7;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(94, 618);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // buttonCreate
      // 
      this.buttonCreate.Dock = System.Windows.Forms.DockStyle.Fill;
      this.buttonCreate.Location = new System.Drawing.Point(3, 3);
      this.buttonCreate.Name = "buttonCreate";
      this.buttonCreate.Size = new System.Drawing.Size(88, 44);
      this.buttonCreate.TabIndex = 0;
      this.buttonCreate.Text = "&Create";
      this.buttonCreate.UseVisualStyleBackColor = true;
      this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
      // 
      // buttonQuery
      // 
      this.buttonQuery.Dock = System.Windows.Forms.DockStyle.Fill;
      this.buttonQuery.Location = new System.Drawing.Point(3, 53);
      this.buttonQuery.Name = "buttonQuery";
      this.buttonQuery.Size = new System.Drawing.Size(88, 44);
      this.buttonQuery.TabIndex = 1;
      this.buttonQuery.Text = "Que&ry";
      this.buttonQuery.UseVisualStyleBackColor = true;
      this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
      // 
      // buttonUpdate
      // 
      this.buttonUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
      this.buttonUpdate.Location = new System.Drawing.Point(3, 103);
      this.buttonUpdate.Name = "buttonUpdate";
      this.buttonUpdate.Size = new System.Drawing.Size(88, 44);
      this.buttonUpdate.TabIndex = 2;
      this.buttonUpdate.Text = "&Update";
      this.buttonUpdate.UseVisualStyleBackColor = true;
      this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
      // 
      // buttonDelete
      // 
      this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Fill;
      this.buttonDelete.Location = new System.Drawing.Point(3, 153);
      this.buttonDelete.Name = "buttonDelete";
      this.buttonDelete.Size = new System.Drawing.Size(88, 44);
      this.buttonDelete.TabIndex = 3;
      this.buttonDelete.Text = "&Delete";
      this.buttonDelete.UseVisualStyleBackColor = true;
      this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
      // 
      // buttonImport
      // 
      this.buttonImport.Dock = System.Windows.Forms.DockStyle.Fill;
      this.buttonImport.Location = new System.Drawing.Point(3, 203);
      this.buttonImport.Name = "buttonImport";
      this.buttonImport.Size = new System.Drawing.Size(88, 44);
      this.buttonImport.TabIndex = 4;
      this.buttonImport.Text = "&Import";
      this.buttonImport.UseVisualStyleBackColor = true;
      this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
      // 
      // buttonExport
      // 
      this.buttonExport.Dock = System.Windows.Forms.DockStyle.Fill;
      this.buttonExport.Location = new System.Drawing.Point(3, 253);
      this.buttonExport.Name = "buttonExport";
      this.buttonExport.Size = new System.Drawing.Size(88, 44);
      this.buttonExport.TabIndex = 5;
      this.buttonExport.Text = "&Export";
      this.buttonExport.UseVisualStyleBackColor = true;
      this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
      // 
      // MainWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1031, 653);
      this.Controls.Add(this.mainTable);
      this.Controls.Add(this.statusPanel);
      this.ImeMode = System.Windows.Forms.ImeMode.Disable;
      this.Name = "MainWindow";
      this.Text = "OrderSystem";
      this.statusPanel.ResumeLayout(false);
      this.statusPanel.PerformLayout();
      this.mainTable.ResumeLayout(false);
      this.dataViewTable.ResumeLayout(false);
      this.currentBox.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.currentView)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.allBox.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.allView)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel statusPanel;
    private System.Windows.Forms.Label statusLabel;
    private System.Windows.Forms.TableLayoutPanel mainTable;
    private System.Windows.Forms.TableLayoutPanel dataViewTable;
    private System.Windows.Forms.GroupBox currentBox;
    private System.Windows.Forms.DataGridView currentView;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox operationInput;
    private System.Windows.Forms.GroupBox allBox;
    private System.Windows.Forms.DataGridView allView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonExport;
    }
}

