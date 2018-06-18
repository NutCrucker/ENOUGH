using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT.PageObjects
{
    public class GroupsObjects
    {
        [FindsBy(How = How.Name, Using = "xhpc_message_text")]
        private IWebElement TextBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button._1mf7._4jy0._4jy3._4jy1._51sy.selected._42ft")]
        private IWebElement PostButton { get; set; }

        public void Post(string path)
        {
            TextBox.SendKeys(File.ReadAllText(path));
            System.Threading.Thread.Sleep(2000);
            PostButton.Click();
            System.Threading.Thread.Sleep(5000);
        }
    }
}
