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




        [ActionName("loadcourseinfo")]
        [HttpGet]
        public ActionResult LoadCourseInfo(int ID)
        {
            System.Diagnostics.Debug.WriteLine(ID);
            var CourseInfo = (from _Course in db.Courses
                              where _Course.ID == ID
                              select _Course).FirstOrDefault();
            var Lectures = (from _Lecture in db.Lectures
                            where _Lecture.CourseID == ID
                            select _Lecture).ToArray<Lecture>();

            JSONCourse JSONCourse = new JSONCourse(CourseInfo.ID, CourseInfo.CRN, CourseInfo.Name);
            foreach(var Lecture in Lectures)
            {
            JSONCourse.Lectures.Add(new JSONLecture(Lecture.ID,Lecture.Name,Lecture.CourseID,Lecture.Date));
            }
            return Json(JSONCourse, JsonRequestBehavior.AllowGet);
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
                var newcourse = NewData.Courses.Select(x => new
                {
                    ID = x.ID,
                    Name = x.Name,
                    //items = x.Lectures.Select(item => new
                    //{
                    //    for nested collections
                    //})
                });
                db.SaveChanges();
                return Json(newcourse, JsonRequestBehavior.AllowGet);
            }
            else
                CurrUserData.Courses.Add(course);

            var courses = CurrUserData.Courses.Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                //items = x.Lectures.Select(item => new
                //{
                //    for nested collections
                //})
            });


            db.SaveChanges();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }


    }


}