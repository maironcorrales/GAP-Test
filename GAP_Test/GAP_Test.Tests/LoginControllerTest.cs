using System;
using System.Web.Mvc;
using GAP_Tec_Test.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Entities;

namespace GAP_Test.Tests
{
    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod]
        public void Login()
        {
            LoginController lc = new LoginController();
            User user = new User();
            user.username = "admin";
            user.user_password = "1234";
            var result = lc.Login(user) as RedirectResult;
            Assert.AreEqual("~/Policy/Policies",result.Url);
        }

        [TestMethod]
        public void LoginFailed()
        {
            LoginController lc = new LoginController();
            User user = new User();
            user.username = "admins";
            user.user_password = "123456";
            var result = lc.Login(user) as RedirectResult;
            Assert.AreEqual("~/Login/Index", result.Url);
        }


    }
}
