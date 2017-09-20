using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mode.ShiJuan;
using mode;
using System.Data;

namespace Repository
{
    public class ShiTi : IShiTi
    {
        public bool RegisterUser(MyUserEntity myUserEntity)
        {
            bool bOk = false;
            string sql = String.Format("insert into my_user values(null,'{0}','{1}','{2}')", myUserEntity.userName, myUserEntity.userPhone, myUserEntity.userPwd);
            int num= MySqlHelper.ExecuteNonQuery(sql);
            if (num >= 1)
            {
                bOk = true;    
            }
            return bOk;
        }
        public MyUserEntity Login(MyUserEntity myUserEntity)
        {
            MyUserEntity myUser = new MyUserEntity();
            string sql = String.Format(@"select * from  my_user 
where is_deleted=0 
and user_name='{0}' 
and user_pwd='{1}'", myUserEntity.userName, myUserEntity.userPwd);
            DataTable dtUser = MySqlHelper.ExecuteTable(sql);
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                DataRow drUser = dtUser.Rows[0];
                myUser.userId = drUser["user_id"] == DBNull.Value ? 0 : Convert.ToInt32(drUser["user_id"].ToString());
                myUser.userName = drUser["user_name"] == DBNull.Value ? string.Empty : drUser["user_name"].ToString();
                myUser.userPhone = drUser["user_phone"] == DBNull.Value ? string.Empty : drUser["user_phone"].ToString();
                myUser.userPwd = drUser["user_pwd"] == DBNull.Value ? string.Empty : drUser["user_pwd"].ToString();
            }
            else
            {
                myUser = null;
            }
            return myUser;
        }
        public List<ShiJuanEntity> GetShiJuanList()
        {
            List<ShiJuanEntity> listShiJuan = new List<ShiJuanEntity>();
            string sql =@"select * from shi_juan 
where is_deleted=0";
            DataTable dtShiJuan = MySqlHelper.ExecuteTable(sql);
            if (dtShiJuan != null && dtShiJuan.Rows.Count > 0)
            {
                foreach(DataRow drShiJuan in dtShiJuan.Rows){
                    ShiJuanEntity shiJuanEntity = new ShiJuanEntity();
                    shiJuanEntity.id = drShiJuan["id"] == DBNull.Value ? 0 : Convert.ToInt32(drShiJuan["id"].ToString());
                    shiJuanEntity.shiJuanName = drShiJuan["shi_juan_name"] == DBNull.Value ? string.Empty : drShiJuan["shi_juan_name"].ToString();
                    listShiJuan.Add(shiJuanEntity);
                }
            }
            else
            {
                listShiJuan = null;
            }
            return listShiJuan;
         }

