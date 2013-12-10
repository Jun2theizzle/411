using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassCloud.Models
{
    public class Course
    {
        public int ID { get; set; }
        public int CRN { get; set; }
        [Display(Name = "Course Name")]
        public string Name { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<UserData> UserDatas { get; set; }
        public Course()
        {
            Lectures = new Collection<Lecture>();
            UserDatas = new Collection<UserData>();
        }
        public Course(int _CRN, string CourseName)
        {
            CRN = _CRN;
            Name = CourseName;
            Lectures = new Collection<Lecture>();
            UserDatas = new Collection<UserData>();
        }
    }


    public class JSONCourse { 
    
    public int ID { get; set; }
        public int CRN { get; set; }
        [Display(Name = "Course Name")]
        public string Name { get; set; }
        public virtual ICollection<JSONLecture> Lectures { get; set; }
        public virtual ICollection<UserData> UserDatas { get; set; }
        public JSONCourse()
        {
            Lectures = new Collection<JSONLecture>();
            UserDatas = new Collection<UserData>();
        }
        public JSONCourse(int _ID,int _CRN, string CourseName)
        {
            ID = _ID;
            CRN = _CRN;
            Name = CourseName;
            Lectures = new Collection<JSONLecture>();
            UserDatas = new Collection<UserData>();
        }
    
    
    
    }
}