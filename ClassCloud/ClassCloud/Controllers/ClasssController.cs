using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassCloud.Models;



namespace ClassCloud.Controllers
{

    public class ClasssController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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

        public ActionResult CreateLecture(Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine(lecture.ID);
                Course course = db.Courses.Find(lecture.CourseID);
                course.Lectures.Add(lecture);
                db.SaveChanges();
            }
            return View();
        }
    }
}
