using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ValidationMessage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CheckIfAccountRepeated(string Account)
        {
            bool isValidate = false;
            if (Account != "circle")
                isValidate = true;

            return Json(isValidate, JsonRequestBehavior.AllowGet);
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
    }

    public class Person
    {
        public DateTime LoginAt { get; set; }
        [Required]
        [Remote("CheckIfAccountRepeated", "Home", ErrorMessage = "帳號已存在")]
        public string Account { get; set; }
        [Required(ErrorMessage = "必填欄位")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [DataType(DataType.MultilineText)]
        public string Descr { get; set; }
    }
}