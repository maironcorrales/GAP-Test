using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.Entities;

namespace GAP_Tec_Test.Controllers
{
    public class PolicyController : Controller
    {

        UnitOfWork uw = new UnitOfWork(new GAPTestEntities());
        Policy policy = new Policy();
        // GET: Policy
        public ActionResult Policies()
        {
            List <Policy> policyList = uw.Policies.GetAll().ToList();
            ViewBag.policies = policyList;
            return View();
        }

        public ActionResult Policy(Policy model)
        {
            
            uw.Policies.Add(model);
            uw.Complete();
            return Redirect("~/Policy/Policies");
        }
    
        public ActionResult EditPolicy(int id)
        {
            
            return View( policy = uw.Policies.Get(id));
        }

        public ActionResult SaveChanges(Policy model)
        {
            Policy policy = uw.Policies.Get(model.id_policy);
            policy.policy_name = model.policy_name;
            policy.policy_description = model.policy_description;
            uw.Complete();
            return Redirect("~/Policy/Policies");
        }

        public ActionResult DeletePolicy(Policy model)
        {
            Policy policy = uw.Policies.Get(model.id_policy);
            uw.Policies.Remove(policy);
            uw.Complete();
            return Redirect("~/Policy/Policies");
        }
    }
}