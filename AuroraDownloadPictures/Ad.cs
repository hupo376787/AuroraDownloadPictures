using System;
using System.Windows.Forms;

namespace AuroraDownloadPictures
{
    public partial class Ad : Form
    {
        public Ad()
        {
            InitializeComponent();
        }

        Timer tm;

        public int n_AdType = 0;
        public int n_ShowAdTimeLength = 10;
        public string str_AdUrl = "";
        public string str_WhatisNew = "";

        private void Ad_Load(object sender, EventArgs e)
        {
            tm = new Timer();
            tm.Interval = 1000;
            tm.Tick += new EventHandler(Ad_Tick);
            tm.Start();
            
            this.Text = "广告推送(10s后自动关闭)";
            webBrowser1.Url = new Uri("http://www.2345.com/?k53345154");
        }

        private void Ad_Tick(object sender, EventArgs e)
        {
            n_ShowAdTimeLength--;
            this.Text = "广告推送(" + n_ShowAdTimeLength.ToString() + "s后自动关闭)";
            if (n_ShowAdTimeLength <= 0)
            {
                tm.Dispose();
                this.Close();
            }
        }
    }
}
