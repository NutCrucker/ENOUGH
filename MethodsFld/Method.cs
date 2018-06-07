using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumingIT.Methods;
using SeleniumingIT.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT
{
    public class Method
    {

        private IWebDriver driver;
        private LoginObjects LoginObjects = new LoginObjects();
        private GroupsObjects GroupObjects = new GroupsObjects();
        private MainPageObjects MainObjects = new MainPageObjects();
        private SimpleMethods method = new SimpleMethods();
        private WebDriverWait wait;
        
        public void LoadDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddExcludedArgument("ignore-certificate-errors");
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            PageFactory.InitElements(driver, LoginObjects);
            PageFactory.InitElements(driver, MainObjects);
            PageFactory.InitElements(driver, GroupObjects);
        }
        public void UnloadDriver()
        {
            driver.Quit();
            Console.WriteLine("TearDown Finished Successfully");
        }
        //LaunchMethods
        public void LaunchFacebook()
        {
            LoadDriver();
            driver.Navigate().GoToUrl("http://www.facebook.com");
        }
        public void LoginToFacebook(string email, string password)
        {
            LaunchFacebook();
            LoginObjects.Login(email, password);
            ignorePrem();
        }
        public void ignorePrem()
        {
            System.Threading.Thread.Sleep(5000);
            Actions builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.Id("blueBarDOMInspector")), 10, 25).Click().Build().Perform();
        }
        //MainMethods
        public void ReturnToMain()
        {
            MainObjects.GoToMainPage();
        }
        public void Search(string name)
        {
            MainObjects.SearchGroup(name);
        }
        //PostMethods
        public void GoToGroup(string name)
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
                name = Console.ReadLine();
                GoToGroup(name);
            }
            
        }
        public void Post(string path)
        {
            if (method.ValidateGroup())
            {
                GroupObjects.Post(path);
                Console.WriteLine("Posted! Going back to the main page.");
            }
            else
            {
                Console.WriteLine("Couldn't get into the right group, moving to post in the next group!");
            }
        }
        public void PostOnGroups(Group[] groups, string path)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                GoToGroup(groups[i].name);
                Post(path);
                ReturnToMain();
            }
        }

        public void StartPosting(User user)
        {
            user.Init();
            LoginToFacebook(user.email, user.password);
            PostOnGroups(user.Groups(),user.post.path);
            Console.WriteLine("Finished posting. Thank you for using the app!");
            UnloadDriver();
            Console.ReadKey();
        }
    }
}
