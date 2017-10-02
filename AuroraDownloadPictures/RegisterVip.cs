using System;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace AuroraDownloadPictures
{
    //加密密码
    //商业版加密密码ilovetangwei               203
    //学习版加密密码DateTime.Now.Date.ToString("yyyy-MM-dd") + "hupo"              101


    public partial class RegisterVip : Form
    {
        //此版本试用Aurora注册机注册时，永久VIP选择商业版， 30天VIP选择学生版。
        private string str_Serial_Temp = "";

        public RegisterVip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_Key.Text == "")
                return;
            if (checkBox1.Checked == true)
            {
                if (transform(str_Serial_Temp, "ilovetangwei") == textBox_Key.Text) //判断转换后的加密串 == 输入的注册码？
                {
                    RegistryHelper rh = new RegistryHelper();
                    rh.SetRegistryData(Registry.CurrentUser, "SOFTWARE\\Aurora\\AuroraDownloadPictures\\", "ValidDays", "9999");
                    rh.SetRegistryData(Registry.CurrentUser, "SOFTWARE\\Aurora\\AuroraDownloadPictures\\", "RegDate", DateTime.Now.ToString("yyyy-MM-dd"));
                    MessageBox.Show("注册成功.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注册码错误");
                    return;
                }
            }
            else
            {
                if (transform(str_Serial_Temp, DateTime.Now.Date.ToString("yyyy-MM-dd") + "hupo") == textBox_Key.Text) //判断转换后的加密串 == 输入的注册码？
                {
                    RegistryHelper rh = new RegistryHelper();
                    rh.SetRegistryData(Registry.CurrentUser, "SOFTWARE\\Aurora\\AuroraDownloadPictures\\", "ValidDays", "31");
                    rh.SetRegistryData(Registry.CurrentUser, "SOFTWARE\\Aurora\\AuroraDownloadPictures\\", "RegDate", DateTime.Now.ToString("yyyy-MM-dd"));
                    MessageBox.Show("注册成功.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注册码错误");
                    return;
                }
            }
        }

        private void RegisterVip_Load(object sender, EventArgs e)
        {
            textBox_Request.Text = CreateSNCode();
            checkBox1.Checked = true;
            checkBox1.Checked = false;
            
        }

        //获得CPU的序列号
        public string getCpu()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }

        //取得设备硬盘的卷标号
        public string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        //生成机器码
        public string CreateSNCode()
        {
            string temp = getCpu() + GetDiskVolumeSerialNumber();//获得24位Cpu和硬盘序列号
            string[] strid = new string[24];//
            for (int i = 0; i < 24; i++)//把字符赋给数组
            {
                strid[i] = temp.Substring(i, 1);
            }
            temp = "";
            //Random rdid = new Random();
            for (int i = 0; i < 24; i++)//从数组随机抽取24个字符组成新的字符生成机器三
            {
                //temp += strid[rdid.Next(0, 24)];
                temp += strid[i + 3 >= 24 ? 0 : i + 3];
            }
            return GetMd5(temp);
        }

        public string GetMd5(object text)
        {
            string path = text.ToString();

            MD5CryptoServiceProvider MD5Pro = new MD5CryptoServiceProvider();
            Byte[] buffer = Encoding.GetEncoding("utf-8").GetBytes(text.ToString());
            Byte[] byteResult = MD5Pro.ComputeHash(buffer);

            string md5result = BitConverter.ToString(byteResult).Replace("-", "");
            return md5result;
        }

        //加密数据
        private string EnText(string Text, string sKey)
        {
            StringBuilder ret = new StringBuilder();
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray;
                inputByteArray = Encoding.Default.GetBytes(Text);
                //通过两次哈希密码设置对称算法的初始化向量   
                des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile
                (System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8), "sha1").Substring(0, 8));
                //通过两次哈希密码设置算法的机密密钥   
                des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile
                (System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8), "md5").Substring(0, 8));
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                return ret.ToString();
            }
            catch
            {
                return "";
            }
        }

        //解密数据
        private string DeText(string Text, string sKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();   //定义DES加密对象   
                int len;
                len = Text.Length / 2;
                byte[] inputByteArray = new byte[len];
                int x, i;
                for (x = 0; x < len; x++)
                {
                    i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                    inputByteArray[x] = (byte)i;
                }
                //通过两次哈希密码设置对称算法的初始化向量   
                des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile
                (System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8), "sha1").Substring(0, 8));
                //通过两次哈希密码设置算法的机密密钥   
                des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile
                (System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8), "md5").Substring(0, 8));
                System.IO.MemoryStream ms = new System.IO.MemoryStream();//定义内存流
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);//定义加密流
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Encoding.Default.GetString(ms.ToArray());
            }
            catch
            {
                return "";
            }
        }

        //将加密的字符串转换为注册码形式
        public string transform(string input, string skey)
        {
            string transactSn = string.Empty;
            if (input == "")
            {
                return transactSn;
            }
            string initSn = string.Empty;
            try
            {
                initSn = this.EnText(this.EnText(input, skey), skey).ToString();
                transactSn = initSn.Substring(0, 5) + "-" + initSn.Substring(5, 5) +
                "-" + initSn.Substring(10, 5) + "-" + initSn.Substring(15, 5) +
                "-" + initSn.Substring(20, 5);
                return transactSn;
            }
            catch
            {
                return transactSn;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)              //首先计算出加密串
                str_Serial_Temp = EnText(textBox_Request.Text, DateTime.Now.Date.ToString("yyyy-MM-dd") + "hupo");
            else
                str_Serial_Temp = EnText(textBox_Request.Text, "ilovetangwei");
        }
    }
}
