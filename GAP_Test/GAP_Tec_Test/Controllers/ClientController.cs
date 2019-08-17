using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.Entities;

namespace GAP_Tec_Test.Controllers
{
    public class ClientController : Controller
    {
        UnitOfWork uw = new UnitOfWork(new GAPTestEntities());
        Client client = new Client();
        // GET: Client
        public ActionResult Client()
        {
            List<Client> clientList = uw.Clients.GetAll().ToList();
            ViewBag.clients = clientList;
            return View();
        }

        public ActionResult AddClient(Client model)
        {
            uw.Clients.Add(model);
            uw.Complete();
            return Redirect("~/Client/Client");
        }

        public ActionResult DeleteClient(Client model)
        {
            Client client = uw.Clients.Get(model.id_client);
            uw.Clients.Remove(client);
            uw.Complete();
            return Redirect("~/Client/Client");
        }

        public ActionResult EditClient(int id)
        {
            return View(client = uw.Clients.Get(id));
        }

        public ActionResult AddPolicyToClient()
        {
            return View();
        }

        public ActionResult SaveChanges(Client model)
        {
            Client client = uw.Clients.Get(model.id_client);
            client.full_name = model.full_name;
            client.identification = model.identification;
            uw.Complete();
            return Redirect("~/Client/Client");
        }
    }
}