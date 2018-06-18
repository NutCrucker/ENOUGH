using NUnit.Framework;
using SeleniumingIT.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumingIT.Test
{
    public class SimpleTests
    {
        fakeSimpleMethods method = new fakeSimpleMethods();
        [TestCase]
        public void GroupValidation_Correct()
        {
            Assert.IsTrue(method.ValidateGroup(method.ValidAnswer_Y()));
        }
        [TestCase]
        public void GroupValidation_False()
        {
            Assert.IsFalse(method.ValidateGroup(method.ValidAnswer_N()));
        }
        [TestCase]
        public void CheckValidAnswer()
        {
            if ((method.ValidAnswer_N() == "Y") || (method.ValidAnswer_N() == "N"))
            {
                Assert.Pass();
            }
            else Assert.Fail();
        }
        [TestCase]
        public void GetPath_Valid()
        {
            Assert.AreNotEqual(method.GetPath("C:\\Users\\Tomer\\Desktop\\Was.txt"), "");
        }
        [TestCase]
        public void GetPath_NotValid()
        {
            Assert.AreEqual(method.GetPath("aaa"), "");
        }
    }
}
