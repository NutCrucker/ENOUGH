using NUnit.Framework;
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
        FakeUser user = new FakeUser();
        FakePost post = new FakePost();
        [TestCase]
        public void Post_SetPath_Check()
        {
            post.setPath(LoginAndPost.Default.correctPath);
            Assert.IsNotEmpty(post.path);
        }
        [TestCase]
        public void Post_SetPath_NotValidPath()
        {
            post.setPath("C");
            Assert.IsNull(post.path);
        }
        [TestCase]
        public void Post_SetGroups_Check()
        {
            post.setGroups();
            Assert.IsNotNull(post.groups);
        }
        [TestCase]
        public void Post_Init_Check()
        {
            post.Init(LoginAndPost.Default.correctPath);
            if (post.path != null && post.groups != null) Assert.Pass();
        }
        [TestCase]
        public void User_SetEmail()
        {
            user.setEmail("Email");
            Assert.IsNotNull(user.email);
        }
        [TestCase]
        public void User_SetPass()
        {
            user.setPass("Pass");
            Assert.IsNotNull(user.password);
        }
        [TestCase]
        public void User_SetPost()
        {
            user.setPost(LoginAndPost.Default.correctPath);
            Assert.IsNotNull(user.post);
        }
        [TestCase]
        public void User_Init()
        {
            user.Init(LoginAndPost.Default.correctEmail, LoginAndPost.Default.correctPass, LoginAndPost.Default.correctPath);
            if(user.email != null && user.password != null && user.post != null) Assert.Pass();
        }
    }
}
