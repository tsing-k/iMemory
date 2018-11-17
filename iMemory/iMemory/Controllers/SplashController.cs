using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iMemory.Controllers
{
    public class SplashController : Controller
    {
        // GET: Splash
        public ActionResult Index()
        {
            ViewBag.Title = "李芳芳生日快乐！";
            ViewBag.Name = "李芳芳";

            List<string> musics = Utility.OssHelper.GetFileUrls(Utility.GlobalData.OssEndpoint, Utility.GlobalData.OssBucketName, Utility.GlobalData.OssAccessKeyId, Utility.GlobalData.OssAccessKeySecret, "music/");
            if (musics.Count > 0)
            {
                ViewBag.Music = string.Format("{0}/{1}", Utility.GlobalData.CdnDomain, musics.First());
            }

            return View();
        }
    }
}