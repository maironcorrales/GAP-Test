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
        Client_has_Policy clientHasP = new Client_has_Policy(); 
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

        public ActionResult AddPolicyToClient(int id)
        {
            List<Client_has_Policy> clientPolicyList = uw.ClienHasPolicies.GetAllPoliciesFromClient(id).ToList();
            ViewBag.pliciesOfClient = clientPolicyList;
            ViewBag.client = uw.Clients.Get(id);
            List<Policy> policyList = uw.Policies.GetAll().ToList();
            ViewBag.policies = new SelectList(policyList,"id_policy","policy_name");
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

        public ActionResult AddPolicy(FormCollection collection, Client_has_Policy model)
        {
            model.client_id_client = Convert.ToInt32(collection[0]);
            if (model.risk == 4 && model.coverage_amount > 50)
            {
                model.coverage_amount = 50;
            }
            uw.ClienHasPolicies.Add(model);
            uw.Complete();
            return Redirect("~/Client/AddPolicyToClient/"+model.client_id_client);
        }

        public ActionResult DeletePlan(int id)
        {
            int param = 0;
            Client_has_Policy chp = uw.ClienHasPolicies.Get(id);
            param = chp.client_id_client;
            uw.ClienHasPolicies.Remove(chp);
            uw.Complete();
            return Redirect("~/Client/AddPolicyToClient/" + param);
        }

        public ActionResult EditPlan(int id)
        {
            List<Policy> policyList = uw.Policies.GetAll().ToList();
            ViewBag.policies = new SelectList(policyList, "id_policy", "policy_name");
            return View(clientHasP = uw.ClienHasPolicies.Get(id));
        }

        public ActionResult EditPolicy(Client_has_Policy model) 
        {
            Client_has_Policy chp = uw.ClienHasPolicies.Get(model.id_coverage_plan);
            chp.plan_Coverage_description = model.plan_Coverage_description;
            chp.coverage_period = model.coverage_period;
            chp.coverage_start = model.coverage_start;
            chp.cover_object = model.cover_object;
            chp.coverage_amount = model.coverage_amount;
            chp.coverage_monthly_price = model.coverage_monthly_price;
            chp.risk = model.risk;
            if (chp.risk == 4 && chp.coverage_amount > 50)
                chp.coverage_amount = 50;
            uw.Complete();
            return Redirect("~/Client/AddPolicyToClient/" + chp.client_id_client);
        }

        
    }
}