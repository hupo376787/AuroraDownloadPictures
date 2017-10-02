using System.Windows.Forms;
using System;
using Microsoft.Win32;

namespace AuroraDownloadPictures
{
    public partial class AboutMe : Form
    {
        public AboutMe()
        {
            InitializeComponent();
        }

        //禁用窗体的关闭按钮
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //连续单机5次。
        private int i = 0;              //i用来计数，看点击了几次鼠标
        private DateTime lastClickTime = DateTime.MinValue;
        private void label3_Click(object sender, System.EventArgs e)
        {
            DateTime now = DateTime.Now;

            if ((now - lastClickTime).TotalMilliseconds <= 500)             // 两次点击间隔小于500毫秒时，算连续点击
            {
                i++;
                if (i >= 5)
                {
                    i = 0;// 连续点击完毕时，清0

                    DialogResult dr = MessageBox.Show("即将清除注册信息，清除后将不能下载高清原图", "Aurora 警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            RegistryKey key = Registry.CurrentUser;
                            key.DeleteSubKeyTree("SOFTWARE\\Aurora\\AuroraDownloadPictures", false);
                        }
                        catch { this.Close(); }
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                i = 1;// 不是连续点击时，清0
            }
            lastClickTime = now;
        }


    }
}
