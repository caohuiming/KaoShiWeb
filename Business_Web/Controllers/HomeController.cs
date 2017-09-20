using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IRepository;
using Repository;
using mode.Consulting;
using Ipaloma.Model;
using model.Account;
using Ipaloma.API.Controllers;
using mode.ShiJuan;
using System.Web;
using Business_Web.Helper;
using Microsoft.AspNetCore.Http;

namespace Business_Web.Controllers
{
    public class HomeController : BaseController
    {
      
        IHome home = new Home();
        public IActionResult Index()
        {
            IShiTi shiTi = new ShiTi();
            List<ShiJuanEntity> listShiJuan = shiTi.GetShiJuanList();
            
            return View("ShiJuanList",listShiJuan);
        }
        public IActionResult DaTiType(int shiJuanId,string shiJuanName)
        {
            ViewBag.ShiJuanId = shiJuanId;
            ViewBag.ShiJuanName = shiJuanName;
            return View();
        }
        #region 顺序练习
        public IActionResult ShiTiShunXuNext(int shiJuanId, string shiJuanName, long shiTiId,int daTiType)
        {
            IShiTi shiTi = new ShiTi();
            ShiTiNumEntity shiTiNumEntity = shiTi.GetShiTiNum(shiJuanId);
            ShiTiEntity shiTiEntity = shiTi.GetNextShiTiByShiJuanIdAndCurrentIdOld(shiJuanId, shiTiId, daTiType);
            ViewBag.ShiTi = shiTiEntity;
            ViewBag.shiJuanId = shiJuanId;
            ViewBag.shiJuanName = shiJuanName;
            string myDaAn = string.Empty;
            if (this.ControllerContext.HttpContext.Request.Cookies.ContainsKey("DaTi"))
            {
                string strCookie = this.ControllerContext.HttpContext.Request.Cookies["DaTi"];
                List<DaTiCookieEntity> listDaTiCookie = JsonHelper.DeserializeJsonToList<DaTiCookieEntity>(strCookie);
                List<DaTiCookieEntity> listDaTiCookieExist = listDaTiCookie.Where(i => i.daTiType == daTiType && i.shiJuanId == shiJuanId && i.shiTiId == shiTiEntity.id).ToList();
                if (listDaTiCookieExist != null && listDaTiCookieExist.Count > 0)
                {
                    myDaAn = listDaTiCookieExist[0].myDaAn;
                }
            }
            ViewBag.myDaAn = myDaAn;
            ViewBag.shiTiNumEntity = shiTiNumEntity;
            ViewBag.daTiType = daTiType;
            string viewName = "ShiTiShunXu";
            if (shiTiEntity.tiXing == "单选题")
            {
                viewName = "ShiTiShunXu_DanXuan";
            }
            else if (shiTiEntity.tiXing == "多选题")
            {
                viewName = "ShiTiShunXu_DuoXuan";
            }
            else if (shiTiEntity.tiXing == "判断题")
            {
                viewName = "ShiTiShunXu_PanDuan";
            }
            else if (shiTiEntity.tiXing == "简答题")
            {
                viewName = "ShiTiShunXu_JianDa";
            }
            else
            {
                viewName = "ShiTiShunXu";
            }
            //shiTiEntity.xuanXiang=shiTiEntity.xuanXiang.Replace(" b","<br/>b");
            //shiTiEntity.xuanXiang = shiTiEntity.xuanXiang.Replace(" B", "<br/>B");
            //shiTiEntity.xuanXiang = shiTiEntity.xuanXiang.Replace(" c", "<br/>c");
            //shiTiEntity.xuanXiang = shiTiEntity.xuanXiang.Replace(" C", "<br/>C");
            //shiTiEntity.xuanXiang = shiTiEntity.xuanXiang.Replace(" d", "<br/>d");
            //shiTiEntity.xuanXiang = shiTiEntity.xuanXiang.Replace(" D", "<br/>D");
            return View(viewName);
        }
        public IActionResult ShiTiShunXuPre(int shiJuanId,string shiJuanName,long shiTiId, int daTiType)
        {
            IShiTi shiTi = new ShiTi();
            ShiTiNumEntity shiTiNumEntity = shiTi.GetShiTiNum(shiJuanId);
            ShiTiEntity shiTiEntity =shiTi.GetPreShiTiByShiJuanIdAndCurrentIdOld(shiJuanId,shiTiId, daTiType);
            ViewBag.ShiTi = shiTiEntity;
            ViewBag.shiJuanId = shiJuanId;
            ViewBag.shiJuanName = shiJuanName;
            string myDaAn = string.Empty;
            if (this.ControllerContext.HttpContext.Request.Cookies.ContainsKey("DaTi"))
            {
                string strCookie = this.ControllerContext.HttpContext.Request.Cookies["DaTi"];
                List<DaTiCookieEntity> listDaTiCookie = JsonHelper.DeserializeJsonToList<DaTiCookieEntity>(strCookie);
                List<DaTiCookieEntity> listDaTiCookieExist = listDaTiCookie.Where(i => i.daTiType == daTiType && i.shiJuanId == shiJuanId && i.shiTiId == shiTiEntity.id).ToList();
                if (listDaTiCookieExist != null && listDaTiCookieExist.Count>0)
                {
                    myDaAn = listDaTiCookieExist[0].myDaAn;
                }
            }
            ViewBag.myDaAn = myDaAn;
            ViewBag.shiTiNumEntity = shiTiNumEntity;
            ViewBag.daTiType = daTiType;
            string viewName = "ShiTiShunXu";
            if (shiTiEntity.tiXing == "单选题")
            {
                viewName = "ShiTiShunXu_DanXuan";
            }
            else if (shiTiEntity.tiXing == "多选题")
            {
                viewName = "ShiTiShunXu_DuoXuan";
            }
            else if (shiTiEntity.tiXing == "判断题")
            {
                viewName = "ShiTiShunXu_PanDuan";
            }
            else if (shiTiEntity.tiXing == "简答题")
            {
                viewName = "ShiTiShunXu_JianDa";
            }
            else
            {
                viewName = "ShiTiShunXu";
            }
            return View(viewName);
        }
        public IActionResult ShiTiShunXuGoTo(int shiJuanId, string shiJuanName, long goToShiTiId,int daTiType)
        {
            IShiTi shiTi = new ShiTi();
            ShiTiNumEntity shiTiNumEntity = shiTi.GetShiTiNum(shiJuanId);
            ShiTiEntity shiTiEntity = shiTi.GetGoToShiTiByShiJuanIdAndCurrentIdOld(shiJuanId, goToShiTiId);
            ViewBag.ShiTi = shiTiEntity;
            ViewBag.shiJuanId = shiJuanId;
            ViewBag.shiJuanName = shiJuanName;
            string myDaAn = string.Empty;
            if (this.ControllerContext.HttpContext.Request.Cookies.ContainsKey("DaTi"))
            {
                string strCookie = this.ControllerContext.HttpContext.Request.Cookies["DaTi"];
                List<DaTiCookieEntity> listDaTiCookie = JsonHelper.DeserializeJsonToList<DaTiCookieEntity>(strCookie);
                List<DaTiCookieEntity> listDaTiCookieExist = listDaTiCookie.Where(i => i.daTiType == daTiType && i.shiJuanId == shiJuanId && i.shiTiId == shiTiEntity.id).ToList();
                if (listDaTiCookieExist != null && listDaTiCookieExist.Count > 0)
                {
                    myDaAn = listDaTiCookieExist[0].myDaAn;
                }
            }
            ViewBag.myDaAn = myDaAn;
            ViewBag.shiTiNumEntity = shiTiNumEntity;
            ViewBag.daTiType = daTiType;
            string viewName = "ShiTiShunXu";
            if (shiTiEntity.tiXing == "单选题")
            {
                viewName = "ShiTiShunXu_DanXuan";
            }
            else if (shiTiEntity.tiXing == "多选题")
            {
                viewName = "ShiTiShunXu_DuoXuan";
            }
            else if (shiTiEntity.tiXing == "判断题")
            {
                viewName = "ShiTiShunXu_PanDuan";
            }
            else if (shiTiEntity.tiXing == "简答题")
            {
                viewName = "ShiTiShunXu_JianDa";
            }
            else
            {
                viewName = "ShiTiShunXu";
            }
            return View(viewName);
        }
        #endregion 顺序练习

