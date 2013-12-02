using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ClassCloud.Models
{
    public enum UserType
    {
        Student, Prof
    };

    public class UserData
    {
        public int UserDataID { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public int Points { get; set; }
        public UserType? UserType { get; set; }


        public UserData()
        {
            Courses = new Collection<Course>();
            Points = 0;

        }
        public UserData(string _UserName)
        {
            Courses = new Collection<Course>();
            Points = 0;
            UserName = _UserName;
        }

        public UserData(string _UserName, ICollection<Course> _Courses, int _Points)
        {
            UserName = _UserName;
            Courses = _Courses;
            Points = _Points;

        }
    }
}