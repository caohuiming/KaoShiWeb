using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

using System.Threading.Tasks;

using System.IO;

using System.Text;
using System.Collections.Generic;

using Ipaloma.Model;


namespace Ipaloma.API.Controllers
{
    /// <summary>
    /// PC后台权限验证
    /// </summary>
    public class NeedPCLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var adminName = filterContext.HttpContext.Request.Cookies["adminName"];
            if (adminName != "admin")
            {
                filterContext.HttpContext.Response.Redirect("/Login/index");
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class BaseController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            context.HttpContext.Response.Headers.Add("Cache-Control", "no-cache");
        }

        /// <summary>
        /// 获取登陆ID
        /// </summary>
        /// <returns></returns>
        protected int UserId
        {
            get
            {
                int userid = -1;
                int.TryParse(HttpContext.Session.GetString("userid"), out userid);
                return userid;
            }
        }

    }


}
