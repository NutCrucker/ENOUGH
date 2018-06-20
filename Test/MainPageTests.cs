using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumingIT.Methods;
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
        
        private fakeMethods method = new fakeMethods();
        [SetUp]
        public void LoadDriver()
        {
            User user = new User();
            user.email = "tomerezon@gmail.com";
            user.password = "vpugk,ktchc";
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
            method.GoToGroup("מאליה");
            System.Threading.Thread.Sleep(2000);
            method.Post("C:/Users/Tomer/Desktop/Was.txt");
        }
    }
}
