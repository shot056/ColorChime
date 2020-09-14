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
            this.txtInputColor = new System.Windows.Forms.TextBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numUD_ay = new System.Windows.Forms.NumericUpDown();
            this.numUD_ax = new System.Windows.Forms.NumericUpDown();
            this.numUD_by = new System.Windows.Forms.NumericUpDown();
            this.numUD_bx = new System.Windows.Forms.NumericUpDown();
            this.lblCaptureMode = new System.Windows.Forms.Label();
            this.comboCaptureMode = new System.Windows.Forms.ComboBox();
            this.btnSelectWin = new System.Windows.Forms.Button();
            this.txtTargetWindow = new System.Windows.Forms.TextBox();
            this.lsbTargetColors = new System.Windows.Forms.ListBox();
            this.btnDelColor = new System.Windows.Forms.Button();
            this.btnAddColor = new System.Windows.Forms.Button();
            this.btnShowCapImage = new System.Windows.Forms.Button();
            this.btnShowTargImage = new System.Windows.Forms.Button();
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
            this.txtWavFilePath.Location = new System.Drawing.Point(88, 127);
            this.txtWavFilePath.Name = "txtWavFilePath";
            this.txtWavFilePath.Size = new System.Drawing.Size(271, 19);
            this.txtWavFilePath.TabIndex = 4;
            this.txtWavFilePath.TextChanged += new System.EventHandler(this.txtWavFilePath_TextChanged);
            // 
            // lblWavFile
            // 
            this.lblWavFile.AutoSize = true;
            this.lblWavFile.Location = new System.Drawing.Point(10, 130);
            this.lblWavFile.Name = "lblWavFile";
            this.lblWavFile.Size = new System.Drawing.Size(59, 12);
            this.lblWavFile.TabIndex = 5;
            this.lblWavFile.Text = "wavファイル";
            // 
            // btnSelectWavFile
            // 
            this.btnSelectWavFile.Location = new System.Drawing.Point(365, 125);
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
            this.lblWatchInterval.Location = new System.Drawing.Point(10, 99);
            this.lblWatchInterval.Name = "lblWatchInterval";
            this.lblWatchInterval.Size = new System.Drawing.Size(53, 12);
            this.lblWatchInterval.TabIndex = 9;
            this.lblWatchInterval.Text = "監視間隔";
            // 
            // lblWatchIntervalSec
            // 
            this.lblWatchIntervalSec.AutoSize = true;
            this.lblWatchIntervalSec.Location = new System.Drawing.Point(153, 99);
            this.lblWatchIntervalSec.Name = "lblWatchIntervalSec";
            this.lblWatchIntervalSec.Size = new System.Drawing.Size(17, 12);
            this.lblWatchIntervalSec.TabIndex = 11;
            this.lblWatchIntervalSec.Text = "秒";
            // 
            // numUDWatchInterval
            // 
            this.numUDWatchInterval.Location = new System.Drawing.Point(88, 96);
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
            this.lblTargetArea.Location = new System.Drawing.Point(13, 162);
            this.lblTargetArea.Name = "lblTargetArea";
            this.lblTargetArea.Size = new System.Drawing.Size(54, 12);
            this.lblTargetArea.TabIndex = 13;
            this.lblTargetArea.Text = "監視エリア";
            // 
            // lblTargetColor
            // 
            this.lblTargetColor.AutoSize = true;
            this.lblTargetColor.Location = new System.Drawing.Point(16, 276);
            this.lblTargetColor.Name = "lblTargetColor";
            this.lblTargetColor.Size = new System.Drawing.Size(53, 12);
            this.lblTargetColor.TabIndex = 18;
            this.lblTargetColor.Text = "監視RGB";
            // 
            // txtInputColor
            // 
            this.txtInputColor.Location = new System.Drawing.Point(88, 346);
            this.txtInputColor.Name = "txtInputColor";
            this.txtInputColor.Size = new System.Drawing.Size(100, 19);
            this.txtInputColor.TabIndex = 10;
            this.txtInputColor.Text = "#000000";
            this.txtInputColor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInputColor_KeyDown);
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.Location = new System.Drawing.Point(194, 344);
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
            this.panel1.Location = new System.Drawing.Point(88, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 100);
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
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 87);
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
            this.numUD_ay.ValueChanged += new System.EventHandler(this.numUD_ay_ValueChanged);
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
            this.numUD_ax.ValueChanged += new System.EventHandler(this.numUD_ax_ValueChanged);
            // 
            // numUD_by
            // 
            this.numUD_by.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numUD_by.Location = new System.Drawing.Point(218, 80);
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
            this.numUD_bx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numUD_bx.Location = new System.Drawing.Point(161, 80);
            this.numUD_bx.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numUD_bx.Name = "numUD_bx";
            this.numUD_bx.Size = new System.Drawing.Size(50, 19);
            this.numUD_bx.TabIndex = 8;
            // 
            // lblCaptureMode
            // 
            this.lblCaptureMode.AutoSize = true;
            this.lblCaptureMode.Location = new System.Drawing.Point(10, 44);
            this.lblCaptureMode.Name = "lblCaptureMode";
            this.lblCaptureMode.Size = new System.Drawing.Size(77, 12);
            this.lblCaptureMode.TabIndex = 19;
            this.lblCaptureMode.Text = "キャプチャモード";
            // 
            // comboCaptureMode
            // 
            this.comboCaptureMode.DisplayMember = "アクティブウィンドウ ( Alt+PrintScreen )";
            this.comboCaptureMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCaptureMode.FormattingEnabled = true;
            this.comboCaptureMode.Location = new System.Drawing.Point(88, 41);
            this.comboCaptureMode.Name = "comboCaptureMode";
            this.comboCaptureMode.Size = new System.Drawing.Size(271, 20);
            this.comboCaptureMode.TabIndex = 20;
            this.comboCaptureMode.SelectedValueChanged += new System.EventHandler(this.comboCaptureMode_SelectedValueChanged);
            // 
            // btnSelectWin
            // 
            this.btnSelectWin.Enabled = false;
            this.btnSelectWin.Location = new System.Drawing.Point(365, 39);
            this.btnSelectWin.Name = "btnSelectWin";
            this.btnSelectWin.Size = new System.Drawing.Size(75, 23);
            this.btnSelectWin.TabIndex = 21;
            this.btnSelectWin.Text = "選択";
            this.btnSelectWin.UseVisualStyleBackColor = true;
            this.btnSelectWin.Click += new System.EventHandler(this.btnSelectWin_Click);
            // 
            // txtTargetWindow
            // 
            this.txtTargetWindow.Enabled = false;
            this.txtTargetWindow.Location = new System.Drawing.Point(88, 68);
            this.txtTargetWindow.Name = "txtTargetWindow";
            this.txtTargetWindow.Size = new System.Drawing.Size(352, 19);
            this.txtTargetWindow.TabIndex = 22;
            // 
            // lsbTargetColors
            // 
            this.lsbTargetColors.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lsbTargetColors.FormattingEnabled = true;
            this.lsbTargetColors.ItemHeight = 12;
            this.lsbTargetColors.Location = new System.Drawing.Point(88, 276);
            this.lsbTargetColors.Name = "lsbTargetColors";
            this.lsbTargetColors.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsbTargetColors.Size = new System.Drawing.Size(181, 64);
            this.lsbTargetColors.Sorted = true;
            this.lsbTargetColors.TabIndex = 23;
            // 
            // btnDelColor
            // 
            this.btnDelColor.Location = new System.Drawing.Point(275, 276);
            this.btnDelColor.Name = "btnDelColor";
            this.btnDelColor.Size = new System.Drawing.Size(75, 23);
            this.btnDelColor.TabIndex = 24;
            this.btnDelColor.Text = "削除";
            this.btnDelColor.UseVisualStyleBackColor = true;
            this.btnDelColor.Click += new System.EventHandler(this.btnDelColor_Click);
            // 
            // btnAddColor
            // 
            this.btnAddColor.Location = new System.Drawing.Point(275, 344);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(75, 23);
            this.btnAddColor.TabIndex = 25;
            this.btnAddColor.Text = "追加";
            this.btnAddColor.UseVisualStyleBackColor = true;
            this.btnAddColor.Click += new System.EventHandler(this.btnAddColor_Click);
            // 
            // btnShowCapImage
            // 
            this.btnShowCapImage.Location = new System.Drawing.Point(365, 164);
            this.btnShowCapImage.Name = "btnShowCapImage";
            this.btnShowCapImage.Size = new System.Drawing.Size(123, 23);
            this.btnShowCapImage.TabIndex = 26;
            this.btnShowCapImage.Text = "キャプチャ画像の確認";
            this.btnShowCapImage.UseVisualStyleBackColor = true;
            this.btnShowCapImage.Click += new System.EventHandler(this.btnShowCapImage_Click);
            // 
            // btnShowTargImage
            // 
            this.btnShowTargImage.Location = new System.Drawing.Point(366, 193);
            this.btnShowTargImage.Name = "btnShowTargImage";
            this.btnShowTargImage.Size = new System.Drawing.Size(122, 23);
            this.btnShowTargImage.TabIndex = 27;
            this.btnShowTargImage.Text = "監視画像の確認";
            this.btnShowTargImage.UseVisualStyleBackColor = true;
            this.btnShowTargImage.Click += new System.EventHandler(this.btnShowTargImage_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 373);
            this.Controls.Add(this.btnShowTargImage);
            this.Controls.Add(this.btnShowCapImage);
            this.Controls.Add(this.btnAddColor);
            this.Controls.Add(this.btnDelColor);
            this.Controls.Add(this.lsbTargetColors);
            this.Controls.Add(this.txtTargetWindow);
            this.Controls.Add(this.btnSelectWin);
            this.Controls.Add(this.comboCaptureMode);
            this.Controls.Add(this.lblCaptureMode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSelectColor);
            this.Controls.Add(this.txtInputColor);
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
        private System.Windows.Forms.TextBox txtInputColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numUD_ay;
        private System.Windows.Forms.NumericUpDown numUD_ax;
        private System.Windows.Forms.NumericUpDown numUD_by;
        private System.Windows.Forms.NumericUpDown numUD_bx;
        private System.Windows.Forms.Label lblCaptureMode;
        private System.Windows.Forms.ComboBox comboCaptureMode;
        private System.Windows.Forms.Button btnSelectWin;
        private System.Windows.Forms.TextBox txtTargetWindow;
        private System.Windows.Forms.ListBox lsbTargetColors;
        private System.Windows.Forms.Button btnDelColor;
        private System.Windows.Forms.Button btnAddColor;
        private System.Windows.Forms.Button btnShowCapImage;
        private System.Windows.Forms.Button btnShowTargImage;
    }
}

