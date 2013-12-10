using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassCloud.Models
{
    public class Lecture
    {
        public int ID { get; set; }
        [Display(Name = "Lecture Topic")]
        public string Name { get; set; }
        public virtual ICollection<Comment> Discussion { get; set; }
        public virtual ICollection<Note> Notes { get; set; }


        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public DateTime Date { get; set; }

        public Lecture()
        {
            Discussion = new Collection<Comment>();
            Notes = new Collection<Note>();
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




    public class JSONLecture {

        public int ID { get; set; }
        [Display(Name = "Lecture Topic")]
        public string Name { get; set; }
        public virtual ICollection<Comment> Discussion { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public string Date { get; set; }
        public int CourseID { get; set; }

        public JSONLecture(int _ID,string _Name, int _CourseID, DateTime? _Date = null)
        {
            if (!_Date.HasValue)
                Date = DateTime.Now.ToString("MMMM dd, yyyy");
            else if (_Date.HasValue)
                Date = _Date.Value.ToString("MMMM dd, yyyy");
            ID = _ID;
            Name = _Name;
            CourseID = _CourseID;
        }
    
    }
}