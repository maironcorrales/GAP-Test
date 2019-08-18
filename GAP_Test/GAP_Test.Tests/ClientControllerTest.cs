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
    }
}
