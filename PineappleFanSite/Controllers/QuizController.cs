using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using PineappleFanSite.Models;

namespace PineappleFanSite.Controllers
{
    public class QuizController : Controller
    {
        public Dictionary<int, String> Questions { get; set; }
        public Dictionary<int, String> Answers { get; set; }

        public QuizController()
        {
            Questions = new Dictionary<int, String>();
            Answers = new Dictionary<int, String>();

            Questions[1] = "Are pineapples only from Hawaii?";
            Answers[1] = "Nope.";
            Questions[2] = "Can you hide a camera in a pineapple?";
            Answers[2] = "Yep.";
            Questions[3] = "Where does a certain iconic pineapple live?";
            Answers[3] = "Under the sea!";
        }
        // GET: Quiz
        public ActionResult Index()
        {
            var model = LoadQuestions(new Tests());
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string answer1, string answer2, string answer3)
        {
            var model = LoadQuestions(new Tests());
            model.UserAnswers[1] = answer1;
            model.UserAnswers[2] = answer2;
            model.UserAnswers[3] = answer3;
            var checkedModel = checkQuizAnswers(model);
            return View(checkedModel);
        }

        public Tests LoadQuestions(Tests model)
        {
            model.Questions = Questions;
            model.Answers = Answers;
            model.UserAnswers = new Dictionary<int, string>();
            model.Results = new Dictionary<int, bool>();
            foreach (var question in Questions) 
            {
                int key = question.Key;
                model.UserAnswers[key] = "";
            }
            return model;
        }

        public Tests checkQuizAnswers(Tests model)
        {
            foreach (var question in Questions) 
            {
                int key = question.Key;
                model.Results[key] = model.Answers[key] == model.UserAnswers[key];
            }
            return model;
        }
    }
}