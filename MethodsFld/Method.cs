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
    public class Method
    {

        public IWebDriver driver;
        public LoginObject LoginObject = new LoginObject();
        public GroupsObject GroupObjects = new GroupsObject();
        public MainPageObject MainObjects = new MainPageObject();
        protected SimpleMethods method = new SimpleMethods();
        protected WebDriverWait wait;
        
        public void LoadDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddExcludedArgument("ignore-certificate-errors");
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            PageFactory.InitElements(driver, LoginObject);
            PageFactory.InitElements(driver, MainObjects);
            PageFactory.InitElements(driver, GroupObjects);
        }

        public void UnloadDriver()
        {
            driver.Quit();
            Console.WriteLine("TearDown Finished Successfully");
        }

        #region Launch Methods
        public void LaunchFacebook()
        {
            LoadDriver();
            driver.Navigate().GoToUrl(Facebook.Default.URL);
        }
        public void CorrectLogin(User user)
        {
            if (driver.Title != "Facebook" && driver.Title != "פייסבוק")
            {
                Console.WriteLine("Invalid login details, please try again");
                user.SetEmail();
                user.SetPass();
                UnloadDriver();
                LoginToFacebook(user);
            }
            else ignorePrem();
        }
        public void LoginToFacebook(User user)
        {
            LaunchFacebook();
            LoginObject.Login(user.Email, user.Password);
            CorrectLogin(user);
        }
        public void ignorePrem()
        {
            System.Threading.Thread.Sleep(5000);
            Actions builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.Id("blueBarDOMInspector")), 10, 25).Click().Build().Perform();
        }
        #endregion

        #region Main Methods
        public void ReturnToMain()
        {
            MainObjects.GoToMainPage();
        }
        public void Search(string name)
        {
            MainObjects.SearchGroup(name);
        } 
        #endregion
        

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
        public void PostOnGroups(User user)
        {
            for (int i = 0; i < user.Post.groups.Length; i++)
            {
                GoToGroup(user.Post.groups[i].name);
                Post(user.Post.path);
                ReturnToMain();
            }
        }

        public void StartPosting(User user)
        {
            user.Init();
            LoginToFacebook(user);
            PostOnGroups(user);
            Console.WriteLine("Finished posting. Thank you for using the app!");
            UnloadDriver();
            Console.ReadKey();
        }
        public void TestableEndtoEnd(User user)
        { 
            user.Build(LoginAndPost.Default.correctEmail, LoginAndPost.Default.correctPass, new Post());
            user.Post.Build(LoginAndPost.Default.correctPath, new Group[1]);
            user.Post.groups[0] = new Group();
            user.Post.groups[0].name = "מאליה";
            LoginToFacebook(user);
            for (int i = 0; i < user.Post.groups.Length; i++)
            {
                GoToGroup(user.Post.groups[i].name);
                System.Threading.Thread.Sleep(2000);
                GroupObjects.Post(user.Post.path);
                ReturnToMain();
            }
        }
        public bool LoginFailEndtoEnd(User user)
        {
            LaunchFacebook();
            LoginObject.Login(user.Email, user.Password);
            if (driver.Title != "Facebook" && driver.Title != "פייסבוק") return true;
            return false;
        }
    }
}
