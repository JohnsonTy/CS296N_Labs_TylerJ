using Microsoft.AspNetCore.Identity;
using PineappleFanSite.Models;
using System;
using System.Linq;

namespace PineappleFanSite.Data
{
    public class SeedData
    {
        //public static List<Stories> Stories {  get; set; }
        private readonly UserManager<IdentityUser> _userManager;

        public SeedData(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task Seed(AppDbContext context)
        {
            if (!context.Stories.Any())  // prevent dupes from being added
            {
                var user = new IdentityUser { UserName = "username", Email = "email@example.com" };
                var result = await _userManager.CreateAsync(user, "password");

                if (result.Succeeded)
                {
                    // User created good
                    Console.WriteLine("User created!");
                }
                else
                {
                    // Handlin' errors
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }

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

                await context.SaveChangesAsync();  // stores all the stories
            }
        }
    }
}