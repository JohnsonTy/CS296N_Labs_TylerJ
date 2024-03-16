using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PineappleFanSite.Data;
using PineappleFanSite.Models;

namespace PineappleFanSite.Controllers
{
    public class SourcesController : Controller
    {
        private readonly AppDbContext _context;
        UserManager<AppUser> userManager;
        public SourcesController(AppDbContext context, UserManager<AppUser> user)
        {
            _context = context;
            userManager = user;
        }

        [Authorize]
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

        [Authorize]
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

        //[Authorize]
        //public IActionResult Reply(int? OriginalStoryId)
        //{
        //    Stories story = new Stories();
        //    story.OriginalStoryId = OriginalStoryId;
        //    return View(story);
        //}

        ////  CREDIT: Brian's pigeon code
        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> Reply(Reply model)
        //{
        //    model.Name = await userManager.GetUserAsync(User);
        //    model.Date = DateOnly.FromDateTime(DateTime.Now);

        //    // Get the message being replied to (guarantted to be not null by design)
        //    Stories originalPost = await _context.GetStoryByIdAsync(model.OriginalStoryId.Value);

        //    // Save the message
        //    await _context.StoreAsync(model);
        //    // Add the reply to the original message
        //    originalPost.Replies.Add(model);
        //    _context.UpdateStories(originalPost);
        //    //TODO: Do something interesting/useful with the MessageId or don't send it. It's not currently used.
        //    return RedirectToAction("Index", new { model });
        //}



        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> ForumPost(Stories model)
        //{
        //    if (userManager != null)
        //    {
        //        userManager.GetUserAsync(User).Result;
        //    }
        //    model.Date = DateOnly.FromDateTime(DateTime.Now);
        //    //  TODO: Change somethere here to make tests work, end of 2nd video Monday, 1/29/24

        //    //  Temporarily add random post rating
        //    Random random = new Random();
        //    model.Rating = random.Next(1, 10);



        //    //  Code to save info in the database
        //    // CHANGED DURING ASYNC CONVERSION int result;
        //    await _context.StorePostAsync(model);
        }
    }