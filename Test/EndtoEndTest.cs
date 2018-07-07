using Moq;
using NUnit.Framework;
using SeleniumingIT.Methods;
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
        User user = new User();
        Mock<Method> mock = new Mock<Method>();
        Method method = new Method();
        public Group[] SetMock()
        {
            Mock<SimpleMethods> mock = new Mock<SimpleMethods>();
            mock.Setup(x => x.SetGroups()).Returns(new Group[3]);
            return mock.Object.SetGroups();
        }
        [TearDown]
        public void UnloadDriver()
        {
            if (method.driver != null) method.driver.Quit();
        }
        [TestCase]
        public void EndtoEnd_WrongEmail()
        {
            user.Build("a", LoginAndPost.Default.correctPass, new Post());
            Assert.IsTrue(method.LoginFailEndtoEnd(user));
        }
        [TestCase]
        public void EndtoEnd_WrongPass()
        {
            user.Build(LoginAndPost.Default.correctEmail, "12312", new Post());
            Assert.IsTrue(method.LoginFailEndtoEnd(user));
        }
        [TestCase]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Incorrect path")]
        public void EndtoEnd_BadPath()
        {
            Post post = new Post();
            post.Build(post.TestPath("asdf"),SetMock());
            user.Build(LoginAndPost.Default.correctEmail, LoginAndPost.Default.correctPass, post);
        }
        [TestCase]
        public void EndtoEnd_Correct()
        {
            method.TestableEndtoEnd(user); 
        }
    }
}
