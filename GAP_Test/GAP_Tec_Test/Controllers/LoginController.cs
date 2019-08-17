using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using GAP_Tec_Test.Models;
using Model;

namespace GAP_Tec_Test.Controllers
{
    public class LoginController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(User model)
        {
            // comprobar si el usuario existe mediante el unitofwork y si todo esta bien dejarlo pasar
            UnitOfWork ui = new UnitOfWork(new GAPTestEntities());
            if (ui.Users.UserExist(model.username, model.user_password))
                return Redirect("~/Policy/Policies");
            else
                return Redirect("~/Login/Index");
        }
    }
}