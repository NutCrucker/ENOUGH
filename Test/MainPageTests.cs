using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumingIT.Methods;
using SeleniumingIT.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT
{
    public class MainPageTests
    {
        User user = new User();
        private Method method = new Method();
        [SetUp]
        public void LoadDriver()
        {
            user.Build(LoginAndPost.Default.correctEmail, LoginAndPost.Default.correctPass, new Post());
            method.LoginToFacebook(user);
        }
        [TearDown]
        public void UnloadDriver()
        {
            method.UnloadDriver();
            Console.WriteLine("TearDown Finished Successfully");
        }
        [TestCase]
        public void SearchCorrectText()
        {
            method.Search("EVB");
            Assert.AreEqual(method.driver.FindElement(By.Name("q")).GetAttribute("value"), "EVB");
        }
        [TestCase]
        public void ReturnToMain_Working()
        {
            SearchCorrectText();
            method.ReturnToMain();
            if (method.driver.Title == "Facebook" || method.driver.Title == "פייסבוק") Assert.Pass();
        }
        [TestCase]
        public void GoToGroup_Correctly()
        {
            method.GoToGroup("מאליה");
            if (method.driver.Title.Contains("מאליה")) Assert.Pass();
        }
        [TestCase]
        public void Post_Correctly()
        {
            method.driver.Navigate().GoToUrl("https://www.facebook.com/groups/1406198856328709/?ref=bookmarks");
            method.ignorePrem();
            method.GroupObjects.Post("C:/Users/Tomer/Desktop/Was.txt");
        }
    }
}
