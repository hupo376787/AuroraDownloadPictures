using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Text;
using System.IO;
using System.Net;
using System.Linq;
using System.Media;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace AuroraDownloadPictures
{
    public partial class MainForm : Form
    {
        //此版本试用Aurora注册机注册时，选择商业版。

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        bool b_VIP = false;
        System.Windows.Forms.Timer timer_Progress;
        int n_ShowAd = 0;

        string str_WebSiteType = "";    //http, https

        string strDownloadFolder = Application.StartupPath;
        string str_charset = "utf-8";
        List<string> list_PictureUrl = new List<string>();
        int n_width = 200;
        int n_height = 200;
        int nWebsiteName = 1024;
        string str_WebsiteNamePinyin = "暂未识别";

        //自定义规则
        public List<string> list_Rules = new List<string>();
        string str_Old = "";    //要被替换的旧字符串
        string str_New = "";    //新的字符串

        private string GetWebSourceCode(string url)
        {
            if (url == "") return "";
            string strHTML = "";
            WebClient myWebClient = new WebClient();
            try
            {
                Stream myStream = myWebClient.OpenRead(url);
                Stream myStream1 = myStream;
                //StreamReader sr = new StreamReader(Application.StartupPath + "\\AuroraDownloadPictures.exe.config");

                StreamReader sr = new StreamReader(myStream, Encoding.UTF8);
                strHTML = sr.ReadToEnd();
                str_charset = GetCharset(strHTML);
                StreamReader sr1 = new StreamReader(myStream1, Encoding.GetEncoding(str_charset));
                strHTML = sr1.ReadToEnd();
                myStream.Close();
                myStream1.Close();
            }
            catch { }

            return strHTML;
        }

        private string GetHtml(string url, Encoding encoding)
        {
            byte[] buf = new WebClient().DownloadData(url);
            if (encoding != null) return encoding.GetString(buf);
            string html = Encoding.UTF8.GetString(buf);
            encoding = GetEncoding(html);
            if (encoding == null || encoding == Encoding.UTF8) return html;
            return encoding.GetString(buf);
        }

        private int GetTotalPages(string strURL, Encoding encoding, int nWebsiteName = (int)PublicClass.WebsiteName.unknown)
        {
            int nPage = 1;
            string strWebSource = "";
            strWebSource = GetHtml(strURL, encoding);
            
            try
            {
                if (nWebsiteName == (int)PublicClass.WebsiteName.fengniao_bbs)
                {
                    string strTemp = GetValue(strWebSource, "<!-- 分页-->", "下一页<i></i></a>") + "下一页";
                    strTemp = strTemp.Substring(strTemp.IndexOf("下一页") - 60, 2);
                    strTemp = strTemp.Replace(">", ""); strTemp = strTemp.Replace("<", ""); strTemp = strTemp.Replace("/", "");
                    nPage = Convert.ToInt32(strTemp);

                    if (nPage == 0)
                        nPage = 1;
                }
            }
            catch
            {
                return 1;
            }
            return nPage;
        }

        private string [] GenerateAllPages(string strURL, int nPages)
        {
            string[] sArray = new string[nPages];
            sArray[0] = strURL;
            for(int i = 2; i <= nPages; i++)
            {
                string strTemp = strURL.Replace(".html", "_" + i.ToString() + ".html"); ;
                sArray[i - 1] = strTemp;
            }
            return sArray;
        }

        Thread multi;
        bool isExitThread = false;
        private void button_Go_Click(object sender, EventArgs e)
        {
            //multi = new Thread(new ThreadStart(StartWork));
            //multi.IsBackground = true;
            //progressBar1.Value = 0;
            //if (button_Go.Text == "获取图片")
            //{
            //    button_Go.Text = "停止获取";
            //    multi.Start();
            //}
            //else
            //{
            //    multi.Abort();
            //    while (multi.ThreadState == ThreadState.AbortRequested)
            //    {
            //        Thread.Sleep(100);
            //    }
            //    button_Go.Text = "获取图片";
            //}

            multi = new Thread(new ThreadStart(StartWork));
            multi.IsBackground = true;
            progressBar1.Value = 0;
            if (button_Go.Text == "获取图片")
            {
                isExitThread = false;
                button_Go.Text = "停止获取";
                textBox_WebSite.Enabled = false;
                multi.Start();
            }
            else if(button_Go.Text == "停止获取")
            {
                isExitThread = true;
                button_Go.Text = "获取图片";
                textBox_WebSite.Enabled = true;
            }
        }

        private void StartWork()
        {
            while(isExitThread == false)
            {
                //开始
                progressBar1.Value = 0;
                textBox_AllHtml.Text = "";
                list_PictureUrl.Clear();
                pictureBox_Show.Image = null;
                button_Go.Text = "停止获取";
                textBox_WebSite.Enabled = false;

                if (textBox_WebSite.Text.Trim() == "")
                {
                    ShowTips("请输入一个有效的网址\r\n");
                    button_Go.Text = "获取图片";
                    textBox_WebSite.Enabled = true;
                    isExitThread = true;
                    return;
                }

                textBox_WebSite.Text = textBox_WebSite.Text.Trim();
                string[] ss = textBox_WebSite.Text.Split('\n');
                progressBar2.Maximum = ss.Length;

                for (int i = 0; i < ss.Length; i++)
                {
                    //验证URL
                    if (!IsUrl(ss[i].Trim()))
                    {
                        ShowTips("(" + (i + 1).ToString() + "/" + ss.Length.ToString() + ")" + "输入的不是网址\r\n\r\n");
                        continue;
                    }

                    PublicClass.GetWebSiteType(textBox_WebSite.Text, ref nWebsiteName, ref str_WebsiteNamePinyin);
                    SetcomboBox_WebSiteNameIndex();
                    progressBar2.Value = i;
                    ShowTips("正在分析" + "(" + (i + 1).ToString() + "/" + ss.Length.ToString() + ")\r\n\"" + ss[i].Trim() + "\"...\r\n");
                    StartWork(ss[i].Trim(), nWebsiteName);
                }

                SoundPlayer sp = new SoundPlayer(Properties.Resources.download_completed);
                sp.Play();
                progressBar2.Value = ss.Length;
                ShowTips("全部下载完成.\r\n\r\n\r\n");
                isExitThread = true;
                button_Go.Text = "获取图片";
                textBox_WebSite.Enabled = true;
            }
        }

        private void StartWork(string strURL, int nWebsiteName = (int)PublicClass.WebsiteName.unknown)
        {
            //页面示例
            //http://bbs.fengniao.com/forum/5015193.html
            //http://bbs.zol.com.cn/dcbbs/d16_434104.html

            string strWebSource = "";
            try
            {
                if (strURL.Substring(0, 7) != "http://" && strURL.Substring(0, 8) != "https://")
                {
                    strURL = "http://" + strURL;
                }
                if (strURL.Substring(0, 7) == "http://")
                    str_WebSiteType = PublicClass.WebSiteType.http.ToString();
                if (strURL.Substring(0, 8) == "https://")
                    str_WebSiteType = PublicClass.WebSiteType.https.ToString();
            }
            catch { }

            ShowTips("正在获取网页数据...\r\n");

            int nPages = GetTotalPages(strURL, null, nWebsiteName);
            if (nWebsiteName == (int)PublicClass.WebsiteName.fengniao_bbs)  //蜂鸟论坛的图片是一层楼一个，所以可能会不止一页有图
            {
                string[] sArray = GenerateAllPages(strURL, nPages);

                for(int i = 0; i < sArray.Length; i++)
                {
                    strWebSource += GetHtml(sArray[i], null);
                }
            }
            else
            {
                strWebSource = GetHtml(strURL, null);
            }

            if (strWebSource == "")
            {
                ShowTips("页面中无图片\r\n");
                button_Go.Text = "获取图片";
                isExitThread = true;
                textBox_WebSite.Enabled = true;
                return;
            }

            //创建文件夹
            string strWebTitle = GetValue(strWebSource, "<title>", "</title>");
            strWebTitle = strWebTitle.Trim();
            strWebTitle = strWebTitle.Replace("\\", "");
            strWebTitle = strWebTitle.Replace("/", "");
            strWebTitle = strWebTitle.Replace(":", "");
            strWebTitle = strWebTitle.Replace("*", "");
            strWebTitle = strWebTitle.Replace("?", "");
            strWebTitle = strWebTitle.Replace("\"", "");
            strWebTitle = strWebTitle.Replace(">", "");
            strWebTitle = strWebTitle.Replace("<", "");
            strWebTitle = strWebTitle.Replace("|", "");

            if (!Directory.Exists(Application.StartupPath + "\\下载的图片\\" + strWebTitle + "\\"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\下载的图片\\" + strWebTitle + "\\");
            }

            ShowTips("正在提取网页图片...\r\n");
            list_PictureUrl = GetHtmlImageUrlList(strWebSource);
            //for (int i = 0; i < list_PictureUrl.Count; i++)
            //{
            //    Console.WriteLine(list_PictureUrl[i]);
            //}
            progressBar1.Minimum = 0;
            progressBar1.Maximum = list_PictureUrl.Count;

            WebClient webclient = new WebClient();
            int n_sum = 0;  //统计下载个数 
            //高清原图
            if (comboBox_PicStyle.Text == "高清原图")
            {
                //List<string> list_PictureUrl_Temp = list_PictureUrl;
                //http://www.jiaonan.tv/html/blog/1/29606.htm
                List<string> list_PictureUrl_Temp = new List<string>(list_PictureUrl.ToArray());
                list_PictureUrl.Clear();
                for (int i = 0; i < list_PictureUrl_Temp.Count; i++)
                {
                    string strPicRealUrl = list_PictureUrl_Temp[i];
                    strPicRealUrl = GetPictureHDUrl(strPicRealUrl);
                    list_PictureUrl.Add(strPicRealUrl);
                }
            }

            for (int i = 0; i < list_PictureUrl.Count; i++)
            {
                string strPicRealUrl = list_PictureUrl[i];

                if (n_width != 0 || n_height != 0)
                {
                    try
                    {
                        Image O_Image = Image.FromStream(WebRequest.Create(strPicRealUrl).GetResponse().GetResponseStream());
                        if (n_width != 0 && n_height != 0)
                        {
                            if (O_Image.Width < n_width || O_Image.Height < n_height)
                                continue;
                        }
                        else if (n_width == 0 && n_height != 0)
                        {
                            if (O_Image.Height < n_height)
                                continue;
                        }
                        else if (n_width != 0 && n_height == 0)
                        {
                            if (O_Image.Width < n_width)
                                continue;
                        }
                    }
                    catch { }
                }

                int nTemp = strPicRealUrl.LastIndexOf('/');
                string strPicName = strPicRealUrl.Substring(nTemp + 1);
                string strPicFullPathName = Application.StartupPath + "\\下载的图片\\" + strWebTitle + "\\" + strPicName;
                strDownloadFolder = Application.StartupPath + "\\下载的图片\\" + strWebTitle;

                try
                {
                    DateTime dt1 = DateTime.Now;
                    webclient.DownloadFile(strPicRealUrl, strPicFullPathName);
                    n_sum++;
                }
                catch { }

                pictureBox_Show.ImageLocation = strPicFullPathName;
                progressBar1.Value = i + 1;

                //显示输出
                ShowTips(strPicRealUrl + "\r\n");
            }

            
            progressBar1.Value = list_PictureUrl.Count;
            CreateURLShortcut(strWebTitle, strDownloadFolder, strURL);
            ShowTips("总共获取" + n_sum.ToString() + "个图片.\r\n");
            if(comboBox_PicStyle.Text == "页面图片")
            {
                ShowTips("提示：当前下载的不是高清原图.\r\n");
                ShowTips("提示：当前下载的不是高清原图.\r\n");
                ShowTips("提示：当前下载的不是高清原图.\r\n");
            }
            ShowTips("下载完成.\r\n\r\n");
        }

        private bool IsUrl(string str_url)
        {
            return Regex.IsMatch(str_url, @"((http|https)://)?(www.)?[a-z0-9\.]+(\.(com|net|cn|com\.cn|com\.net|net\.cn))(/[^\s\n]*)?");
        }

        private string GetPictureHDUrl(string strUrl)
        {
            string strPicHDUrl = strUrl;
            //if (nWebsiteType == (int)PublicClass.WebsiteType.fengniao_bbs)
            //{
            //    //http://img3.fengniao.com/forum/attachpics/871/32/34806348_1024.jpg
            //    //http://img3.fengniao.com/forum/attachpics/871/32/34806348.jpg
            //    try
            //    {
            //        strPicHDUrl = strUrl.Replace("_1024", "");
            //    }
            //    catch { }
            //}
            //else if (nWebsiteType == (int)PublicClass.WebsiteType.zol_bbs)
            //{
            //    //http://i4.bbs.fd.zol-img.com.cn/t_s1200x5000/g5/M00/0F/0B/ChMkJ1aKP4mIKINfAAbF0VDazEAAAG97QBs-jcABsXp524.jpg
            //    //http://i4.bbs.fd.zol-img.com.cn/t_s2000x2000/g5/M00/0F/0B/ChMkJ1aKP4mIKINfAAbF0VDazEAAAG97QBs-jcABsXp524.jpg
            //    string strTemp = GetValue(strUrl, "t_s", "/g");
            //    try
            //    {
            //        strPicHDUrl = strUrl.Replace(strTemp, "2000x2000");
            //    }
            //    catch { }
            //}
            try
            {
                strPicHDUrl = strUrl.Replace(str_Old, str_New);
            }
            catch { }
            return strPicHDUrl;
        }

        // 根据网页的HTML内容提取网页的Encoding
        private string GetCharset(string sHtmlText)
        {
            string pattern = @"(?i)\bcharset=(?<charset>[-a-zA-Z_0-9]+)";
            string charset = "";
            Regex regImg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = regImg.Matches(sHtmlText);
            foreach (Match match in matches)
            {
                charset = match.Value;
            }
            return charset.Replace("charset=", "");
        }

        private Encoding GetEncoding(string sHtmlText)
        {
            try
            {
                string strQuot = "\"";
                string pattern = @"(?i)\bcharset=" + strQuot + @"?(?<charset>[-a-zA-Z_0-9]+)" + strQuot + "?";
                string charset = "";
                Regex regImg = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matches = regImg.Matches(sHtmlText);

                charset = matches[0].Value;     //匹配网站头部的charset

                charset = charset.Replace("charset=", "");
                charset = charset.Replace("\"", "");
                try { return Encoding.GetEncoding(charset); }
                catch (ArgumentException) { return null; }
            }
            catch
            {
                ShowTips("获取页面异常\r\n确定网址对了？");
                isExitThread = true;
                return null;
            }
        }

        /// <summary>
        /// 获得字符串中开始和结束字符串中间得值
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="s">开始</param>
        /// <param name="e">结束</param>
        /// <returns></returns> 
        public static string GetValue(string strinput, string start, string end)
        {
            Regex rg = new Regex("(?<=(" + start + "))[.\\s\\S]*?(?=(" + end + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(strinput).Value;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AboutMe me = new AboutMe();
            me.ShowDialog();

            timer_Progress = new System.Windows.Forms.Timer();
            timer_Progress.Interval = 1000;
            timer_Progress.Tick += new System.EventHandler(this.timer_Progress_Tick);
            timer_Progress.Enabled = true;

            RegistryHelper rh = new RegistryHelper();
            try
            {
                string strValidDays = rh.GetRegistryData(Registry.CurrentUser, "SOFTWARE\\Aurora\\AuroraDownloadPictures\\", "ValidDays");
                int nValidDays = Convert.ToInt32(strValidDays);

                string strRegDate = rh.GetRegistryData(Registry.CurrentUser, "SOFTWARE\\Aurora\\AuroraDownloadPictures\\", "RegDate");
                int nSpan = 0;
                TimeSpan d3 = DateTime.Now.Subtract(Convert.ToDateTime(strRegDate));
                nSpan = d3.Days;
                if(nSpan < 0)
                {
                    comboBox_PicStyle.Text = "页面图片";
                }
                else
                {
                    int nTemp = nValidDays - nSpan;
                    if (nTemp <= 31)
                        ShowTips("会员剩余天数:" + nTemp.ToString() + "\r\n\r\n" + "支持的网站：\r\n" +
                                "①蜂鸟网论坛\r\n" +
                                "http://bbs.fengniao.com/forum/***.html\r\n" +
                                "②中关村摄影论坛\r\n" +
                                "http://bbs.zol.com.cn/dcbbs/***.html\r\n" +
                                "③POCO摄影空间\r\n" +
                                "http://photo.poco.cn/lastphoto-htx-id-***-p-0.xhtml\r\n" +
                                "④图虫网\r\n" +
                                "https://portrait.tuchong.com/***/\r\n" +
                                "其他摄影论坛尚未添加,或者可以使用自定义功能自行添加\r\n\r\n");

                    if (strValidDays == "")
                        comboBox_PicStyle.Text = "页面图片";
                    else
                    {
                        if (nTemp > 0)
                        {
                            b_VIP = true;
                            comboBox_PicStyle.Text = "高清原图";
                            timer_Progress.Enabled = false;
                        }
                        else
                            comboBox_PicStyle.Text = "页面图片";
                    }
                }
            }
            catch
            {
                comboBox_PicStyle.Text = "页面图片";
            }

            LoadCustomRules();
        }

        private void comboBox_PicStyle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!b_VIP)
            {
                comboBox_PicStyle.Text = "页面图片";
                RegisterVip vip = new RegisterVip();
                vip.ShowDialog();
                return;
            }
            else
            {
                RegistryHelper rh = new RegistryHelper();
                if (comboBox_PicStyle.Text == "高清原图")
                {
                    try
                    {
                        string strLeftDays = rh.GetRegistryData(Registry.CurrentUser, "SOFTWARE\\Aurora\\AuroraDownloadPictures\\", "ValidDays");
                        if (strLeftDays == "")
                        {
                            RegisterVip vip = new RegisterVip();
                            vip.ShowDialog();
                        }
                        else
                        {
                            if (Convert.ToInt32(strLeftDays) <= 0)
                            {
                                RegisterVip vip = new RegisterVip();
                                vip.ShowDialog();
                            }
                        }
                    }
                    catch
                    {
                        RegisterVip vip = new RegisterVip();
                        vip.ShowDialog();
                    }

                    try
                    {
                        string strLeftDays = rh.GetRegistryData(Registry.CurrentUser, "SOFTWARE\\Aurora\\AuroraDownloadPictures\\", "ValidDays");
                        if (strLeftDays == "")
                            comboBox_PicStyle.Text = "页面图片";
                        else
                        {
                            if (Convert.ToInt32(strLeftDays) <= 0)
                            {
                                comboBox_PicStyle.Text = "页面图片";
                            }
                        }
                    }
                    catch
                    {
                        comboBox_PicStyle.Text = "页面图片";
                    }
                }
            }
        }

        private void button_OpenDownFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(strDownloadFolder);
        }

        // 取得HTML中所有图片的 URL。
        public List<string> GetHtmlImageUrlList(string sHtmlText)
        {
            List<string> list = new List<string>();

            // 定义正则表达式用来匹配 img 标签
            //Regex regImg = new Regex(@"(?<=http://).*?(?=.jpg)", RegexOptions.IgnoreCase)
            string str_Match = "";
            str_Match = @"https?://[^<>"" ?\s]*\.jpg";
            //if (str_WebSiteType == PublicClass.WebSiteType.http.ToString())
            //{
            //    str_Match = @"(?<=http://)((?!http://).)*.(?=.jpg)";
            //}
            //else if (str_WebSiteType == PublicClass.WebSiteType.https.ToString())
            //{
            //    str_Match = @"(?<=https://)((?!https://).)*.(?=.jpg)";
            //}
            Regex regImg = new Regex(str_Match, RegexOptions.IgnoreCase);

            // 搜索匹配的字符串
            MatchCollection matches = regImg.Matches(sHtmlText);

            // 取得匹配项列表
            foreach (Match match in matches)
            {
                string str = match.Value;// "http://" + match.Value + ".jpg";
                if (str.Contains("&nbsp;") || str.Contains("&quot;") || str.Contains("<") || str.Contains(">") ||
                    str.Contains("{") || str.Contains("}") || str.Contains("'"))     //网址不能包含空格&nbsp;   引号&quot;
                {
                    continue;
                }
                else if(str == "http://test.svn.fengniao.com/frontend_svn/fengniao/common-pic/photo.jpg")
                {
                    continue;
                }
                else if (str.Contains("fengniao") && str.Contains("head"))
                {
                    continue;
                }
                else if (str.Contains("zol") && !str.Contains("1200x5000"))
                {
                    continue;
                }
                else
                {
                    list.Add(str);
                }
            }
            //去重复，引入linq
            List<string> listPictureUrl_Distinct = new List<string>();
            listPictureUrl_Distinct = list.Distinct().ToList();
            return listPictureUrl_Distinct;
        }

        #region comboBox-宽度高度
        private void comboBox_Height_TextChanged(object sender, EventArgs e)
        {
            if (comboBox_Height.Text.Trim() == "")
                comboBox_Height.Text = "0";
            n_height = Convert.ToInt32(comboBox_Height.Text.Trim());
            if (n_height != 0)
                ShowTips("设置下载图片最小高度为：" + n_height.ToString() + "\r\n");
            else
                ShowTips("设置下载图片最小高度无限制\r\n");
        }

        private void comboBox_Width_TextChanged(object sender, EventArgs e)
        {
            if (comboBox_Width.Text.Trim() == "")
                comboBox_Width.Text = "0";
            n_width = Convert.ToInt32(comboBox_Width.Text.Trim());
            if (n_width != 0)
                ShowTips("设置下载图片最小宽度为：" + n_width.ToString() + "\r\n");
            else
                ShowTips("设置下载图片最小宽度无限制\r\n");
        }

        private void comboBox_Height_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int kc = (int)e.KeyChar;
                if ((kc < 48 || kc > 57) && kc != 8)
                    e.Handled = true;
            }
            catch { }
        }

        private void comboBox_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int kc = (int)e.KeyChar;
                if ((kc < 48 || kc > 57) && kc != 8)
                    e.Handled = true;
            }
            catch { }
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void comboBox_WebSiteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_WebSiteName.Text == "自定义规则")
            {
                CustomRules cs = new CustomRules();
                cs.ShowDialog(this);
            }
            else if (comboBox_WebSiteName.Text == "--------------")
            {
                return;
            }
            else
            {
                string str_Selected = comboBox_WebSiteName.Text;
                string str1 = "", str2 = "", str3 = "", str4 = "", str5 = "";
                for (int i = 0; i < list_Rules.Count; i++)
                {
                    string[] str_Arr = list_Rules[i].Split(',');
                    str1 = str_Arr[0];
                    str2 = str_Arr[1];
                    str3 = str_Arr[2];
                    str4 = str_Arr[3];
                    str5 = str_Arr[4];
                    if (str_Selected == str2)
                    {
                        break;
                    }
                }

                str_Old = str4;
                str_New = str5;
            }
        }

        //加载自定义规则
        private void LoadCustomRules()
        {
            string str_config = Application.StartupPath + "\\MyRules.cfg";
            string str_line = "";
            using (StreamReader sr = new StreamReader(str_config, Encoding.UTF8))
            {
                while ((str_line = sr.ReadLine()) != null)
                {
                    if (str_line.Substring(0, 2) == "//")
                    {
                        continue;
                    }
                    else
                    {
                        list_Rules.Add(str_line);
                        string[] str_Arr = str_line.Split(',');
                        string str_Temp = str_Arr[1];
                        comboBox_WebSiteName.Items.Add(str_Temp);
                    }
                }
            }
            comboBox_WebSiteName.Items.Add("暂未识别");
            comboBox_WebSiteName.Items.Add("--------------");
            comboBox_WebSiteName.Items.Add("自定义规则");
        }

        private void textBox_WebSite_TextChanged(object sender, EventArgs e)
        {
            PublicClass.GetWebSiteType(textBox_WebSite.Text, ref nWebsiteName, ref str_WebsiteNamePinyin);
            SetcomboBox_WebSiteNameIndex();
        }

        private void SetcomboBox_WebSiteNameIndex()
        {
            int n_Index = 4;
            for (int i = 0; i < comboBox_WebSiteName.Items.Count; i++)
            {
                if (str_WebsiteNamePinyin == comboBox_WebSiteName.Items[i].ToString())
                {
                    n_Index = i;
                    break;
                }
            }
            comboBox_WebSiteName.SelectedIndex = n_Index;
        }

        private void button_About_Click(object sender, EventArgs e)
        {
            AboutMe ab = new AboutMe();
            ab.ShowDialog();
        }

        private void CreateURLShortcut(string ShortcutName, string ShortcutLocation, string ShortcutURL)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ShortcutLocation + "\\" + ShortcutName + ".url"))
                {
                    writer.WriteLine("[InternetShortcut]");
                    writer.WriteLine("URL=" + ShortcutURL);
                    writer.Flush();
                }
            }
            catch { }
        }

        private void timer_Progress_Tick(object sender, EventArgs e)
        {
            n_ShowAd += 1000;
            if (n_ShowAd == 10000)
            {
                Screen CurrentSC = Screen.FromControl(this);
                Ad ad = new Ad();
                ad.Location = new Point(CurrentSC.WorkingArea.X + CurrentSC.WorkingArea.Width - 360, CurrentSC.WorkingArea.Y + CurrentSC.WorkingArea.Height - 220);
                ad.Show();
            }
        }

        private void ShowTips(string strTips)
        {
            textBox_AllHtml.Text += strTips;
            textBox_AllHtml.SelectionStart = this.textBox_AllHtml.TextLength;
            textBox_AllHtml.ScrollToCaret();
        }

        private void pictureBox_Show_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
    }
}
