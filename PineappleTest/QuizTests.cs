using Microsoft.VisualStudio.TestTools.UnitTesting;
using PineappleFanSite.Controllers;
using PineappleFanSite.Models;
using System;

namespace PineappleTest
{
    [TestClass]
    public class QuizTests
    {/*
        [TestMethod]
        public void TestLoadQuestions()
        {
            var controller = new QuizController();
            var model = new Tests();

            var loadedModel = controller.LoadQuestions(model);

            Assert.AreEqual(controller.Questions, loadedModel.Questions);
            Assert.AreEqual(controller.Answers, loadedModel.Answers);
            Assert.IsNotNull(loadedModel.Questions);
            Assert.IsNotNull(loadedModel.Answers);
            Assert.IsNotNull(controller.Questions);
            Assert.IsNotNull(controller.Answers);
            Assert.AreEqual(loadedModel.Questions.Count, loadedModel.Answers.Count);
        }

        [TestMethod]
        public void TestCheckQuizAnswers()
        {
            var model = new Tests();
            var controller = new QuizController();
            var loadedModel = controller.LoadQuestions(model);
            loadedModel.UserAnswers[1] = "Nope.";
            loadedModel.UserAnswers[2] = "Yep.";
            loadedModel.UserAnswers[3] = "Hello there.";

            var result = controller.checkQuizAnswers(model);
            Assert.IsTrue(result.Results[1]);
            Assert.IsFalse(result.Results[2]);
            Assert.IsFalse(result.Results[3]);
        }
    */
    }
}
