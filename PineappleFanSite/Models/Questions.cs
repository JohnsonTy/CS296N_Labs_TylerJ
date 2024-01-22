using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PineappleFanSite.Models
{
    public class Tests
    {
        public Dictionary<int, String> Questions { get; set; }
        public Dictionary<int, String> Answers { get; set; }
        public Dictionary<int, String> UserAnswers { get; set; }
        public Dictionary<int, bool> Results { get; set; }
    }
}