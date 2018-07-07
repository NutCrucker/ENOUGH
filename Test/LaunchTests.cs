using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumingIT.Objects;
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
        private Method method = new Method();
        User user = new User();
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
            user.Build(LoginAndPost.Default.correctEmail, LoginAndPost.Default.correctPass, new Post());
            method.LoginToFacebook(user);
        }
        [TestCase]
        public void LoginToFacebook_WrongDetails()
        {
            method.LaunchFacebook();
            method.LoginObject.Login("tomerezon@gmail.com", "1234");
            if (method.driver.Title != "Facebook" && method.driver.Title != "פייסבוק") Assert.Pass();
        }
        [TestCase]
        public void IgnorePerm_Check()
        {
            LoginToFacebook_CorrectDetails();
            IWebElement d = method.driver.FindElement(By.Name("q"));
            d.Click();
        }
        
    }
}
