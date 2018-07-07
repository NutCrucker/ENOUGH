using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT.PageObjects
{
    public class MainPageObject
    {
        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement Search { get; set; }

        [FindsBy(How = How.Id, Using = "u_0_c")]
        private IWebElement MainPageButton { get; set; }

        public void GoToMainPage()
        {
            MainPageButton.Click();
        }

        public void ClickSearchBar()
        {
            Search.Click();
        }

        public void SearchGroup(string name)
        {
            ClickSearchBar();
            Search.SendKeys(name);
            Search.SendKeys(Keys.Enter);
        }
    }
}
