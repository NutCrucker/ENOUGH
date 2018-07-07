using OpenQA.Selenium;
using System;

namespace SeleniumingIT
{
    internal class BrowserUtil
    {
        IWebDriver webDriver;
        public BrowserUtil(IWebDriver web)
        {
            this.webDriver = web;
        }

        internal void EnterFacebook()
        {
            //Open facebook url with chrome
        }
    }
}