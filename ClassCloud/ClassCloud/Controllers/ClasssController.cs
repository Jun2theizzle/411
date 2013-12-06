using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassCloud.Controllers
{
    public class ClasssController : Controller
    {
        //
        // GET: /Classs/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Classs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult ClassStudent()
        {
            return View();
        }

        public ActionResult LectureDetails()
        {
            return View();
        }
    }
}
