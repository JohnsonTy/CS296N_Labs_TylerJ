using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.AspNetCore.Identity.UI.Services
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        //public static implicit operator AppUser(string v)
        //{
            //throw new NotImplementedException();
        //}
    }
}