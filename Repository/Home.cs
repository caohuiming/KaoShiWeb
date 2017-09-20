using Ipaloma.Model;
using IRepository;
using mode;
using mode.Consulting;
using model;
using model.Account;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{

    public class Home : IHome
    {
        public Myaccount Getaccunt(int id)
        {
            Myaccount myaccount = new Myaccount();
            try
            {
                string sqlDetail = string.Format(@"select * from account where id={0}", id);
                DataTable dt = null;
                DataTable dtDetail = MySqlHelper.ExecuteTable(sqlDetail);
                if (dtDetail == null || dtDetail.Rows.Count == 0)
                {
                    string sqlSingle = string.Format(@"select  * from account  LIMIT 1");
                    DataTable  dtSingle = MySqlHelper.ExecuteTable(sqlSingle);
                    if (dtSingle == null || dtSingle.Rows.Count ==0)
                    {
                        return new Myaccount();
                    }
                    else
                    {
                        dt = dtSingle;
                    }
                }
                else
                {
                    dt = dtDetail;
                }
                
                DataRow dr = dt.Rows[0];
                int currentId = Convert.ToInt32(dr["id"].ToString());
                string currentName = dr["name"] == DBNull.Value ? "" : dr["name"].ToString();
                string currentPosition = dr["position"] == DBNull.Value ? "" : dr["position"].ToString();
                string currentMembershipNo = dr["membershipNo"] == DBNull.Value ? "" : dr["membershipNo"].ToString();

                string currentLogoImg = dr["logoImg"] == DBNull.Value ? "" : dr["logoImg"].ToString();
                string currentHeadImg = dr["headImg"] == DBNull.Value ? "" : dr["headImg"].ToString();
                string currentIntroduce = dr["introduce"] == DBNull.Value ? "" : dr["introduce"].ToString();
                DateTime currentAddTime = dr["addtime"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["addtime"].ToString());
                string currentVideoaddress = dr["videoaddress"] == DBNull.Value ? "" : dr["videoaddress"].ToString();

                string currentTel = dr["tel"] == DBNull.Value ? "" : dr["tel"].ToString();
                string currentEmail = dr["email"] == DBNull.Value ? "" : dr["email"].ToString();
                string currentQQ = dr["QQ"] == DBNull.Value ? "" : dr["QQ"].ToString();
                string currentWxImg = dr["wxImg"] == DBNull.Value ? "" : dr["wxImg"].ToString();

                string currentCompany_profile_img = dr["company_profile_img"] == DBNull.Value ? "" : dr["company_profile_img"].ToString();
                string currentProduct_center_img1 = dr["product_center_img1"] == DBNull.Value ? "" : dr["product_center_img1"].ToString();
                string currentProduct_center_img2 = dr["product_center_img2"] == DBNull.Value ? "" : dr["product_center_img2"].ToString();
                string currentEnterprise_img1 = dr["enterprise_img1"] == DBNull.Value ? "" : dr["enterprise_img1"].ToString();

                string currentEnterprise_img2 = dr["enterprise_img2"] == DBNull.Value ? "" : dr["enterprise_img2"].ToString();
                string currentColumn1Name= dr["column1_name"] == DBNull.Value ? "" : dr["column1_name"].ToString();
                string currentColumn2Name = dr["column2_name"] == DBNull.Value ? "" : dr["column2_name"].ToString();
                string currentColumn3Name = dr["column3_name"] == DBNull.Value ? "" : dr["column3_name"].ToString();

                string currentColumn1Url = dr["column1_url"] == DBNull.Value ? "" : dr["column1_url"].ToString();
                string currentColumn2Url = dr["column2_url"] == DBNull.Value ? "" : dr["column2_url"].ToString();
                string currentColumn3Url = dr["column3_url"] == DBNull.Value ? "" : dr["column3_url"].ToString();
                myaccount.Id = currentId;
                myaccount.Name = currentName;
                myaccount.position = currentPosition;
                myaccount.MembershipNo = currentMembershipNo;

                myaccount.LogoImg = currentLogoImg;
                myaccount.HeadImg = currentHeadImg;
                myaccount.introduce = currentIntroduce;
                myaccount.addtime = currentAddTime;
                myaccount.Videoaddress = currentVideoaddress;

                myaccount.tel = currentTel;
                myaccount.email = currentEmail;
                myaccount.QQ = currentQQ;
                myaccount.WxImg = currentWxImg;

                myaccount.company_profile_img = currentCompany_profile_img;
                myaccount.product_center_img1 = currentProduct_center_img1;
                myaccount.product_center_img2 = currentProduct_center_img2;
                myaccount.enterprise_img1 = currentEnterprise_img1;

                myaccount.enterprise_img2 = currentEnterprise_img2;
                myaccount.column1_name = currentColumn1Name;
                myaccount.column2_name = currentColumn2Name;
                myaccount.column3_name = currentColumn3Name;

                myaccount.column1_url = currentColumn1Url;
                myaccount.column2_url = currentColumn2Url;
                myaccount.column3_url = currentColumn3Url;
                return myaccount;

                //using (var content = new DBContext())
                //{
                //    string sql = string.Format(@"select * from account where id={0}",id);
                //    var result = content.Database.SqlQuery<Myaccount>(sql).ToList();
                //    if (result.Count() == 0) {
                //         sql = string.Format(@"select  * from account  LIMIT 1");
                //         result = content.Database.SqlQuery<Myaccount>(sql).ToList();
                //    }
                //    return result.Count() > 0 ? result.First() : new Myaccount();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Myaccount> GetaccuntList(int id)
        {
            List<Myaccount> list = new List<Myaccount>();
            try
            {
                string sql = @"select  * from account";
                if (id > 0)
                {
                    sql = string.Format(@"select * from account where id={0}", id);
                }
                DataTable dt = MySqlHelper.ExecuteTable(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    Myaccount myaccount = null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        myaccount = new Myaccount();
                        int currentId = Convert.ToInt32(dr["id"].ToString());
                        string currentName = dr["name"] == DBNull.Value ? "" : dr["name"].ToString();
                        string currentPosition = dr["position"] == DBNull.Value ? "" : dr["position"].ToString();
                        string currentMembershipNo = dr["membershipNo"] == DBNull.Value ? "" : dr["membershipNo"].ToString();

                        string currentLogoImg = dr["logoImg"] == DBNull.Value ? "" : dr["logoImg"].ToString();
                        string currentHeadImg = dr["headImg"] == DBNull.Value ? "" : dr["headImg"].ToString();
                        string currentIntroduce = dr["introduce"] == DBNull.Value ? "" : dr["introduce"].ToString();
                        DateTime currentAddTime = dr["addtime"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["addtime"].ToString());
                        string currentVideoaddress = dr["videoaddress"] == DBNull.Value ? "" : dr["videoaddress"].ToString();

                        string currentTel = dr["tel"] == DBNull.Value ? "" : dr["tel"].ToString();
                        string currentEmail = dr["email"] == DBNull.Value ? "" : dr["email"].ToString();
                        string currentQQ = dr["QQ"] == DBNull.Value ? "" : dr["QQ"].ToString();
                        string currentWxImg = dr["wxImg"] == DBNull.Value ? "" : dr["wxImg"].ToString();

                        string currentCompany_profile_img = dr["company_profile_img"] == DBNull.Value ? "" : dr["company_profile_img"].ToString();
                        string currentProduct_center_img1 = dr["product_center_img1"] == DBNull.Value ? "" : dr["product_center_img1"].ToString();
                        string currentProduct_center_img2 = dr["product_center_img2"] == DBNull.Value ? "" : dr["product_center_img2"].ToString();
                        string currentEnterprise_img1 = dr["enterprise_img1"] == DBNull.Value ? "" : dr["enterprise_img1"].ToString();

                        string currentEnterprise_img2 = dr["enterprise_img2"] == DBNull.Value ? "" : dr["enterprise_img2"].ToString();
                        string currentColumn1Name = dr["column1_name"] == DBNull.Value ? "" : dr["column1_name"].ToString();
                        string currentColumn2Name = dr["column2_name"] == DBNull.Value ? "" : dr["column2_name"].ToString();
                        string currentColumn3Name = dr["column3_name"] == DBNull.Value ? "" : dr["column3_name"].ToString();

                        string currentColumn1Url = dr["column1_url"] == DBNull.Value ? "" : dr["column1_url"].ToString();
                        string currentColumn2Url = dr["column2_url"] == DBNull.Value ? "" : dr["column2_url"].ToString();
                        string currentColumn3Url = dr["column3_url"] == DBNull.Value ? "" : dr["column3_url"].ToString();
                        myaccount.Id = currentId;
                        myaccount.Name = currentName;
                        myaccount.position = currentPosition;
                        myaccount.MembershipNo = currentMembershipNo;

                        myaccount.LogoImg = currentLogoImg;
                        myaccount.HeadImg = currentHeadImg;
                        myaccount.introduce = currentIntroduce;
                        myaccount.addtime = currentAddTime;
                        myaccount.Videoaddress = currentVideoaddress;

                        myaccount.tel = currentTel;
                        myaccount.email = currentEmail;
                        myaccount.QQ = currentQQ;
                        myaccount.WxImg = currentWxImg;

                        myaccount.company_profile_img = currentCompany_profile_img;
                        myaccount.product_center_img1 = currentProduct_center_img1;
                        myaccount.product_center_img2 = currentProduct_center_img2;
                        myaccount.enterprise_img1 = currentEnterprise_img1;

                        myaccount.enterprise_img2 = currentEnterprise_img2;
                        myaccount.column1_name = currentColumn1Name;
                        myaccount.column2_name = currentColumn2Name;
                        myaccount.column3_name = currentColumn3Name;

                        myaccount.column1_url = currentColumn1Url;
                        myaccount.column2_url = currentColumn2Url;
                        myaccount.column3_url = currentColumn3Url;
                        list.Add(myaccount);
                    }
                }
                return list;

                //using (var content = new DBContext())
                //{
                //    string sql = string.Format(@"select  * from account ");
                //    if (id>0)
                //     sql = string.Format(@"select * from account where id={0}", id);
                //    var result = content.Database.SqlQuery<Myaccount>(sql).ToList();
                //     result = content.Database.SqlQuery<Myaccount>(sql).ToList();

                //    return result;
                //}
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int UPdateaccoun(Myaccount mode)
        {
            try
            {

                string sql = "";
                if (mode.Id > 0)
                {
                    sql = string.Format(@"UPDATE account SET  `name`='{0}', `position`='{1}', `MembershipNo`='{2}', `HeadImg`='{3}', `introduce`='{4}', `Videoaddress`='{5}', `tel`='{6}', `email`='{7}', `QQ`='{8}', `WxImg`='{9}'

                    ,product_center_img1='{10}',product_center_img2='{11}',enterprise_img1='{12}',enterprise_img2='{13}',company_profile_img='{14}',logoImg='{15}'
                        WHERE id='{16}'
         ", mode.Name, mode.position, mode.MembershipNo, mode.HeadImg, mode.introduce, mode.Videoaddress, mode.tel, mode.email, mode.QQ,
     mode.WxImg, mode.product_center_img1, mode.product_center_img2, mode.enterprise_img1, mode.enterprise_img2, mode.company_profile_img,mode.LogoImg, mode.Id);
                }
                else
                {
                    mode.column1_name = "企业简介";
                    mode.column2_name = "产品中心";
                    mode.column3_name = "企业咨询";
                    sql = string.Format(@"INSERT INTO  account (  `name`, `position`, `MembershipNo`, `HeadImg`, `introduce`, `Videoaddress`, `tel`, `email`, `QQ`, `WxImg`,addtime ,product_center_img1,product_center_img2,enterprise_img1,enterprise_img2,company_profile_img,column1_name,column2_name,column3_name,logoImg) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')",
                        mode.Name, mode.position, mode.MembershipNo, mode.HeadImg, mode.introduce, mode.Videoaddress, mode.tel, mode.email, mode.QQ
                        , mode.WxImg, mode.addtime, mode.product_center_img1, mode.product_center_img2, mode.enterprise_img1, mode.enterprise_img2, mode.company_profile_img,
                        mode.column1_name,mode.column2_name,mode.column3_name,mode.LogoImg);

                }
                int row= MySqlHelper.ExecuteNonQuery(sql);
                return row;
         //       using (var content = new DBContext())
         //       {
         //           string sql = "";
         //           if (mode.Id > 0)
         //           {
         //               sql = string.Format(@"UPDATE account SET  `name`='{0}', `position`='{1}', `MembershipNo`='{2}', `HeadImg`='{3}', `introduce`='{4}', `Videoaddress`='{5}', `tel`='{6}', `email`='{7}', `QQ`='{8}', `WxImg`='{9}'

         //           ,product_center_img1='{10}',product_center_img2='{11}',enterprise_img1='{12}',enterprise_img2='{13}',company_profile_img='{14}',position='{16}'
         //               WHERE id='{15}'
         //", mode.Name, mode.position, mode.MembershipNo, mode.HeadImg, mode.introduce, mode.Videoaddress, mode.tel, mode.email, mode.QQ,
         //mode.WxImg, mode.product_center_img1, mode.product_center_img2, mode.enterprise_img1, mode.enterprise_img2, mode.company_profile_img, mode.Id, mode.position);
         //           }
         //           else
         //           {
         //               sql = string.Format(@"INSERT INTO  account (  `name`, `position`, `MembershipNo`, `HeadImg`, `introduce`, `Videoaddress`, `tel`, `email`, `QQ`, `WxImg`,addtime ,product_center_img1,product_center_img2,enterprise_img1,enterprise_img2,company_profile_img,position) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')", mode.Name, mode.position, mode.MembershipNo, mode.HeadImg, mode.introduce, mode.Videoaddress, mode.tel, mode.email, mode.QQ
         //                   , mode.WxImg, mode.addtime, mode.product_center_img1, mode.product_center_img2, mode.enterprise_img1, mode.enterprise_img2, mode.company_profile_img, mode.position);

         //           }
         //           return content.Database.ExecuteSqlCommand(sql);

         //       }
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
        public int Deleteaccoun(int id)
        {
            try
            {
                string sql = string.Format(@"delete from account where id={0}", id);
                int row= MySqlHelper.ExecuteNonQuery(sql);
                return row;
                //using (var content = new DBContext())
                //{
                //    string sql = string.Format(@"delete from account where id={0}", id);

                //    return content.Database.ExecuteSqlCommand(sql);

                //}
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public int add(Consulting con)
        {
            try
            {
                string sql = string.Format(@"INSERT INTO `consulting` (`acconunt_id`,  `tel`, `remark`, `addtime`, `gender`, `name`) VALUES ('{0}', '{1}',  '{2}',  '{3}',  '{4}',  '{5}');", con.acconunt_id, con.tel, con.remark, con.addtime, con.gender, con.name);
                int row= MySqlHelper.ExecuteNonQuery(sql);
                return row;
                //using (var content = new DBContext())
                //{
                //    string sql = string.Format(@"INSERT INTO `consulting` (`acconunt_id`,  `tel`, `remark`, `addtime`, `gender`, `name`) VALUES ('{0}', '{1}',  '{2}',  '{3}',  '{4}',  '{5}');", con.acconunt_id, con.tel, con.remark, con.addtime, con.gender, con.name);
                //    int result = content.Database.ExecuteSqlCommand(sql);
                //    return result;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int UpdateColumn(Myaccount mode)
        {
            try
            {
                string sql = String.Format("update account set column1_name='{0}',column2_name='{1}',column3_name='{2}',column1_url='{3}',column2_url='{4}',column3_url='{5}' where id={6}", mode.column1_name, mode.column2_name, mode.column3_name,mode.column1_url, mode.column2_url, mode.column3_url, mode.Id);
                int row = MySqlHelper.ExecuteNonQuery(sql);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            
    }
}
