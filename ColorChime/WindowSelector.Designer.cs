namespace ColorChime
{
    partial class WindowSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lsvWinList = new System.Windows.Forms.ListView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkShowInvisible = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(12, 250);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "選択";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(462, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lsvWinList
            // 
            this.lsvWinList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvWinList.FullRowSelect = true;
            this.lsvWinList.GridLines = true;
            this.lsvWinList.HideSelection = false;
            this.lsvWinList.Location = new System.Drawing.Point(12, 41);
            this.lsvWinList.MultiSelect = false;
            this.lsvWinList.Name = "lsvWinList";
            this.lsvWinList.Size = new System.Drawing.Size(525, 203);
            this.lsvWinList.TabIndex = 3;
            this.lsvWinList.UseCompatibleStateImageBehavior = false;
            this.lsvWinList.View = System.Windows.Forms.View.Details;
            this.lsvWinList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lsvWinList_ColumnClick);
            this.lsvWinList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lsvWinList_ItemSelectionChanged);
            this.lsvWinList.DoubleClick += new System.EventHandler(this.lsvWinList_DoubleClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "更新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chkShowInvisible
            // 
            this.chkShowInvisible.AutoSize = true;
            this.chkShowInvisible.Location = new System.Drawing.Point(93, 16);
            this.chkShowInvisible.Name = "chkShowInvisible";
            this.chkShowInvisible.Size = new System.Drawing.Size(151, 16);
            this.chkShowInvisible.TabIndex = 5;
            this.chkShowInvisible.Text = "隠れたウィンドウを表示する";
            this.chkShowInvisible.UseVisualStyleBackColor = true;
            this.chkShowInvisible.CheckedChanged += new System.EventHandler(this.chkShowInvisible_CheckedChanged);
            // 
            // WindowSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 283);
            this.Controls.Add(this.chkShowInvisible);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lsvWinList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Name = "WindowSelector";
            this.Text = "ウィンドウ選択";
            this.Load += new System.EventHandler(this.WindowSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lsvWinList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chkShowInvisible;
    }
}