        #region 随机练习
        public IActionResult ShiTiSuiJiNext(int shiJuanId, string shiJuanName, long shiTiId, int daTiType)
        {
            IShiTi shiTi = new ShiTi();
            ShiTiNumEntity shiTiNumEntity = shiTi.GetShiTiNum(shiJuanId);
            ShiTiEntity shiTiEntity = shiTi.GetNextShiTiByShiJuanIdAndCurrentIdOld(shiJuanId, shiTiId,daTiType);
            ViewBag.ShiTi = shiTiEntity;
            ViewBag.shiJuanId = shiJuanId;
            ViewBag.shiJuanName = shiJuanName;
            string myDaAn = string.Empty;
            string doShiTiIdsString = string.Empty;//已答试题编号"1,2"
            if (this.ControllerContext.HttpContext.Request.Cookies.ContainsKey("DaTi"))
            {
                string strCookie = this.ControllerContext.HttpContext.Request.Cookies["DaTi"];
                List<DaTiCookieEntity> listDaTiCookie = JsonHelper.DeserializeJsonToList<DaTiCookieEntity>(strCookie);
                List<DaTiCookieEntity> listDaTiCookieExistThisType = listDaTiCookie.Where(i => i.daTiType == daTiType && i.shiJuanId == shiJuanId).ToList();
                if (listDaTiCookieExistThisType != null && listDaTiCookieExistThisType.Count > 0)
                {
                    foreach(DaTiCookieEntity daTi in listDaTiCookieExistThisType)
                    {
                        doShiTiIdsString += daTi.shiTiId.ToString()+",";
                    }
                }
                List<DaTiCookieEntity> listDaTiCookieExist = listDaTiCookie.Where(i => i.daTiType == daTiType && i.shiJuanId == shiJuanId && i.shiTiId==shiTiEntity.id).ToList();
                if (listDaTiCookieExist != null && listDaTiCookieExist.Count > 0)
                {
                    myDaAn = listDaTiCookieExist[0].myDaAn;
                }
            }
            if (doShiTiIdsString.Length > 0)
            {
                doShiTiIdsString = doShiTiIdsString.Substring(0, doShiTiIdsString.Length - 1);
            }

            ViewBag.myDaAn = myDaAn;
            ViewBag.shiTiNumEntity = shiTiNumEntity;
            ViewBag.daTiType = daTiType;
            ViewBag.doShiTiIdsString = doShiTiIdsString;
            string viewName = "ShiTiSuiJi";
            if (shiTiEntity.tiXing == "单选题")
            {
                viewName = "ShiTiSuiJi_DanXuan";
            }
            else if (shiTiEntity.tiXing == "多选题")
            {
                viewName = "ShiTiSuiJi_DuoXuan";
            }
            else if (shiTiEntity.tiXing == "判断题")
            {
                viewName = "ShiTiSuiJi_PanDuan";
            }
            else if (shiTiEntity.tiXing == "简答题")
            {
                viewName = "ShiTiSuiJi_JianDa";
            }
            else
            {
                viewName = "ShiTiSuiJi";
            }
            return View(viewName);
        }
        public IActionResult ShiTiSuiJiPre(int shiJuanId, string shiJuanName, long shiTiId, int daTiType)
        {
            IShiTi shiTi = new ShiTi();
            ShiTiNumEntity shiTiNumEntity = shiTi.GetShiTiNum(shiJuanId);
            ShiTiEntity shiTiEntity = shiTi.GetPreShiTiByShiJuanIdAndCurrentIdOld(shiJuanId, shiTiId, daTiType);
            ViewBag.ShiTi = shiTiEntity;
            ViewBag.shiJuanId = shiJuanId;
            ViewBag.shiJuanName = shiJuanName;
            string myDaAn = string.Empty;
            string doShiTiIdsString = string.Empty;//已答试题编号"1,2"
            if (this.ControllerContext.HttpContext.Request.Cookies.ContainsKey("DaTi"))
            {
                string strCookie = this.ControllerContext.HttpContext.Request.Cookies["DaTi"];
                List<DaTiCookieEntity> listDaTiCookie = JsonHelper.DeserializeJsonToList<DaTiCookieEntity>(strCookie);
                List<DaTiCookieEntity> listDaTiCookieExistThisType = listDaTiCookie.Where(i => i.daTiType == daTiType && i.shiJuanId == shiJuanId).ToList();
                if (listDaTiCookieExistThisType != null && listDaTiCookieExistThisType.Count > 0)
                {
                    foreach (DaTiCookieEntity daTi in listDaTiCookieExistThisType)
                    {
                        doShiTiIdsString += daTi.shiTiId.ToString() + ",";
                    }
                }
                List<DaTiCookieEntity> listDaTiCookieExist = listDaTiCookie.Where(i => i.daTiType == daTiType && i.shiJuanId == shiJuanId && i.shiTiId == shiTiEntity.id).ToList();
                if (listDaTiCookieExist != null && listDaTiCookieExist.Count > 0)
                {
                    myDaAn = listDaTiCookieExist[0].myDaAn;
                }
            }
            if (doShiTiIdsString.Length > 0)
            {
                doShiTiIdsString = doShiTiIdsString.Substring(0, doShiTiIdsString.Length - 1);
            }
            ViewBag.myDaAn = myDaAn;
            ViewBag.shiTiNumEntity = shiTiNumEntity;
            ViewBag.daTiType = daTiType;
            ViewBag.doShiTiIdsString = doShiTiIdsString;
            string viewName = "ShiTiSuiJi";
            if (shiTiEntity.tiXing == "单选题")
            {
                viewName = "ShiTiSuiJi_DanXuan";
            }
            else if (shiTiEntity.tiXing == "多选题")
            {
                viewName = "ShiTiSuiJi_DuoXuan";
            }
            else if (shiTiEntity.tiXing == "判断题")
            {
                viewName = "ShiTiSuiJi_PanDuan";
            }
            else if (shiTiEntity.tiXing == "简答题")
            {
                viewName = "ShiTiSuiJi_JianDa";
            }
            else
            {
                viewName = "ShiTiSuiJi";
            }
            return View(viewName);
        }
        public IActionResult ShiTiSuiJiGoTo(int shiJuanId, string shiJuanName, long goToShiTiId, int daTiType)
        {
            IShiTi shiTi = new ShiTi();
            ShiTiNumEntity shiTiNumEntity = shiTi.GetShiTiNum(shiJuanId);
            ShiTiEntity shiTiEntity = shiTi.GetGoToShiTiByShiJuanIdAndCurrentIdOld(shiJuanId, goToShiTiId);
            ViewBag.ShiTi = shiTiEntity;
            ViewBag.shiJuanId = shiJuanId;
            ViewBag.shiJuanName = shiJuanName;
            string myDaAn = string.Empty;
            string doShiTiIdsString = string.Empty;//已答试题编号"1,2"
            if (this.ControllerContext.HttpContext.Request.Cookies.ContainsKey("DaTi"))
            {
                string strCookie = this.ControllerContext.HttpContext.Request.Cookies["DaTi"];
                List<DaTiCookieEntity> listDaTiCookie = JsonHelper.DeserializeJsonToList<DaTiCookieEntity>(strCookie);
                List<DaTiCookieEntity> listDaTiCookieExistThisType = listDaTiCookie.Where(i => i.daTiType == daTiType && i.shiJuanId == shiJuanId).ToList();
                if (listDaTiCookieExistThisType != null && listDaTiCookieExistThisType.Count > 0)
                {
                    foreach (DaTiCookieEntity daTi in listDaTiCookieExistThisType)
                    {
                        doShiTiIdsString += daTi.shiTiId.ToString() + ",";
                    }
                }
                List<DaTiCookieEntity> listDaTiCookieExist = listDaTiCookie.Where(i => i.daTiType == daTiType && i.shiJuanId == shiJuanId && i.shiTiId == shiTiEntity.id).ToList();
                if (listDaTiCookieExist != null && listDaTiCookieExist.Count > 0)
                {
                    myDaAn = listDaTiCookieExist[0].myDaAn;
                }
            }
            if (doShiTiIdsString.Length > 0)
            {
                doShiTiIdsString = doShiTiIdsString.Substring(0, doShiTiIdsString.Length - 1);
            }
            ViewBag.myDaAn = myDaAn;
            ViewBag.shiTiNumEntity = shiTiNumEntity;
            ViewBag.daTiType = daTiType;
            ViewBag.doShiTiIdsString = doShiTiIdsString;
            string viewName = "ShiTiSuiJi";
            if (shiTiEntity.tiXing == "单选题")
            {
                viewName = "ShiTiSuiJi_DanXuan";
            }
            else if (shiTiEntity.tiXing == "多选题")
            {
                viewName = "ShiTiSuiJi_DuoXuan";
            }
            else if (shiTiEntity.tiXing == "判断题")
            {
                viewName = "ShiTiSuiJi_PanDuan";
            }
            else if (shiTiEntity.tiXing == "简答题")
            {
                viewName = "ShiTiSuiJi_JianDa";
            }
            else
            {
                viewName = "ShiTiSuiJi";
            }
            return View(viewName);
        }
        #endregion 随机练习
        public IActionResult DaTiJieGuo(int shiJuanId, string shiJuanName,int daTiType)
        {
            int nAllNum = 0;
            int nRightNum = 0;
            string strDaTiTypeName = string.Empty;
            switch (daTiType)
            {
                case 1: strDaTiTypeName = "顺序练习";break;
                case 2: strDaTiTypeName = "随机练习"; break;
                case 3: strDaTiTypeName = "模拟考试"; break;
                case 4: strDaTiTypeName = "我的错题"; break;
                default : strDaTiTypeName = string.Empty;break;
            }
            List<long> wrongShiTiIds = new List<long>();
            ResultEntity resultEntity = new ResultEntity();
            if (this.ControllerContext.HttpContext.Request.Cookies.ContainsKey("DaTi"))
            {
                string strCookie = this.ControllerContext.HttpContext.Request.Cookies["DaTi"];
                List<DaTiCookieEntity> listDaTiCookie = JsonHelper.DeserializeJsonToList<DaTiCookieEntity>(strCookie);
                List<DaTiCookieEntity> listDaTiCookieExist = listDaTiCookie.Where(i => i.daTiType == daTiType && i.shiJuanId == shiJuanId).ToList();
                if (listDaTiCookieExist != null && listDaTiCookieExist.Count > 0)
                {
                    foreach(DaTiCookieEntity daTi in listDaTiCookieExist)
                    {
                        nAllNum++;
                        if (daTi.myDaAn == daTi.daAn)
                        {
                            nRightNum++;
                        }
                        else
                        {
                            wrongShiTiIds.Add(daTi.shiTiId);
                        }
                    }
                }
            }
            resultEntity.shiJuanId = shiJuanId;
            resultEntity.shiJuanName = shiJuanName;
            resultEntity.daTiType =strDaTiTypeName;
            resultEntity.allNum = nAllNum;
            resultEntity.rightNum = nRightNum;
            resultEntity.wrongShiTiIds = wrongShiTiIds;
            
            ViewBag.daTiType = daTiType;
            ViewBag.daTiTypeName = strDaTiTypeName;
            return View(resultEntity);
        }
        public string ClearCookie(int shiJuanId, int daTiType)
        {
            try
            {
                if (this.ControllerContext.HttpContext.Request.Cookies.ContainsKey("DaTi"))
                {
                    string strCookie = this.ControllerContext.HttpContext.Request.Cookies["DaTi"];
                    List<DaTiCookieEntity> listDaTiCookie = JsonHelper.DeserializeJsonToList<DaTiCookieEntity>(strCookie);
                    List<DaTiCookieEntity> listDaTiCookieExist = listDaTiCookie.Where(i => i.daTiType == daTiType && i.shiJuanId == shiJuanId).ToList();
                    if (listDaTiCookieExist != null && listDaTiCookieExist.Count > 0)
                    {
                        foreach(DaTiCookieEntity daTi in listDaTiCookieExist)
                        {
                            listDaTiCookie.Remove(daTi);
                        }
                    }
                    String strCookieNew = JsonHelper.SerializeObject(listDaTiCookie);

                    Response.Cookies.Append("DaTi", strCookieNew, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(1) });
                    return true.ToString();
                }
                else
                {
                    return true.ToString();
                }
            }
            catch
            {
                return false.ToString();
            }
        }
        public string IsShiTiExist(int shiJuanId, long goToShiTiId)
        {
            try
            {
                IShiTi shiTi = new ShiTi();
                ShiTiEntity shiTiEntity = shiTi.GetGoToShiTiByShiJuanIdAndCurrentIdOld(shiJuanId, goToShiTiId);
                if (shiTiEntity == null)
                {
                    return false.ToString();
                }
                else
                {
                    return true.ToString();
                }
            }
            catch 
            {
                return false.ToString();
            }
        }
        public string SaveDaAn(int shiJuanId,long shiTiId,string daAn,string myDaAn,int daTiType)
        {
            try
            {
                List<DaTiCookieEntity> listDaTiCookie = null;
                string strCookie = string.Empty;
                if (!this.ControllerContext.HttpContext.Request.Cookies.ContainsKey("DaTi"))
                {
                    listDaTiCookie = new List<DaTiCookieEntity>();
                    DaTiCookieEntity daTiCookieEntity = new DaTiCookieEntity();
                    daTiCookieEntity.daTiType = daTiType;//答题类型
                    daTiCookieEntity.shiJuanId = shiJuanId;
                    daTiCookieEntity.shiTiId = shiTiId;
                    daTiCookieEntity.myDaAn = myDaAn;
                    daTiCookieEntity.daAn = daAn;
                    listDaTiCookie.Add(daTiCookieEntity);
                }
                else
                {
                    strCookie = this.ControllerContext.HttpContext.Request.Cookies["DaTi"];
                    listDaTiCookie = JsonHelper.DeserializeJsonToList<DaTiCookieEntity>(strCookie);
                    List<DaTiCookieEntity> listDaTiCookieExist = listDaTiCookie.Where(i => i.daTiType == daTiType && i.shiJuanId == shiJuanId && i.shiTiId == shiTiId).ToList();
                    if (listDaTiCookieExist != null && listDaTiCookieExist.Count > 0)
                    {
                        if (listDaTiCookieExist[0].myDaAn == myDaAn)
                        {
                            return true.ToString();
                        }
                        else
                        {
                            listDaTiCookieExist[0].myDaAn = myDaAn;
                            listDaTiCookieExist[0].daAn = daAn;
                        }
                    }
                    else
                    {
                        DaTiCookieEntity daTiCookieEntity = new DaTiCookieEntity();
                        daTiCookieEntity.daTiType = daTiType;
                        daTiCookieEntity.shiJuanId = shiJuanId;
                        daTiCookieEntity.shiTiId = shiTiId;
                        daTiCookieEntity.myDaAn = myDaAn;
                        daTiCookieEntity.daAn = daAn;
                        listDaTiCookie.Add(daTiCookieEntity);
                    }
                }
                String strCookieNew = JsonHelper.SerializeObject(listDaTiCookie);
                
                Response.Cookies.Append("DaTi", strCookieNew, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(100) });
                return true.ToString();
            }
            catch(Exception ex)
            {
                return false.ToString() + ex.Message;
            }
            
        }
       

        public IActionResult Error()
        {
            return View();
        }
    }
}
