namespace GUICalc
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Input1 = new System.Windows.Forms.TextBox();
            this.Input2 = new System.Windows.Forms.TextBox();
            this.OperatorSelector = new System.Windows.Forms.ListBox();
            this.buttonEqual = new System.Windows.Forms.Button();
            this.labelAnswer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Input1
            // 
            this.Input1.Location = new System.Drawing.Point(53, 39);
            this.Input1.Name = "Input1";
            this.Input1.Size = new System.Drawing.Size(100, 25);
            this.Input1.TabIndex = 0;
            // 
            // Input2
            // 
            this.Input2.Location = new System.Drawing.Point(285, 39);
            this.Input2.Name = "Input2";
            this.Input2.Size = new System.Drawing.Size(100, 25);
            this.Input2.TabIndex = 1;
            // 
            // OperatorSelector
            // 
            this.OperatorSelector.FormattingEnabled = true;
            this.OperatorSelector.ItemHeight = 15;
            this.OperatorSelector.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.OperatorSelector.Location = new System.Drawing.Point(159, 39);
            this.OperatorSelector.Name = "OperatorSelector";
            this.OperatorSelector.Size = new System.Drawing.Size(120, 94);
            this.OperatorSelector.TabIndex = 2;
            // 
            // buttonEqual
            // 
            this.buttonEqual.Location = new System.Drawing.Point(392, 40);
            this.buttonEqual.Name = "buttonEqual";
            this.buttonEqual.Size = new System.Drawing.Size(75, 23);
            this.buttonEqual.TabIndex = 3;
            this.buttonEqual.Text = "=";
            this.buttonEqual.UseVisualStyleBackColor = true;
            this.buttonEqual.Click += new System.EventHandler(this.buttonEqual_Click);
            // 
            // labelAnswer
            // 
            this.labelAnswer.AutoSize = true;
            this.labelAnswer.Location = new System.Drawing.Point(473, 42);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(15, 15);
            this.labelAnswer.TabIndex = 4;
            this.labelAnswer.Text = " ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 183);
            this.Controls.Add(this.labelAnswer);
            this.Controls.Add(this.buttonEqual);
            this.Controls.Add(this.OperatorSelector);
            this.Controls.Add(this.Input2);
            this.Controls.Add(this.Input1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Input1;
        private System.Windows.Forms.TextBox Input2;
        private System.Windows.Forms.ListBox OperatorSelector;
        private System.Windows.Forms.Button buttonEqual;
        private System.Windows.Forms.Label labelAnswer;
    }
}

