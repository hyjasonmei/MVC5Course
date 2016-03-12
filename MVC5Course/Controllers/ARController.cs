using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Action()
        {
            return PartialView("Index");
        }

        public ActionResult FileTest()
        {
            var filename = Server.MapPath("~/Content/Koala.jpg");
            //第三個參數就會自動變下載
            return File(filename, "image/jpeg","koala.jpg");
        }

        public ActionResult JsonShow()
        {
            return View();
        }

        public ActionResult JsonTest()
        {
            var db = new FabricsEntities();
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.Product.Take(3);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}