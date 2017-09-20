using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Account
{
    public class Myaccount
    {
 
        public int Id { get; set; }
        //名字
        public string Name { get; set; }
        //logo图片
        public string LogoImg { get; set; }
        //头像
        public string HeadImg { get; set; }
        //z职位
        public string position { get; set; }
        //会员编号
        public string MembershipNo { get; set; }
        //介绍
        public string introduce { get; set; }
        //添加时间
        public DateTime addtime { get; set; }
        //视频地址
        public string Videoaddress { get; set; }
        //手机号
        public string tel { get; set; }
        //邮箱
        public string email { get; set; }
        //qq
        public string QQ { get; set; }
        //微信图片地址
        public string WxImg { get; set; } 
        public string product_center_img1 { get; set; }       

        public string product_center_img2 { get; set; }
        public string enterprise_img1 { get; set; }
        public string enterprise_img2 { get; set; }
        public string company_profile_img { get; set; }
        //栏目1名称
        public string column1_name { get; set; }
        //栏目2名称
        public string column2_name { get; set; }
        //栏目3名称
        public string column3_name { get; set; }


        //栏目1url
        public string column1_url { get; set; }
        //栏目2url
        public string column2_url { get; set; }
        //栏目3url
        public string column3_url { get; set; }


    }
}
