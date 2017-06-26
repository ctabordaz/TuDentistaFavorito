using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DentistaFavoritoApp.Repositories;
using Moq;
using System.Collections.Generic;
using DentistaFavoritoApp.Models;
using DentistaFavoritoApp.ApiControllers;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using System.Linq.Expressions;

namespace DentistaFavoritoApp.Tests
{
    [TestClass]
    public class TratamientoControllerTest
    {
        Mock<RepositorioTratamiento> mockRepositorioTratamiento;

        [TestInitialize]
        public void Initialize()
        {
            mockRepositorioTratamiento = new Mock<RepositorioTratamiento>();
        }

        [TestMethod]
        public void TestGetAll()
        {
            //Arrange

            ICollection<Tratamiento> listaMock = new List<Tratamiento>();
            listaMock.Add(new Tratamiento() { Id = 0, Detalle = "Prueba" });
            mockRepositorioTratamiento.Setup(r => r.GetAll()).Returns(listaMock);
            TratamientoController controller = new TratamientoController(mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.GetAll();

            //Assert
            IEnumerable<Tratamiento> tratamientos;
            response.TryGetContentValue<IEnumerable<Tratamiento>>(out tratamientos);
            Assert.AreEqual(1, tratamientos.Count());
        }

        [TestMethod]
        public void TestGetAllExcepcion()
        {
            //Arrange        
            mockRepositorioTratamiento.Setup(r => r.GetAll()).Throws(new Exception());
            TratamientoController controller = new TratamientoController(mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.GetAll();

            //Assert
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public void TestGetPaciente()
        {
            //Arrange

            ICollection<Tratamiento> listaMock = new List<Tratamiento>();
            listaMock.Add(new Tratamiento() { Id = 0, Detalle = "Prueba" });
            mockRepositorioTratamiento.Setup(r => r.GetMany(It.IsAny<Expression<Func<Tratamiento, bool>>>())).Returns(listaMock);
            TratamientoController controller = new TratamientoController(mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.GetAllPaciente(1);

            //Assert
            IEnumerable<Tratamiento> tratamientos;
            response.TryGetContentValue<IEnumerable<Tratamiento>>(out tratamientos);
            Assert.AreEqual(1, tratamientos.Count());
        }

        [TestMethod]
        public void TestGetPacienteExcepcion()
        {
            //Arrange
            mockRepositorioTratamiento.Setup(r => r.GetMany(It.IsAny<Expression<Func<Tratamiento, bool>>>())).Throws(new Exception());
            TratamientoController controller = new TratamientoController(mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.GetAllPaciente(1);

            //Assert
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            mockRepositorioTratamiento.Setup(r => r.Remove(It.IsAny<Tratamiento>())).Verifiable();
            TratamientoController controller = new TratamientoController(mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.deleteTratamiento(1);

            //Assert
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void TestDeleteExcepcion()
        {
            //Arrange
            mockRepositorioTratamiento.Setup(r => r.Remove(It.IsAny<Tratamiento>())).Throws(new Exception());
            TratamientoController controller = new TratamientoController(mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.deleteTratamiento(1);

            //Assert
            Assert.AreEqual(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}
