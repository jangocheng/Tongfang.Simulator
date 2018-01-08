namespace Tongfang.Simulator
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanelInput = new System.Windows.Forms.TableLayoutPanel();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStartup = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBoxReceive = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClearReceive = new System.Windows.Forms.Button();
            this.richTextBoxReceive = new System.Windows.Forms.RichTextBox();
            this.richTextBoxError = new System.Windows.Forms.RichTextBox();
            this.btnClearError = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelInput.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxReceive.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelInput, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxReceive, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.richTextBoxError, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.btnClearError, 1, 3);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 4;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(584, 441);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelInput
            // 
            this.tableLayoutPanelInput.ColumnCount = 4;
            this.tableLayoutPanelInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelInput.Controls.Add(this.labelIP, 0, 0);
            this.tableLayoutPanelInput.Controls.Add(this.labelPort, 2, 0);
            this.tableLayoutPanelInput.Controls.Add(this.textBoxIP, 1, 0);
            this.tableLayoutPanelInput.Controls.Add(this.textBoxPort, 3, 0);
            this.tableLayoutPanelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInput.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelInput.Name = "tableLayoutPanelInput";
            this.tableLayoutPanelInput.RowCount = 1;
            this.tableLayoutPanelInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInput.Size = new System.Drawing.Size(461, 38);
            this.tableLayoutPanelInput.TabIndex = 0;
            // 
            // labelIP
            // 
            this.labelIP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(14, 13);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(17, 12);
            this.labelIP.TabIndex = 0;
            this.labelIP.Text = "IP";
            // 
            // labelPort
            // 
            this.labelPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(330, 13);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 12);
            this.labelPort.TabIndex = 1;
            this.labelPort.Text = "端口";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxIP.Location = new System.Drawing.Point(49, 8);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(240, 21);
            this.textBoxIP.TabIndex = 2;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxPort.Location = new System.Drawing.Point(371, 8);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(60, 21);
            this.textBoxPort.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStartup, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(470, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(111, 38);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnStartup
            // 
            this.btnStartup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartup.Location = new System.Drawing.Point(3, 7);
            this.btnStartup.Name = "btnStartup";
            this.btnStartup.Size = new System.Drawing.Size(49, 23);
            this.btnStartup.TabIndex = 0;
            this.btnStartup.Text = "开启";
            this.btnStartup.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Location = new System.Drawing.Point(58, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // groupBoxReceive
            // 
            this.groupBoxReceive.Controls.Add(this.richTextBoxReceive);
            this.groupBoxReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxReceive.Location = new System.Drawing.Point(3, 47);
            this.groupBoxReceive.Name = "groupBoxReceive";
            this.groupBoxReceive.Size = new System.Drawing.Size(461, 258);
            this.groupBoxReceive.TabIndex = 2;
            this.groupBoxReceive.TabStop = false;
            this.groupBoxReceive.Text = "接受的数据";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnClearReceive, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(470, 47);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(111, 258);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // btnClearReceive
            // 
            this.btnClearReceive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClearReceive.Location = new System.Drawing.Point(18, 213);
            this.btnClearReceive.Name = "btnClearReceive";
            this.btnClearReceive.Size = new System.Drawing.Size(75, 23);
            this.btnClearReceive.TabIndex = 0;
            this.btnClearReceive.Text = "清空";
            this.toolTipMain.SetToolTip(this.btnClearReceive, "清空接受数据");
            this.btnClearReceive.UseVisualStyleBackColor = true;
            this.btnClearReceive.Click += new System.EventHandler(this.btnClearReceive_Click);
            // 
            // richTextBoxReceive
            // 
            this.richTextBoxReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxReceive.Location = new System.Drawing.Point(3, 17);
            this.richTextBoxReceive.Name = "richTextBoxReceive";
            this.richTextBoxReceive.ReadOnly = true;
            this.richTextBoxReceive.Size = new System.Drawing.Size(455, 238);
            this.richTextBoxReceive.TabIndex = 0;
            this.richTextBoxReceive.Text = "";
            // 
            // richTextBoxError
            // 
            this.richTextBoxError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxError.Location = new System.Drawing.Point(3, 399);
            this.richTextBoxError.Name = "richTextBoxError";
            this.richTextBoxError.ReadOnly = true;
            this.richTextBoxError.Size = new System.Drawing.Size(461, 39);
            this.richTextBoxError.TabIndex = 4;
            this.richTextBoxError.Text = "";
            this.toolTipMain.SetToolTip(this.richTextBoxError, "异常信息");
            // 
            // btnClearError
            // 
            this.btnClearError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClearError.Location = new System.Drawing.Point(488, 407);
            this.btnClearError.Name = "btnClearError";
            this.btnClearError.Size = new System.Drawing.Size(75, 23);
            this.btnClearError.TabIndex = 5;
            this.btnClearError.Text = "清空";
            this.toolTipMain.SetToolTip(this.btnClearError, "清空异常");
            this.btnClearError.UseVisualStyleBackColor = true;
            this.btnClearError.Click += new System.EventHandler(this.btnClearError_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 441);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "MainForm";
            this.Text = "模拟服务";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelInput.ResumeLayout(false);
            this.tableLayoutPanelInput.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxReceive.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInput;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnStartup;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxReceive;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnClearReceive;
        private System.Windows.Forms.RichTextBox richTextBoxReceive;
        private System.Windows.Forms.RichTextBox richTextBoxError;
        private System.Windows.Forms.Button btnClearError;
    }
}

