using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Web;

namespace PineappleFanSite.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        [NotMapped]
        public IList<string>? RoleNames { get; set; }
        //public static implicit operator AppUser(string v)
        //{
            //throw new NotImplementedException();
        //}
    }
}