namespace ColorChime
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtWavFilePath = new System.Windows.Forms.TextBox();
            this.lblWavFile = new System.Windows.Forms.Label();
            this.btnSelectWavFile = new System.Windows.Forms.Button();
            this.lblWatchInterval = new System.Windows.Forms.Label();
            this.lblWatchIntervalSec = new System.Windows.Forms.Label();
            this.numUDWatchInterval = new System.Windows.Forms.NumericUpDown();
            this.watchTimer = new System.Windows.Forms.Timer(this.components);
            this.lblTargetArea = new System.Windows.Forms.Label();
            this.lblTargetColor = new System.Windows.Forms.Label();
            this.txtTargetColor = new System.Windows.Forms.TextBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numUD_ay = new System.Windows.Forms.NumericUpDown();
            this.numUD_ax = new System.Windows.Forms.NumericUpDown();
            this.numUD_by = new System.Windows.Forms.NumericUpDown();
            this.numUD_bx = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numUDWatchInterval)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_ay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_ax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_by)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_bx)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 22);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "開始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(93, 11);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // txtWavFilePath
            // 
            this.txtWavFilePath.Location = new System.Drawing.Point(88, 79);
            this.txtWavFilePath.Name = "txtWavFilePath";
            this.txtWavFilePath.Size = new System.Drawing.Size(271, 19);
            this.txtWavFilePath.TabIndex = 4;
            this.txtWavFilePath.TextChanged += new System.EventHandler(this.txtWavFilePath_TextChanged);
            // 
            // lblWavFile
            // 
            this.lblWavFile.AutoSize = true;
            this.lblWavFile.Location = new System.Drawing.Point(10, 82);
            this.lblWavFile.Name = "lblWavFile";
            this.lblWavFile.Size = new System.Drawing.Size(59, 12);
            this.lblWavFile.TabIndex = 5;
            this.lblWavFile.Text = "wavファイル";
            // 
            // btnSelectWavFile
            // 
            this.btnSelectWavFile.Location = new System.Drawing.Point(365, 77);
            this.btnSelectWavFile.Name = "btnSelectWavFile";
            this.btnSelectWavFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectWavFile.TabIndex = 5;
            this.btnSelectWavFile.Text = "参照";
            this.btnSelectWavFile.UseVisualStyleBackColor = true;
            this.btnSelectWavFile.Click += new System.EventHandler(this.btnSelectWavFile_Click);
            // 
            // lblWatchInterval
            // 
            this.lblWatchInterval.AutoSize = true;
            this.lblWatchInterval.Location = new System.Drawing.Point(10, 51);
            this.lblWatchInterval.Name = "lblWatchInterval";
            this.lblWatchInterval.Size = new System.Drawing.Size(53, 12);
            this.lblWatchInterval.TabIndex = 9;
            this.lblWatchInterval.Text = "監視間隔";
            // 
            // lblWatchIntervalSec
            // 
            this.lblWatchIntervalSec.AutoSize = true;
            this.lblWatchIntervalSec.Location = new System.Drawing.Point(153, 51);
            this.lblWatchIntervalSec.Name = "lblWatchIntervalSec";
            this.lblWatchIntervalSec.Size = new System.Drawing.Size(17, 12);
            this.lblWatchIntervalSec.TabIndex = 11;
            this.lblWatchIntervalSec.Text = "秒";
            // 
            // numUDWatchInterval
            // 
            this.numUDWatchInterval.Location = new System.Drawing.Point(88, 48);
            this.numUDWatchInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDWatchInterval.Name = "numUDWatchInterval";
            this.numUDWatchInterval.Size = new System.Drawing.Size(59, 19);
            this.numUDWatchInterval.TabIndex = 3;
            this.numUDWatchInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // watchTimer
            // 
            this.watchTimer.Tick += new System.EventHandler(this.watchTimer_Tick);
            // 
            // lblTargetArea
            // 
            this.lblTargetArea.AutoSize = true;
            this.lblTargetArea.Location = new System.Drawing.Point(13, 114);
            this.lblTargetArea.Name = "lblTargetArea";
            this.lblTargetArea.Size = new System.Drawing.Size(54, 12);
            this.lblTargetArea.TabIndex = 13;
            this.lblTargetArea.Text = "監視エリア";
            // 
            // lblTargetColor
            // 
            this.lblTargetColor.AutoSize = true;
            this.lblTargetColor.Location = new System.Drawing.Point(16, 228);
            this.lblTargetColor.Name = "lblTargetColor";
            this.lblTargetColor.Size = new System.Drawing.Size(53, 12);
            this.lblTargetColor.TabIndex = 18;
            this.lblTargetColor.Text = "監視RGB";
            // 
            // txtTargetColor
            // 
            this.txtTargetColor.Location = new System.Drawing.Point(88, 225);
            this.txtTargetColor.Name = "txtTargetColor";
            this.txtTargetColor.Size = new System.Drawing.Size(100, 19);
            this.txtTargetColor.TabIndex = 10;
            this.txtTargetColor.Text = "#000000";
            this.txtTargetColor.TextChanged += new System.EventHandler(this.txtTargetColor_TextChanged);
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.Location = new System.Drawing.Point(194, 223);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(75, 23);
            this.btnSelectColor.TabIndex = 11;
            this.btnSelectColor.Text = "選択";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectColor_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numUD_ay);
            this.panel1.Controls.Add(this.numUD_ax);
            this.panel1.Controls.Add(this.numUD_by);
            this.panel1.Controls.Add(this.numUD_bx);
            this.panel1.Location = new System.Drawing.Point(88, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(7, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = ",";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(7, 12);
            this.label4.TabIndex = 35;
            this.label4.Text = ",";
            // 
            // numUD_ay
            // 
            this.numUD_ay.Location = new System.Drawing.Point(57, -1);
            this.numUD_ay.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numUD_ay.Name = "numUD_ay";
            this.numUD_ay.Size = new System.Drawing.Size(50, 19);
            this.numUD_ay.TabIndex = 7;
            // 
            // numUD_ax
            // 
            this.numUD_ax.Location = new System.Drawing.Point(0, -1);
            this.numUD_ax.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numUD_ax.Name = "numUD_ax";
            this.numUD_ax.Size = new System.Drawing.Size(50, 19);
            this.numUD_ax.TabIndex = 6;
            // 
            // numUD_by
            // 
            this.numUD_by.Location = new System.Drawing.Point(149, 80);
            this.numUD_by.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numUD_by.Name = "numUD_by";
            this.numUD_by.Size = new System.Drawing.Size(50, 19);
            this.numUD_by.TabIndex = 9;
            // 
            // numUD_bx
            // 
            this.numUD_bx.Location = new System.Drawing.Point(92, 80);
            this.numUD_bx.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numUD_bx.Name = "numUD_bx";
            this.numUD_bx.Size = new System.Drawing.Size(50, 19);
            this.numUD_bx.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 260);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSelectColor);
            this.Controls.Add(this.txtTargetColor);
            this.Controls.Add(this.lblTargetColor);
            this.Controls.Add(this.lblTargetArea);
            this.Controls.Add(this.numUDWatchInterval);
            this.Controls.Add(this.lblWatchIntervalSec);
            this.Controls.Add(this.lblWatchInterval);
            this.Controls.Add(this.btnSelectWavFile);
            this.Controls.Add(this.lblWavFile);
            this.Controls.Add(this.txtWavFilePath);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "ColorChime";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUDWatchInterval)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_ay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_ax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_by)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_bx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox txtWavFilePath;
        private System.Windows.Forms.Label lblWavFile;
        private System.Windows.Forms.Button btnSelectWavFile;
        private System.Windows.Forms.Label lblWatchInterval;
        private System.Windows.Forms.Label lblWatchIntervalSec;
        private System.Windows.Forms.NumericUpDown numUDWatchInterval;
        private System.Windows.Forms.Timer watchTimer;
        private System.Windows.Forms.Label lblTargetArea;
        private System.Windows.Forms.Label lblTargetColor;
        private System.Windows.Forms.TextBox txtTargetColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numUD_ay;
        private System.Windows.Forms.NumericUpDown numUD_ax;
        private System.Windows.Forms.NumericUpDown numUD_by;
        private System.Windows.Forms.NumericUpDown numUD_bx;
    }
}

