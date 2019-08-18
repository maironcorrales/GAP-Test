using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using GAP_Tec_Test.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Entities;

namespace GAP_Unitary_Test
{
    [TestClass]
    class LoginControllerTest
    {
        [TestMethod]
        public void LoginTest()
        {
            LoginController lc = new LoginController();
            User user = new User();
            user.username = "admin";
            user.user_password = "1234";
            var result = lc.Login(user) as ViewResult;
            Assert.AreEqual("Policies", result.ViewName);
        }
    }
}
