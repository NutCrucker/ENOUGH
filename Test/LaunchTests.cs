using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumingIT.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT
{
    [TestFixture]
    public class LaunchTests
    {
        private fakeMethods method = new fakeMethods();
        

        [TearDown]
        public void UnloadDriver()
        {
            method.UnloadDriver();
            Console.WriteLine("TearDown Finished Successfully");
        }

        [TestCase]
        public void LaunchFacebook_Correctly()
        {
            method.LaunchFacebook();
            Assert.AreEqual(Facebook.Default.URL, method.driver.Url);
        }
        [TestCase]
        public void LoginToFacebook_CorrectDetails()
        {
            User user = new User();
            user.email = "tomerezon@gmail.com";
            user.password = "vpugk,ktchc";
            method.LoginToFacebook(user);
            try
            {
                IWebElement d = method.driver.FindElement(By.Name("q"));
            }
            catch
            {
                Assert.Fail();
            }
        }
        [TestCase]
        public void LoginToFacebook_WrongDetails()
        {
            User user = new User();
            user.email = "tomerezon@gmail.com";
            user.password = "1234";
            method.LoginToFacebook(user);
            try
            {
                IWebElement d = method.driver.FindElement(By.Name("q"));
                Assert.Fail();
            }
            catch{}
        }
        [TestCase]
        public void IgnorePerm_Check()
        {
            LoginToFacebook_CorrectDetails();
            try
            {
                IWebElement d = method.driver.FindElement(By.Name("q"));
                d.Click();
            }
            catch
            {
                Assert.Fail();
            }
        }
        
    }
}
