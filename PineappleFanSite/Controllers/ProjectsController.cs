using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using PineappleFanSite.Data;
using PineappleFanSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PineappleFanSite.Controllers
{
    public class ProjectsController : Controller
    {
        AppDbContext context;

        readonly IRegistryRepository repository;
        UserManager<AppUser> userManager;
        public ProjectsController(AppDbContext c, IRegistryRepository r)
        {
            context = c;
            repository = r;
        }
        //public ICollection<Stories> Index(int Id) {
            //var stories = context.Stories
                //.Include(c => c.Year)
                //.Include(c => c.Topic)
                //.Include(c => c.By)
                //.ToList();
            //return (ICollection<Stories>)View(stories);
        //}
        // GET: Projects
        public ActionResult Index()
        {
           return View();
        }

        public ActionResult ForumPost()
        {
            //int result;
            //result = repository.StoreMessage(model);
            return View();
        }
        [HttpPost]
        public ActionResult ForumPost(Models.Stories model)
        {
            model.Date = DateTime.Now;

            // Save model to db
            repository.StoreStories(model);
            context.Stories.Add(model);
            context.SaveChanges();

            return RedirectToAction("Index", new { model.Id });
        }

        public ActionResult Info()
        {
            return View();
        }

    }
}