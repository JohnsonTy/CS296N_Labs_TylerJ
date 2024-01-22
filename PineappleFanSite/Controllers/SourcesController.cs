using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PineappleFanSite.Data;

namespace PineappleFanSite.Controllers
{
    public class SourcesController : Controller
    {
        private readonly AppDbContext _context;

        public SourcesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> FanSites(string searchString)
        {
            var stories = from s in _context.Stories
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                stories = stories.Where(s => s.Title.Contains(searchString));
            }

            return View(await stories.ToListAsync());
        }

        public ActionResult Index(int Id)
        {
            var stories = _context.Stories
                                  .Where(s => s.Id >= 3)
                                  .ToList();
            return View(stories);
        }

        //public ActionResult FanSites()
        //{
            //return View();
        //}

        public ActionResult News(Models.Stories model)
        {
            var stories = _context.Stories
                                  .Where(s => s.Id <= 2)
                                  .ToList();
            return View(stories);
        }
    }
}