        public List<ShiTiEntity> GetShiTiByShiJuanId(int shiJuanId)
        {
            List<ShiTiEntity> listShiTi = new List<ShiTiEntity>();
            string sql = string.Format(@"select * from shi_ti 
where is_deleted=0
and shi_juan_id={0}",shiJuanId);
            DataTable dtShiTi = MySqlHelper.ExecuteTable(sql);
            if (dtShiTi != null && dtShiTi.Rows.Count > 0)
            {
                foreach (DataRow dr in dtShiTi.Rows)
                {
                    ShiTiEntity shiTiEntity = ConvertDataRowToShiTiEntity(dr);
                    if (shiTiEntity != null)
                    {
                        listShiTi.Add(shiTiEntity);
                    }
                }
            }
            else
            {
                listShiTi = null;
            }
            return listShiTi;
        }
        public ShiTiNumEntity GetShiTiNum(int shiJuanId)
        {
            ShiTiNumEntity shiTiNumEntity = new ShiTiNumEntity();
            string sql = string.Format(@"
select count(1) rowCount,max(id) maxShiTiId,min(id) minShiTiId 
from shi_ti 
where is_deleted=0
and shi_juan_id={0}", shiJuanId);
            DataTable dtShiTiNum = MySqlHelper.ExecuteTable(sql);
            if (dtShiTiNum != null && dtShiTiNum.Rows.Count > 0)
            {
                DataRow dr = dtShiTiNum.Rows[0];
                shiTiNumEntity.rowCount=dr["rowCount"]==DBNull.Value?0:Convert.ToInt32(dr["rowCount"].ToString());
                shiTiNumEntity.maxShiTiId = dr["maxShiTiId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["maxShiTiId"].ToString());
                shiTiNumEntity.minShiTiId = dr["minShiTiId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["minShiTiId"].ToString());
            }
            else
            {
                return null;
            }
            return shiTiNumEntity;
        }
        public ShiTiEntity GetNextShiTiByShiJuanIdAndCurrentIdOld(int shiJuanId, long currentShiTiId, int daTiType)
        {
            ShiTiEntity shiTiEntity = null;
            string sql = string.Empty;
            if (daTiType == 1)//顺序
            {
                sql = string.Format(@"
select * from shi_ti 
where is_deleted=0
and shi_juan_id={0}
and id>{1}
order by id asc
limit 1
", shiJuanId, currentShiTiId);
            }else if (daTiType == 2)//随机
            {
                sql = string.Format(@"
select * from shi_ti 
where is_deleted=0
and shi_juan_id={0}
and id<>{1}
order by RAND() asc
limit 1
", shiJuanId, currentShiTiId);
            }
            DataTable dtShiTi = MySqlHelper.ExecuteTable(sql);
            if (dtShiTi != null && dtShiTi.Rows.Count > 0)
            {
                DataRow dr = dtShiTi.Rows[0];
                shiTiEntity = ConvertDataRowToShiTiEntity(dr);
            }
            return shiTiEntity;
        }
        public ShiTiEntity GetPreShiTiByShiJuanIdAndCurrentIdOld(int shiJuanId, long currentShiTiId, int daTiType)
        {
            ShiTiEntity shiTiEntity = null;
            string sql = string.Empty;
            if (daTiType == 1)
            {
                sql = string.Format(@"select * from shi_ti 
where is_deleted=0
and shi_juan_id={0}
and id>0
and id<{1}
order by id desc
limit 1
", shiJuanId, currentShiTiId);
            }else if (daTiType == 2)
            {
                sql = string.Format(@"
select * from shi_ti 
where is_deleted=0
and shi_juan_id={0}
and id={1}
limit 1
", shiJuanId, currentShiTiId);
            }
            DataTable dtShiTi = MySqlHelper.ExecuteTable(sql);
            if (dtShiTi != null && dtShiTi.Rows.Count > 0)
            {
                DataRow dr = dtShiTi.Rows[0];
                shiTiEntity = ConvertDataRowToShiTiEntity(dr);
            }
            return shiTiEntity;
        }
        public ShiTiEntity GetGoToShiTiByShiJuanIdAndCurrentIdOld(int shiJuanId, long currentShiTiId)
        {
            ShiTiEntity shiTiEntity = null;
            string sql = string.Format(@"select * from shi_ti 
where is_deleted=0
and shi_juan_id={0}
and id={1}
order by id desc
limit 1
", shiJuanId, currentShiTiId);
            DataTable dtShiTi = MySqlHelper.ExecuteTable(sql);
            if (dtShiTi != null && dtShiTi.Rows.Count > 0)
            {
                DataRow dr = dtShiTi.Rows[0];
                shiTiEntity = ConvertDataRowToShiTiEntity(dr);
            }
            return shiTiEntity;
        }
        public ShiTiEntity GetNextShiTiByShiJuanIdAndCurrentId(int shiJuanId, long currentShiTiId,int userId)
        {
            ShiTiEntity shiTiEntity = null;
            string sql = string.Format(@"select t.*,ud.da_an my_da_an
from shi_ti t
left join user_da_an ud 
on t.shi_juan_id=ud.shi_juan_id and t.id=ud.shi_ti_id and ud.is_deleted=0 and ud.user_id={2}
where t.is_deleted=0
and t.shi_juan_id={0}
and t.id>{1}
limit 1
", shiJuanId, currentShiTiId,userId);
            DataTable dtShiTi = MySqlHelper.ExecuteTable(sql);
            if (dtShiTi != null && dtShiTi.Rows.Count > 0)
            {
                DataRow dr = dtShiTi.Rows[0];
                shiTiEntity = ConvertDataRowToShiTiEntity(dr);
            }
            return shiTiEntity;
        }


        public List<ShiTiEntity> GetShiTiByCondition(int shiJuanId, string tiXing)
        {
            List<ShiTiEntity> listShiTi = new List<ShiTiEntity>();
            string sql = string.Format(@"select * from shi_ti 
where is_deleted=0
and shi_juan_id={0}
and ti_xing='{1}'", shiJuanId,tiXing);
            DataTable dtShiTi = MySqlHelper.ExecuteTable(sql);
            if (dtShiTi != null && dtShiTi.Rows.Count > 0)
            {
                foreach (DataRow dr in dtShiTi.Rows)
                {
                    ShiTiEntity shiTiEntity = ConvertDataRowToShiTiEntity(dr);
                    if (shiTiEntity != null)
                    {
                        listShiTi.Add(shiTiEntity);
                    }
                }
            }
            else
            {
                listShiTi = null;
            }
            return listShiTi;
        }

        public ShiTiEntity GetNextShiTiByByCondition(int shiJuanId, string tiXing, long currentShiTiId)
        {
            ShiTiEntity shiTiEntity = null;
            string sql = string.Format(@"select * from shi_ti 
where is_deleted=0
and shi_juan_id={0}
and ti_xing='{1}'
limit 1
", shiJuanId, tiXing);
            DataTable dtShiTi = MySqlHelper.ExecuteTable(sql);
            if (dtShiTi != null && dtShiTi.Rows.Count > 0)
            {
                DataRow dr = dtShiTi.Rows[0];
                shiTiEntity = ConvertDataRowToShiTiEntity(dr);
            }
            return shiTiEntity;
        }

        public bool SaveUserDaAn(UserDaAnEntity userDaAnEntity)
        {
            bool bOk = false;
            string sql = string.Format(@"insert into user_da_an (user_id,shi_juan_id,shi_ti_id,da_an)
values({0},{1},{2},'{3}')", userDaAnEntity.userId, userDaAnEntity.shiJuanId, userDaAnEntity.shiTiId, userDaAnEntity.daAn);
            int num = MySqlHelper.ExecuteNonQuery(sql);
            if (num >= 1)
            {
                bOk = true;
            }
            return bOk;
        }

       private ShiTiEntity ConvertDataRowToShiTiEntity(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            ShiTiEntity shiTiEntity = new ShiTiEntity();
            long id = 0;
            int shi_juan_id = 0;
            int shi_yong_deng_ji = 0;
            string nan_du = string.Empty;
            int fen_shu = 0;
            int shi_jian = 0;
            string bian_hao = string.Empty;
            string ti_xing = string.Empty;
            string zheng_wen = string.Empty;
            string xuan_xiang = string.Empty;
            string da_an = string.Empty;
            string zbcsxx = string.Empty;
            string csmsjj = string.Empty;
            string ybcsnr = string.Empty;
            string da_an_jie_xi = string.Empty;
            string ping_fen_biao_zhun = string.Empty;
            string chu_chu = string.Empty;
            string chu_ti_ren = string.Empty;
            string bei_zhu = string.Empty;
            string tiao_mu = string.Empty;
            string fen_ce_ming_cheng = string.Empty;
            string tiao_kuan = string.Empty;
            string zhuan_ye = string.Empty;
            string my_da_an = string.Empty;
            id = dr["id"] == DBNull.Value ? 0 : Convert.ToInt64(dr["id"].ToString());
            shi_juan_id = dr["shi_juan_id"] == DBNull.Value ? 0 : Convert.ToInt32(dr["shi_juan_id"].ToString());
            shi_yong_deng_ji = dr["shi_yong_deng_ji"] == DBNull.Value ? 0 : Convert.ToInt32(dr["shi_yong_deng_ji"].ToString());
            nan_du = dr["nan_du"] == DBNull.Value ? "" : dr["nan_du"].ToString();
            fen_shu = dr["fen_shu"] == DBNull.Value ? 0 : Convert.ToInt32(dr["fen_shu"].ToString());
            shi_jian = dr["shi_jian"] == DBNull.Value ? 0 : Convert.ToInt32(dr["shi_jian"].ToString());
            bian_hao = dr["bian_hao"] == DBNull.Value ? "" : dr["bian_hao"].ToString();
            ti_xing = dr["ti_xing"] == DBNull.Value ? "" : dr["ti_xing"].ToString();
            zheng_wen = dr["zheng_wen"] == DBNull.Value ? "" : dr["zheng_wen"].ToString();
            xuan_xiang = dr["xuan_xiang"] == DBNull.Value ? "" : dr["xuan_xiang"].ToString();
            da_an = dr["da_an"] == DBNull.Value ? "" : dr["da_an"].ToString();
            zbcsxx = dr["zbcsxx"] == DBNull.Value ? "" : dr["zbcsxx"].ToString();
            csmsjj = dr["csmsjj"] == DBNull.Value ? "" : dr["csmsjj"].ToString();
            ybcsnr = dr["ybcsnr"] == DBNull.Value ? "" : dr["ybcsnr"].ToString();
            da_an_jie_xi = dr["da_an_jie_xi"] == DBNull.Value ? "" : dr["da_an_jie_xi"].ToString();
            ping_fen_biao_zhun = dr["ping_fen_biao_zhun"] == DBNull.Value ? "" : dr["ping_fen_biao_zhun"].ToString();
            chu_chu = dr["chu_chu"] == DBNull.Value ? "" : dr["chu_chu"].ToString();
            chu_ti_ren = dr["chu_ti_ren"] == DBNull.Value ? "" : dr["chu_ti_ren"].ToString();
            bei_zhu = dr["bei_zhu"] == DBNull.Value ? "" : dr["bei_zhu"].ToString();
            tiao_mu = dr["tiao_mu"] == DBNull.Value ? "" : dr["tiao_mu"].ToString();
            fen_ce_ming_cheng = dr["fen_ce_ming_cheng"] == DBNull.Value ? "" : dr["fen_ce_ming_cheng"].ToString();
            tiao_kuan = dr["tiao_kuan"] == DBNull.Value ? "" : dr["tiao_kuan"].ToString();
            zhuan_ye = dr["zhuan_ye"] == DBNull.Value ? "" : dr["zhuan_ye"].ToString();
            //my_da_an = dr["my_da_an"] == DBNull.Value ? "" : dr["my_da_an"].ToString();
            shiTiEntity.id = id;
            shiTiEntity.shiJuanId = shi_juan_id;

            shiTiEntity.shiYongDengJi = shi_yong_deng_ji;
            shiTiEntity.nanDu = nan_du;
            shiTiEntity.fenShu = fen_shu;
            shiTiEntity.shiJian = shi_jian;

            shiTiEntity.bianHao = bian_hao;
            shiTiEntity.tiXing = ti_xing;
            shiTiEntity.zhengWen = zheng_wen;
            shiTiEntity.xuanXiang = xuan_xiang;

            shiTiEntity.daAn = da_an;
            shiTiEntity.zbcsxx = zbcsxx;
            shiTiEntity.csmsjj = csmsjj;
            shiTiEntity.ybcsnr = ybcsnr;

            shiTiEntity.daAnJieXi = da_an_jie_xi;
            shiTiEntity.pingFenBiaoZhun = ping_fen_biao_zhun;
            shiTiEntity.chuChu = chu_chu;
            shiTiEntity.chuTiRen = chu_ti_ren;

            shiTiEntity.beiZhu = bei_zhu;
            shiTiEntity.tiaoMu = tiao_mu;
            shiTiEntity.fenCeMingCheng = fen_ce_ming_cheng;
            shiTiEntity.tiaoKuan = tiao_kuan;

            shiTiEntity.zhuanYe = zhuan_ye;
            //shiTiEntity.myDaAn = my_da_an;

            return shiTiEntity;
        }

      
    }
}
