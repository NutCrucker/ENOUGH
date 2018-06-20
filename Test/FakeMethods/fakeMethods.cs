using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumingIT.Methods;
using SeleniumingIT.Objects;
using SeleniumingIT.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT
{
    public class fakeMethods:Method
    {
        public new void UnloadDriver()
        {
            driver.Quit();
            Console.WriteLine("TearDown Finished Successfully");
        }
        public new void LoginToFacebook(User user)
        {
            LaunchFacebook();
            LoginObject.Login(user.email, user.password);
            ignorePrem();
        }
        //PostMethods
        public new void GoToGroup(string name)
        {
            Search(name);
            try
            {
                IWebElement Group = driver.FindElement(By.PartialLinkText(name));
                Group.Click();
            }
            catch
            {
                Console.WriteLine("Please be more specific about the groups name:");
                name = "מאליה";
                GoToGroup(name);
            }

        }
        public new void Post(string path)
        {
            GroupObjects.Post(path);
            Console.WriteLine("Posted! Going back to the main page.");
        }
        public void PostOnGroups(FakeUser user)
        {
            for (int i = 0; i < user.Groups().Length; i++)
            {
                GoToGroup(user.Groups()[i].name);
                System.Threading.Thread.Sleep(2000);
                Post(user.post.path);
                ReturnToMain();
            }
        }

        public void StartPosting(FakeUser user,string path,string email,string password)
        {
            user.Init(email, password, path);
            LoginToFacebook(user);
            PostOnGroups(user);
            Console.WriteLine("Finished posting. Thank you for using the app!");
            UnloadDriver();
        }
    }
}

