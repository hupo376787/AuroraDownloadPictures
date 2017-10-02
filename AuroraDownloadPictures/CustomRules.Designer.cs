namespace AuroraDownloadPictures
{
    partial class CustomRules
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomRules));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.listViewEx1 = new AuroraDownloadPictures.ListViewEx();
            this.columnHeader_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_DisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Website = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_OldString = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_NewString = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 20);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(12, 12);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 1;
            this.button_Add.Text = "添加规则";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(93, 12);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 2;
            this.button_Delete.Text = "删除规则";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // listViewEx1
            // 
            this.listViewEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewEx1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ID,
            this.columnHeader_DisplayName,
            this.columnHeader_Website,
            this.columnHeader_OldString,
            this.columnHeader_NewString});
            this.listViewEx1.FullRowSelect = true;
            this.listViewEx1.GridLines = true;
            this.listViewEx1.LargeImageList = this.imageList1;
            this.listViewEx1.Location = new System.Drawing.Point(12, 49);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(619, 318);
            this.listViewEx1.SmallImageList = this.imageList1;
            this.listViewEx1.TabIndex = 0;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_ID
            // 
            this.columnHeader_ID.Text = "序号";
            this.columnHeader_ID.Width = 50;
            // 
            // columnHeader_DisplayName
            // 
            this.columnHeader_DisplayName.Text = "显示名称";
            this.columnHeader_DisplayName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_DisplayName.Width = 150;
            // 
            // columnHeader_Website
            // 
            this.columnHeader_Website.Text = "英文网站匹配";
            this.columnHeader_Website.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_Website.Width = 150;
            // 
            // columnHeader_OldString
            // 
            this.columnHeader_OldString.Text = "旧字符串";
            this.columnHeader_OldString.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_OldString.Width = 120;
            // 
            // columnHeader_NewString
            // 
            this.columnHeader_NewString.Text = "新字符串";
            this.columnHeader_NewString.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_NewString.Width = 120;
            // 
            // CustomRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 379);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.listViewEx1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomRules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自定义规则";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomRules_FormClosing);
            this.Load += new System.EventHandler(this.CustomRules_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListViewEx listViewEx1;
        private System.Windows.Forms.ColumnHeader columnHeader_ID;
        private System.Windows.Forms.ColumnHeader columnHeader_DisplayName;
        private System.Windows.Forms.ColumnHeader columnHeader_Website;
        private System.Windows.Forms.ColumnHeader columnHeader_OldString;
        private System.Windows.Forms.ColumnHeader columnHeader_NewString;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Delete;
    }
}