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
    public class ClientControllerTest
    {
        UnitOfWork uw = new UnitOfWork(new GAPTestEntities());
        [TestMethod]
        public void AddClientTest()
        {
            ClientController cc = new ClientController();
            Client client = new Client();
            client.full_name = "mairon";
            client.identification = 5415;
            var result = cc.AddClient(client) as RedirectResult;
            Assert.AreEqual("~/Client/Client", result.Url);
        }

        [TestMethod]
        public void GetClientsTest()
        {
            ClientController cc = new ClientController();
            var result = cc.Client() as ViewResult;
            List<Client> actualElements = result.ViewBag.clients;
            List<Client> expectedItems = uw.Clients.GetAll().ToList();
            Assert.AreEqual(expectedItems.Count, actualElements.Count);

        }

        [TestMethod]
        public void EditClientTest()
        {
            ClientController cc = new ClientController();
            Client client = new Client();
            client.full_name = "mairon Corrales";
            client.identification = 54155481;
            client.id_client = 5;
            var result = cc.SaveChanges(client) as RedirectResult;
            Assert.AreEqual("~/Client/Client", result.Url);
        }

        [TestMethod]
        public void DeleteClientsTest()
        {
            ClientController cc = new ClientController();
            Client client = new Client();
            client.id_client = 4;

            var result = cc.DeleteClient(client) as RedirectResult;
            Assert.AreEqual("~/Client/Client", result.Url);
        }

        [TestMethod]
        public void AddPlanToClientTest()
        {
            ClientController cc = new ClientController();
            Client_has_Policy chp = new Client_has_Policy();
            chp.client_id_client = 5;
            chp.plan_Coverage_description = "unit testing";
            chp.policy_id_policy = 2;
            chp.risk = 3;
            chp.coverage_amount = 50;
            chp.coverage_period = 12;
            chp.cover_object = "test";
            chp.coverage_start = DateTime.Now;
            chp.coverage_monthly_price = 3000;
            FormCollection col = new FormCollection();
           
            var result = cc.AddPolicy(col, chp) as RedirectResult;
            Assert.AreEqual("~/Client/AddPolicyToClient/" + chp.client_id_client,result.Url);
        }

        [TestMethod]
        public void DeletePlanToClientTest()
        {
            ClientController cc = new ClientController();
           
            var result = cc.DeletePlan(4) as RedirectResult;
            Assert.AreEqual("~/Client/AddPolicyToClient/" + 5, result.Url);
        }

        [TestMethod]
        public void EditPlanToClientTest()
        {
            ClientController cc = new ClientController();
            Client_has_Policy chp = new Client_has_Policy();
            chp.id_coverage_plan = 4;
            chp.client_id_client = 5;
            chp.plan_Coverage_description = "unit testing";
            chp.policy_id_policy = 3;
            chp.risk = 3;
            chp.coverage_amount = 50;
            chp.coverage_period = 12;
            chp.cover_object = " unit test";
            chp.coverage_start = DateTime.Now;
            chp.coverage_monthly_price = 3000;
            FormCollection col = new FormCollection();

            var result = cc.EditPolicy(chp) as RedirectResult;
            Assert.AreEqual("~/Client/AddPolicyToClient/" + chp.client_id_client, result.Url);
        }

        [TestMethod]
        public void GetPlansOfClientTest()
        {
            ClientController cc = new ClientController();
            var result = cc.AddPolicyToClient(1) as ViewResult;
            List<Client_has_Policy> actualElements = result.ViewBag.pliciesOfClient;
            List<Client_has_Policy> expectedItems = uw.ClienHasPolicies.GetAllPoliciesFromClient(1).ToList();
            Assert.AreEqual(expectedItems.Count, actualElements.Count);
        }

    }
}
