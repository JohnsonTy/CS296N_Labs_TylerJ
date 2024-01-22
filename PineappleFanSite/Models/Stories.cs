using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PineappleFanSite.Models
{
    public class Stories
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public int Year { get; set; }
        public string Text { get; set; }
        public string By { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
    }

}