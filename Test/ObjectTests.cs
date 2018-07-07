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
    public class ObjectTests
    {
        User user = new User();
        Post post = new Post();
        public Group[] setGroups()
        {
            Mock<SimpleMethods> mock = new Mock<SimpleMethods>();
            mock.Setup(x => x.SetGroups()).Returns(new Group[3]);
            return mock.Object.SetGroups();
        }
        [TestCase]
        public void Post_SetPath_Check()
        {
            post.Build(LoginAndPost.Default.correctPath,new Group[1]);
        }
        [TestCase]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Incorrect path")]
        public void Post_SetPath_NotValidPath()
        {
            post.Build(post.TestPath("111"), new Group[1]);
        }
        [TestCase]
        public void Post_SetGroups_Check()
        {
            post.Build("",setGroups());
            Assert.IsNotNull(post.groups);
        }
        [TestCase]
        public void Post_Init_Check()
        {
            post.Build(LoginAndPost.Default.correctPath,setGroups());
            if (post.path == null || post.groups == null) Assert.Fail();
        }
        [TestCase]
        public void User_Init()
        {
            user.Build("","",new Post());
            if(user.Email == null || user.Password == null || user.Post == null) Assert.Fail();
        }
    }
}
