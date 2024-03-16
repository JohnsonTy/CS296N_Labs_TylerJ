//using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;

namespace PineappleFanSite.Models
{
    public class Login
    {
        private IEnumerable<AppUser> users = new List<AppUser>();
        private IEnumerable<IdentityRole> roles = new List<IdentityRole>();
        public IEnumerable<AppUser> Users { get => users; set => users = value; }
        public IEnumerable<IdentityRole> Roles { get => roles; set => roles = value; }

    }
}
