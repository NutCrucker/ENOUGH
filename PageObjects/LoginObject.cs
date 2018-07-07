using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.IO;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumingIT
{
    public class LoginObject
    {
        [FindsBy(How = How.Id, Using = "pass")]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement Email { get; set; }

        public void InsertEmail(string email)
        {
            Email.SendKeys(email);
        }
        public void InsertPassword(string password)
        {
            Password.SendKeys(password);
        }
        public void Login(string email,string password)
        {
            InsertEmail(email);
            InsertPassword(password);
            Password.SendKeys(Keys.Enter);
        }

        

        
    }
}
