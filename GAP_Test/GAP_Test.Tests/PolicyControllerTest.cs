using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GAP_Tec_Test.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Entities;

namespace GAP_Test.Tests
{
    [TestClass]
    public class PolicyControllerTest
    {
        UnitOfWork uw = new UnitOfWork(new GAPTestEntities());
        [TestMethod]
        public void CreatePolicyTest()
        {
            PolicyController pc = new PolicyController();
            Policy policy = new Policy();
            policy.policy_name = "unit testing";
            policy.policy_description= "unit testing";
            var result = pc.Policy(policy) as RedirectResult;
            Assert.AreEqual("~/Policy/Policies", result.Url);
        }

        [TestMethod]
        public void EditPolicyTest()
        {
            PolicyController pc = new PolicyController();
            Policy policy = new Policy();
            policy.id_policy = 5;
            policy.policy_name = "unit testing editing";
            policy.policy_description = "unit testing editing";
            var result = pc.SaveChanges(policy) as RedirectResult;
            Assert.AreEqual("~/Policy/Policies", result.Url);
        }


        [TestMethod]
        public void GetAllPoliciesTest()
        {
            PolicyController pc = new PolicyController();
            var result = pc.Policies() as ViewResult;
            //List<Policy> actualElements = result.ViewBag.policies.ToList();
            List<Policy> expectedItems = uw.Policies.GetAll().ToList();
            //Assert.AreEqual(expectedItems.Count, actualElements.Count);
        }

        [TestMethod]
        public void DeletePolicyTest()
        {
            PolicyController pc = new PolicyController();
            Policy policy = new Policy();
            policy.id_policy = 5;
           
            var result = pc.DeletePolicy(policy) as RedirectResult;
            Assert.AreEqual("~/Policy/Policies", result.Url);
        }

        

    }
}
