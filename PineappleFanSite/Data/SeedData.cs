using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI.Services;
using PineappleFanSite.Data;
using PineappleFanSite.Models;
using System;
using System.Linq;

namespace PineappleFanSite.Data
{
    public class SeedData
    {
        //public static List<Stories> Stories {  get; set; }
        public static void Seed(AppDbContext context, IServiceProvider provider) { 
        if (!context.Stories.Any())  // this is to prevent adding duplicate data
            {
                var userManager = provider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

                
                const string ROLE = "Admin";
                const string SECRET_PASSWORD = "!DRG_321";

                // if role doesn't exist, create it
                bool isSuccess = true;
                if (roleManager.FindByNameAsync(ROLE).Result == null)
                {
                    isSuccess = roleManager.CreateAsync(new IdentityRole(ROLE)).Result.Succeeded;
                }


                var user1 = new AppUser { Name = "Tyler Johnson", UserName = "Tech7yl3r"};
                var user2 = new AppUser { Name = "Ryan Polter", UserName = "RPgamer" };
                context.SaveChanges();

                Random random = new Random();
                Stories story = new Stories
                {
                    Id = 1,
                    Title = "News Alert?",
                    Topic = "Tertium",
                    Year = 41628,
                    Text = "GUESS WHAT, it's Story Time with Captain Titus. Orks are heretics! Destroy them all brothers.",
                    By = "Titus",
                    Date = DateTime.Parse("12/12/2023 12:12:12 PM"),
                    Rating = 10

                };
                context.Stories.Add(story);  // queues up the stories to be added to the front page

                story = new Stories
                {
                    Id = 2,
                    Title = "News Again!",
                    Topic = "Testing News",
                    Year = 2024,
                    Text = "A Short Story.", 
                    By = "Marvel",
                    Date = DateTime.Parse("1/4/2024"),
                    Rating = random.Next(1, 11)
                };
                context.Stories.Add(story);

                story = new Stories
                {
                    Id = 3,
                    Title = "A cool Story without much News",
                    Topic = "Grimdark Pineapples",
                    Year = 42642,
                    Text = "Pineapples in the far, distant future are pretty neat. They glow with a mysterious blue aura, and sometimes float around to give you advice.",
                    By = "An Adeptus Astartes",
                    Date = DateTime.Parse("1/6/2024 8:12:16 PM"),
                    Rating = 42
                };
                context.Stories.Add(story);

                context.SaveChangesAsync();  // stores all the stories
            }
        }
    }
}