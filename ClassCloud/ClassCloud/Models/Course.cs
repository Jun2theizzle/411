using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ClassCloud.Models
{
    public class Course
    {
        public int ID { get; set; }
        public int CRN { get; set; }
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
           
        }
    }
}