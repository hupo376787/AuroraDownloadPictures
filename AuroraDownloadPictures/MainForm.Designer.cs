namespace AuroraDownloadPictures
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBox_WebSite = new System.Windows.Forms.TextBox();
            this.button_Go = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.comboBox_PicStyle = new System.Windows.Forms.ComboBox();
            this.pictureBox_Show = new System.Windows.Forms.PictureBox();
            this.textBox_AllHtml = new System.Windows.Forms.TextBox();
            this.button_OpenDownFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_WebSiteName = new System.Windows.Forms.ComboBox();
            this.button_About = new System.Windows.Forms.Button();
            this.comboBox_Height = new System.Windows.Forms.ComboBox();
            this.comboBox_Width = new System.Windows.Forms.ComboBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Show)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_WebSite
            // 
            this.textBox_WebSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_WebSite.Location = new System.Drawing.Point(12, 10);
            this.textBox_WebSite.Multiline = true;
            this.textBox_WebSite.Name = "textBox_WebSite";
            this.textBox_WebSite.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_WebSite.Size = new System.Drawing.Size(496, 77);
            this.textBox_WebSite.TabIndex = 0;
            this.textBox_WebSite.TextChanged += new System.EventHandler(this.textBox_WebSite_TextChanged);
            // 
            // button_Go
            // 
            this.button_Go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Go.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button_Go.Location = new System.Drawing.Point(517, 64);
            this.button_Go.Name = "button_Go";
            this.button_Go.Size = new System.Drawing.Size(66, 23);
            this.button_Go.TabIndex = 1;
            this.button_Go.Text = "获取图片";
            this.button_Go.UseVisualStyleBackColor = true;
            this.button_Go.Click += new System.EventHandler(this.button_Go_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(68, 462);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(705, 17);
            this.progressBar1.TabIndex = 2;
            // 
            // comboBox_PicStyle
            // 
            this.comboBox_PicStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_PicStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PicStyle.FormattingEnabled = true;
            this.comboBox_PicStyle.Items.AddRange(new object[] {
            "页面图片",
            "高清原图"});
            this.comboBox_PicStyle.Location = new System.Drawing.Point(517, 37);
            this.comboBox_PicStyle.Name = "comboBox_PicStyle";
            this.comboBox_PicStyle.Size = new System.Drawing.Size(120, 20);
            this.comboBox_PicStyle.TabIndex = 3;
            this.comboBox_PicStyle.SelectedValueChanged += new System.EventHandler(this.comboBox_PicStyle_SelectedValueChanged);
            // 
            // pictureBox_Show
            // 
            this.pictureBox_Show.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Show.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Show.Image = global::AuroraDownloadPictures.Properties.Resources.thunder;
            this.pictureBox_Show.Location = new System.Drawing.Point(12, 93);
            this.pictureBox_Show.Name = "pictureBox_Show";
            this.pictureBox_Show.Size = new System.Drawing.Size(496, 353);
            this.pictureBox_Show.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Show.TabIndex = 5;
            this.pictureBox_Show.TabStop = false;
            this.pictureBox_Show.DoubleClick += new System.EventHandler(this.pictureBox_Show_DoubleClick);
            // 
            // textBox_AllHtml
            // 
            this.textBox_AllHtml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_AllHtml.Location = new System.Drawing.Point(517, 93);
            this.textBox_AllHtml.Multiline = true;
            this.textBox_AllHtml.Name = "textBox_AllHtml";
            this.textBox_AllHtml.ReadOnly = true;
            this.textBox_AllHtml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_AllHtml.Size = new System.Drawing.Size(256, 353);
            this.textBox_AllHtml.TabIndex = 7;
            // 
            // button_OpenDownFolder
            // 
            this.button_OpenDownFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OpenDownFolder.Location = new System.Drawing.Point(611, 64);
            this.button_OpenDownFolder.Name = "button_OpenDownFolder";
            this.button_OpenDownFolder.Size = new System.Drawing.Size(66, 23);
            this.button_OpenDownFolder.TabIndex = 9;
            this.button_OpenDownFolder.Text = "打开目录";
            this.button_OpenDownFolder.UseVisualStyleBackColor = true;
            this.button_OpenDownFolder.Click += new System.EventHandler(this.button_OpenDownFolder_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(656, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "宽度>=";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(656, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "高度>=";
            // 
            // comboBox_WebSiteName
            // 
            this.comboBox_WebSiteName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_WebSiteName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_WebSiteName.FormattingEnabled = true;
            this.comboBox_WebSiteName.Location = new System.Drawing.Point(517, 9);
            this.comboBox_WebSiteName.Name = "comboBox_WebSiteName";
            this.comboBox_WebSiteName.Size = new System.Drawing.Size(120, 20);
            this.comboBox_WebSiteName.TabIndex = 14;
            this.comboBox_WebSiteName.SelectedIndexChanged += new System.EventHandler(this.comboBox_WebSiteName_SelectedIndexChanged);
            // 
            // button_About
            // 
            this.button_About.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_About.Location = new System.Drawing.Point(707, 64);
            this.button_About.Name = "button_About";
            this.button_About.Size = new System.Drawing.Size(66, 23);
            this.button_About.TabIndex = 15;
            this.button_About.Text = "关于我";
            this.button_About.UseVisualStyleBackColor = true;
            this.button_About.Click += new System.EventHandler(this.button_About_Click);
            // 
            // comboBox_Height
            // 
            this.comboBox_Height.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Height.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AuroraDownloadPictures.Properties.Settings.Default, "str_Height", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox_Height.FormattingEnabled = true;
            this.comboBox_Height.Items.AddRange(new object[] {
            "0",
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000",
            "1200",
            "1500",
            "2000",
            "2500",
            "3000",
            "3500",
            "4000",
            "4500",
            "5000"});
            this.comboBox_Height.Location = new System.Drawing.Point(703, 9);
            this.comboBox_Height.Name = "comboBox_Height";
            this.comboBox_Height.Size = new System.Drawing.Size(70, 20);
            this.comboBox_Height.TabIndex = 12;
            this.comboBox_Height.Text = global::AuroraDownloadPictures.Properties.Settings.Default.str_Height;
            this.comboBox_Height.TextChanged += new System.EventHandler(this.comboBox_Height_TextChanged);
            this.comboBox_Height.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_Height_KeyPress);
            // 
            // comboBox_Width
            // 
            this.comboBox_Width.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Width.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AuroraDownloadPictures.Properties.Settings.Default, "str_Width", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox_Width.FormattingEnabled = true;
            this.comboBox_Width.Items.AddRange(new object[] {
            "0",
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000",
            "1200",
            "1500",
            "2000",
            "2500",
            "3000",
            "3500",
            "4000",
            "4500",
            "5000"});
            this.comboBox_Width.Location = new System.Drawing.Point(703, 37);
            this.comboBox_Width.Name = "comboBox_Width";
            this.comboBox_Width.Size = new System.Drawing.Size(70, 20);
            this.comboBox_Width.TabIndex = 10;
            this.comboBox_Width.Text = global::AuroraDownloadPictures.Properties.Settings.Default.str_Width;
            this.comboBox_Width.TextChanged += new System.EventHandler(this.comboBox_Width_TextChanged);
            this.comboBox_Width.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_Width_KeyPress);
            // 
            // progressBar2
            // 
            this.progressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar2.Location = new System.Drawing.Point(68, 485);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(705, 17);
            this.progressBar2.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 465);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "当前进度";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 486);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "总 进 度";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.button_About);
            this.Controls.Add(this.comboBox_WebSiteName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_Height);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Width);
            this.Controls.Add(this.button_OpenDownFolder);
            this.Controls.Add(this.textBox_AllHtml);
            this.Controls.Add(this.pictureBox_Show);
            this.Controls.Add(this.comboBox_PicStyle);
            this.Controls.Add(this.button_Go);
            this.Controls.Add(this.textBox_WebSite);
            this.Controls.Add(this.progressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aurora 图片下载";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_WebSite;
        private System.Windows.Forms.Button button_Go;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboBox_PicStyle;
        private System.Windows.Forms.PictureBox pictureBox_Show;
        private System.Windows.Forms.TextBox textBox_AllHtml;
        private System.Windows.Forms.Button button_OpenDownFolder;
        private System.Windows.Forms.ComboBox comboBox_Width;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Height;
        public System.Windows.Forms.ComboBox comboBox_WebSiteName;
        private System.Windows.Forms.Button button_About;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

