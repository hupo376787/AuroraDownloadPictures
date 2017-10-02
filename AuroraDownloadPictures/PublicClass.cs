namespace AuroraDownloadPictures
{
    public class PublicClass
    {
        public enum AdType : int
        {
            None = -1,                  //无广告
            AdAd = 0,                   //广告
            WhatIsNew = 1,              //更新日志
        }

        public enum WebSiteType
        {
            http = 0,
            https = 1
        }

        public enum WebsiteName
        {
            fengniao = 0,
            fengniao_bbs = 1,
            zol = 2,
            zol_bbs = 3,
            poco = 4,
            tuchong = 5,
            unknown = 1024
        }

        public enum WebsiteNamePinyin
        {
            蜂鸟网 = 0,
            蜂鸟摄影论坛 = 1,
            中关村 = 2,
            中关村摄影论坛 = 3,
            POCO = 4,
            图虫 = 5,
            暂未识别 = 1024
        }

        public static void GetWebSiteType(string strUrl, ref int nTemp, ref string str_WebsiteNamePinyin)
        {
            nTemp = 1024;
            str_WebsiteNamePinyin = "暂未识别";
            if (strUrl.Contains("bbs.fengniao.com"))
            {
                nTemp = (int)WebsiteName.fengniao_bbs;
                str_WebsiteNamePinyin = WebsiteNamePinyin.蜂鸟摄影论坛.ToString();
            }
            else if (strUrl.Contains("fengniao.com"))
            {
                nTemp = (int)WebsiteName.fengniao;
                str_WebsiteNamePinyin = WebsiteNamePinyin.蜂鸟网.ToString();
            }
            else if (strUrl.Contains("bbs.zol.com.cn"))
            {
                nTemp = (int)WebsiteName.zol_bbs;
                str_WebsiteNamePinyin = WebsiteNamePinyin.中关村摄影论坛.ToString();
            }
            else if (strUrl.Contains("poco.cn"))
            {
                nTemp = (int)WebsiteName.poco;
                str_WebsiteNamePinyin = WebsiteNamePinyin.POCO.ToString();
            }
            else if (strUrl.Contains("tuchong.com"))
            {
                nTemp = (int)WebsiteName.tuchong;
                str_WebsiteNamePinyin = WebsiteNamePinyin.图虫.ToString();
            }
            else
            {
                nTemp = (int)WebsiteName.unknown;
                str_WebsiteNamePinyin = WebsiteNamePinyin.暂未识别.ToString();
            }
        }

    }
}
