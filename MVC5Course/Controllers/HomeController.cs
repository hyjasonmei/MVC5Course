using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [RecordExecuteTime]
    public class HomeController : Controller
    {
        //
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }


        [HandleError(View="Error2", ExceptionType=typeof(ArgumentException))]
        public ActionResult ErrorTest(string ErrorType)
        {
            if (ErrorType == "1")
                throw new Exception("Error 1");
            if (ErrorType == "2")
                throw new ArgumentException("Error 2");
            //if (ErrorType == "3")
            //    throw new SqlException();
            return Content("No err");
        }

        public ActionResult RazorTest()
        {
            int[] list = new int[] { 1, 2, 3, 4, 5 };
                        return PartialView(list);
        }
    }
}