using DesctopForCafe.Services.DbService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void RegTestMethod()
        {
            string login = "zil@gmail.com";
            string password = "12345";
            var dbService = new DbService();
            bool expected = dbService.CanReg(login, password);
            bool actual = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LoginTestMethod()
        {
            string login = "zil@gmail.com";
            string password = "12345";
            var dbService = new DbService();
            bool expected = dbService.CanLogin(login, password);
            bool actual = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
