using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iMemory.Models;
using Utility;

namespace iMemory.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserModel model)
        {
            if(ModelState.IsValid)
            {
                if (model != null
                    && (model.UserName.Trim().ToLower().Equals("lifangfang") || (model.UserName.Trim().Equals("李芳芳")))
                    && model.Pwd.Trim().Equals("200418KuN"))
                {
                    return Index();
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码错误！");
                }
            }

            return RedirectToAction("Index", "Splash", model);
        }

        private ActionResult Index()
        {
            List<string> images = Utility.OssHelper.GetFileUrls(Utility.GlobalData.OssEndpoint, Utility.GlobalData.OssBucketName, Utility.GlobalData.OssAccessKeyId, Utility.GlobalData.OssAccessKeySecret, "photos/");
            List<string> musics = Utility.OssHelper.GetFileUrls(Utility.GlobalData.OssEndpoint, Utility.GlobalData.OssBucketName, Utility.GlobalData.OssAccessKeyId, Utility.GlobalData.OssAccessKeySecret, "music/");

            List<string> imageUrls = new List<string>();
            foreach (string image in images)
            {
                imageUrls.Add(string.Format("{0}/{1}", Utility.GlobalData.CdnDomain, image));
            }
            ViewBag.Images = imageUrls;
            if (musics.Count > 0)
            {
                ViewBag.Music = string.Format("{0}/{1}", Utility.GlobalData.CdnDomain, musics.First());
            }

            return View();
        }
    }
}