using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ClassCloud.Models
{
    public class Lecture
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Comment> Discussion { get; set; }
        public virtual ICollection<int> StudentIDs { get; set; }


        public int CourseID { get; set; }

        public DateTime Date { get; set; }

        public Lecture()
        {
            Discussion = new Collection<Comment>();
            StudentIDs = new Collection<int>();
        }

        public Lecture(string _Name, int _CourseID, DateTime? _Date = null)
        {
            if (!_Date.HasValue)
                Date = DateTime.Now;
            else if (_Date.HasValue)
                Date = _Date.Value;

            Name = _Name;
            CourseID = _CourseID;
        }
    }
}