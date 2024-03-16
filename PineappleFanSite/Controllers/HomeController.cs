using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PineappleFanSite.Data;

namespace PineappleFanSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        readonly IRegistryRepository _repository;

        public HomeController(AppDbContext c, IRegistryRepository r)
        {
            _context = c;
            _repository = r;
        }

        public async Task<IActionResult> Index(string by, DateTime? date)
        {
            var stories = from s in _context.Stories
                          select s;

            if (!String.IsNullOrEmpty(by))
            {
                stories = stories.Where(s => s.By.Contains(by));
            }

            if (date.HasValue)
            {
                stories = stories.Where(s => s.Date.Date == date.Value.Date);
            }

            return View(await stories.ToListAsync());
        }

        //public ActionResult Index()
        //{
            //return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "GREETINGS BATTLE BROTHERS I AM NEW. **HOLDS UP BOLTER** MY NAME IS SERGEANT ARGUS BUT YOU CAN CALL ME BATTLE BROTHER. AS YOU CAN SEE I AM VERY LOYAL TO THE EMPEROR. " +
                "THAT IS WHY I HAVE COME HERE, TO MEET OTHER BATTLE BROTHERS WHO ARE LOYAL TO THE EMPEROR LIKE MYSELF. I AM 127 YEARS OF AGE (PRAISE THE EMPEROR) I LIKE TO PURGE HERETICS AND XENO SCUM WITH MY BATTLE BROTHERS (I LOVE MY BATTLE BROTHERS, IF YOU DO NOT LIKE THAT THE DEAL WITH IT) " +
                "IT IS OUR FAVORITE ACTIVITY BECAUSE THEY ARE NOT LOYAL TO THE EMPEROR. ALL MY BATTLE BROTHERS ARE LOYAL TO THE EMPEROR TOO OF COURSE, BUT I WANT TO MEET MORE LOYAL SERVANTS OF THE EMPEROR. " +
                "LIKE THE EMPEROR ONCE SAID, THE MORE THE MERRIER. I HOPE TO BOND WITH A LARGE AMOUNT OF LOYAL SERVANTS OF THE EMPEROR SO JOIN ME IN PRAISE OF THE EMPEROR. FAREWELL. " +
                "PRAISE THE EMPEROR " +
                "BATTLE BROTHER!";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "BATTLE BROTHER YOU CAN CONTACT MICROSOFT HERE!";

            return View();
        }

        public ActionResult History()
        {
            ViewBag.Message = "BATTLE BROTHER! GATHER 'ROUND AS I, A PROUD MEMBER OF THE NERD SQUAD, REGALE YOU WITH TALES OF OUR MOST SACRED CREATION - PINEAPPLE TECH, FORGED BY THE MINDS OF TYLER AND THE ESTEEMED LEVI. PINEAPPLE, THE FRUIT OF THE EMPEROR'S CHOOSING, WITH ITS GOLDEN CROWN, IS THE ESSENCE OF PURE, TROPICAL POWER. JUST AS OUR BOLTERS ROAR IN THE NAME OF THE EMPEROR, THE SWEET BURST OF PINEAPPLE FLAVOR INVIGORATES OUR SOULS. IN THE GRIM DARKNESS OF THE 41ST MILLENNIUM, WHERE ONLY WAR REIGNS SUPREME, WE HAVE DISCOVERED A HAVEN IN LEVI'S UTOOB PINEAPPLE TUTORIALS, UNLOCKING THE SECRETS OF THIS FRUITY DELIGHT. PRAISE THE EMPEROR AND PASS THE PINEAPPLE GRENADES, FOR WE SHALL FIND SALVATION!";

            return View();
        }

        [Authorize]
        public ActionResult ForumPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForumPost(Models.Stories model)
        {
            Random random = new Random();
            model.Date = DateTime.Now;
            model.Id = _context.Stories.Max(s => s.Id) + 1;
            model.Rating = random.Next(1, 6);
            //_context.Stories.Add(model);
            _repository.StoreStories(model);
            _context.SaveChanges(); 
            return RedirectToAction("Index", new { model.Id });
        }
    }
}