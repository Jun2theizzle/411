using ClassCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Collections.ObjectModel;

namespace ClassCloud.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            // 
            return View(db.Courses.ToList());
        }

        public ActionResult Chat()
        {
            return View();
            
        }

        public ActionResult Classes()
        {
            
            string currentUser = User.Identity.GetUserName();
            if (currentUser == "")
            {
                ViewBag.Message = "Would you like to log in";
                return View();
            }
            System.Diagnostics.Debug.WriteLine(currentUser);
            System.Diagnostics.Debug.WriteLine("uh oh");
            var _CurrUserData = (from _UserData in db.UserDatas
                                 where _UserData.UserName == currentUser
                                 select _UserData);
            UserData CurrUserData = _CurrUserData.FirstOrDefault();
            //return View();
            System.Diagnostics.Debug.WriteLine(CurrUserData.Courses.ToList());
            return View(CurrUserData.Courses.ToList());
        }



        [ActionName("loadcourseinfo")]
        [HttpGet]
        public ActionResult LoadCourseInfo(int ID)
        {

            var CourseInfo = (from _Course in db.Courses
                              where _Course.ID == ID
                              select _Course).FirstOrDefault();
            var Lectures = (from _Lecture in db.Lectures
                            where _Lecture.CourseID == ID
                            select _Lecture).ToArray<Lecture>();
            CourseInfo.Lectures = Lectures;

            //var StudentIDs = (from _Course in db.Courses
            //                  where _Course.ID == ID
            //                  select _Course.StudentIDs).FirstOrDefault();
            //CourseInfo.StudentIDs = StudentIDs;
            return Json(CourseInfo, JsonRequestBehavior.AllowGet);
        }
        [ActionName("addcourse")]
        [HttpGet]
        public ActionResult AddCourse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }

            string currentUser = User.Identity.GetUserName();
            var _CurrUserData = (from _UserData in db.UserDatas
                                 where _UserData.UserName == currentUser
                                 select _UserData);



            UserData CurrUserData = _CurrUserData.FirstOrDefault();
            if (CurrUserData == null)
            {
                UserData NewData = new UserData(currentUser);
                NewData.Courses.Add(course);
                db.UserDatas.Add(NewData);
                db.SaveChanges();
                return Json(NewData.Courses, JsonRequestBehavior.AllowGet);
            }
            else
                CurrUserData.Courses.Add(course);
            db.SaveChanges();
            return Json(CurrUserData.Courses, JsonRequestBehavior.AllowGet);
        }

    }
}