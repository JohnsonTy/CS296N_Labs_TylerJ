using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PineappleFanSite.Models
{
    public class AppUser
    {
        public string Name { get; set; }
        public int AppUserId { get; set; }

        //public static implicit operator AppUser(string v)
        //{
            //throw new NotImplementedException();
        //}
    }
}