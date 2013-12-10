using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassCloud.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserComment { get; set; }
    }
}