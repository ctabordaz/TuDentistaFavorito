using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DentistaFavoritoApp.JWT;
using DentistaFavoritoApp.ApiControllers;
using DentistaFavoritoApp.Models;
using System.Net.Http;
using System.Web.Http;

namespace DentistaFavoritoApp.Tests
{
    [TestClass]
    public class TokenControllerTest
    {
        [TestMethod]
        public void TestGetToken()
        {
            //Arrange 
            User user = new User() { Contrasena = "prueba123", Usuario = "prueba" };
            TokenController controller = new TokenController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.Get(user);

            //Assert
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void TestGetTokenInvalido()
        {
            //Arrange 
            User user = new User() { Contrasena = "prueba3456", Usuario = "prueba" };
            TokenController controller = new TokenController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.Get(user);

            //Assert
            Assert.AreEqual(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
