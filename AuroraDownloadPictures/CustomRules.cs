using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AuroraDownloadPictures
{
    public partial class CustomRules : Form
    {
        public CustomRules()
        {
            InitializeComponent();
        }

        private void CustomRules_Load(object sender, EventArgs e)
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
                        string[] str_temp = str_line.Split(',');

                        int nCount = listViewEx1.Items.Count;
                        ListViewItem lst = new ListViewItem();
                        //lst.SubItems.Add(str_temp[0]);
                        lst.SubItems.Add(str_temp[1]);
                        lst.SubItems.Add(str_temp[2]);
                        lst.SubItems.Add(str_temp[3]);
                        lst.SubItems.Add(str_temp[4]);
                        listViewEx1.Items.Add(lst);
                        listViewEx1.EnsureVisible(nCount);
                        SortID();
                    }
                }
            }
        }

        private void CustomRules_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm frm = new MainForm();
            frm = (MainForm)this.Owner;

            frm.list_Rules.Clear();
            frm.comboBox_WebSiteName.Items.Clear();
            FileStream aFile = new FileStream(Application.StartupPath + "\\MyRules.cfg", FileMode.Create);
            StreamWriter MyWriter = new StreamWriter(aFile, Encoding.UTF8);
            string str_Header = @"//字段说明
//①序号
//②中文显示名称
//③英文网站匹配
//④被替换的字符串（旧）
//⑤替换的字符串（新）
//http://img3.fengniao.com/forum/attachpics/871/32/34806348_1024.jpg
//http://img3.fengniao.com/forum/attachpics/871/32/34806348.jpg";
            MyWriter.WriteLine(str_Header);
            for (int i = 0; i < listViewEx1.Items.Count; i++)
            {
                string str1 = this.listViewEx1.Items[i].SubItems[0].Text;
                string str2 = this.listViewEx1.Items[i].SubItems[1].Text;
                string str3 = this.listViewEx1.Items[i].SubItems[2].Text;
                string str4 = this.listViewEx1.Items[i].SubItems[3].Text;
                string str5 = this.listViewEx1.Items[i].SubItems[4].Text;

                if(str2 == "" && str3 == "" && str4 == "" && str5 == "") continue;
                string strMyData = str1 + "," + str2 + "," + str3 + "," + str4 + "," + str5;
                MyWriter.WriteLine(strMyData);

                frm.list_Rules.Add(strMyData);
                frm.comboBox_WebSiteName.Items.Add(str2);
            }
            frm.comboBox_WebSiteName.Items.Add("暂未识别");
            frm.comboBox_WebSiteName.Items.Add("--------------");
            frm.comboBox_WebSiteName.Items.Add("自定义规则");
            if (MyWriter != null)
            {
                MyWriter.Close();
            }
            aFile.Close();
        }

        private void AddItem()
        {
            int nCount = listViewEx1.Items.Count;
            ListViewItem lst = new ListViewItem();
            lst.SubItems.Add("");
            lst.SubItems.Add("");
            lst.SubItems.Add("");
            lst.SubItems.Add("");
            lst.SubItems.Add("");
            listViewEx1.Items.Add(lst);
            listViewEx1.EnsureVisible(nCount);

            SortID();
        }

        private void DeleteItem()
        {
            if (listViewEx1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in listViewEx1.SelectedItems)
                {
                    listViewEx1.Items.RemoveAt(lvi.Index);
                }
            }
            SortID();
        }

        private void SortID()
        {
            int nnCount = listViewEx1.Items.Count;
            for (int i = 0; i < nnCount; i++)
            {
                listViewEx1.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

    }
}
