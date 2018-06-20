using NUnit.Framework;
using SeleniumingIT.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT.Test
{
    public class EndtoEndTest
    {
        fakeMethods method = new fakeMethods();
        [SetUp]
        public void LoadDriver()
        {
            
        }
        [TearDown]
        public void UnloadDriver()
        {

        }
        [TestCase]
        public void EndtoEnd_WrongEmail()
        {
            try
            {
                method.StartPosting(new FakeUser(), LoginAndPost.Default.correctPath, "tomerezon1gmail.com", LoginAndPost.Default.correctPass);
                Assert.Fail();
            }
            catch
            {
                method.UnloadDriver();
                Assert.Pass();
            }
        }
        [TestCase]
        public void EndtoEnd_WrongPass()
        {
            try
            {
                method.StartPosting(new FakeUser(), LoginAndPost.Default.correctPath, LoginAndPost.Default.correctEmail, "asdf");
                Assert.Fail();
            }
            catch
            {
                method.UnloadDriver();
                Assert.Pass();
            }
        }
        [TestCase]
        public void EndtoEnd_BadPath()
        {
            try
            {
                method.StartPosting(new FakeUser(), "asdfasd", LoginAndPost.Default.correctEmail, LoginAndPost.Default.correctPass);
                Assert.Fail();
            }
            catch
            {
                method.UnloadDriver();
                Assert.Pass();
            }
        }
        [TestCase]
        public void EndtoEnd_Correct()
        {
            method.StartPosting(new FakeUser(), LoginAndPost.Default.correctPath, LoginAndPost.Default.correctEmail, LoginAndPost.Default.correctPass);
        }
    }
}
