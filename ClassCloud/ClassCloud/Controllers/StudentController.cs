﻿using ClassCloud.Models;
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
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //
        // GET: /Student/
        public ActionResult Index()
        {
            string currentUser = User.Identity.GetUserName();
            if (currentUser == "")
            {
                ViewBag.Message = "Would you like to log in";
                return View();
            }
            System.Diagnostics.Debug.WriteLine(currentUser);

            var _CurrUserData = (from _UserData in db.UserDatas
                                 where _UserData.UserName == currentUser
                                 select _UserData);
            UserData CurrUserData = _CurrUserData.FirstOrDefault();
            if (CurrUserData == null)
                return View();
            return View(CurrUserData.Courses.ToList());
        }
        [ActionName("loadchat")]
        [HttpGet]
        public ActionResult LoadChat(int ID)
        {
            var Lecture = (from _Lecture in db.Lectures
                            where _Lecture.ID == ID
                            select _Lecture).FirstOrDefault();

           
            return Json(Lecture.Discussion.ToArray(), JsonRequestBehavior.AllowGet);

        }
        public ActionResult Calendar()
        {
            
            return View(); 
        }


        [ActionName("getAllCourses")]
        [HttpGet]
        public ActionResult GetAllCourses()
        {
            string currentUser = User.Identity.GetUserName();
            var _CurrUserData = (from _UserData in db.UserDatas
                                 where _UserData.UserName == currentUser
                                 select _UserData);
            UserData CurrUserData = _CurrUserData.FirstOrDefault();

            List<JSONCourse> AllCourse = new List<JSONCourse>();
            foreach (var _course in CurrUserData.Courses) {
                System.Diagnostics.Debug.WriteLine(CurrUserData.Courses.Count);
                JSONCourse JSONCourse = new JSONCourse(_course.ID, _course.CRN, _course.Name);
                System.Diagnostics.Debug.WriteLine(_course.Lectures.Count);

                foreach (var Lecture in _course.Lectures)
                {

                    JSONCourse.Lectures.Add(new JSONLecture(Lecture.ID, Lecture.Name, Lecture.CourseID, Lecture.Date));
                }
                AllCourse.Add(JSONCourse);
            }

            System.Diagnostics.Debug.WriteLine(AllCourse.Count);
            return Json(AllCourse, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SearchClasses(string searchString, int? CRN)
        {
            if(searchString == null && CRN == null)
            {
                return View(db.Courses.ToList());
            }
            var classes = from m in db.Courses
                            select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                classes = classes.Where(s => s.Name.Contains(searchString));
            }
            else
            {
                classes = classes.Where(s => s.CRN == CRN);
            }
            return View(classes);
        }

        //
        // GET: /Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Student/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
