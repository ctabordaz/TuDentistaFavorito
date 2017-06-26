using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DentistaFavoritoApp.Repositories;
using DentistaFavoritoApp.Models;
using System.Collections.Generic;
using DentistaFavoritoApp.ApiControllers;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace DentistaFavoritoApp.Tests
{
    [TestClass]
    public class PacienteControllerTest
    {
        Mock<RepositorioPaciente> mockRepositorioPaciente;
        Mock<RepositorioTratamiento> mockRepositorioTratamiento;

        [TestInitialize]
        public void Initialize()
        {
            mockRepositorioPaciente = new Mock<RepositorioPaciente>();
            mockRepositorioTratamiento = new Mock<RepositorioTratamiento>();
        }

        [TestMethod]
        public void TestGetAll()
        {
            //Arrange
            
            ICollection<Paciente> listaMock = new List<Paciente>();
            listaMock.Add(new Paciente() { Id = 0, Nombre = "Prueba" });
            mockRepositorioPaciente.Setup(r => r.GetAll()).Returns(listaMock);
            PacienteController controller = new PacienteController(mockRepositorioPaciente.Object, mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.GetAll();

            //Assert
            IEnumerable<Paciente> pacientes;
            response.TryGetContentValue<IEnumerable<Paciente>>(out pacientes);
            Assert.AreEqual(1, pacientes.Count());
        }

        [TestMethod]
        public void TestGetAllException()
        {
            //Arrange
            mockRepositorioPaciente.Setup(r => r.GetAll()).Throws(new System.Exception());            
            PacienteController controller = new PacienteController(mockRepositorioPaciente.Object, mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.GetAll();

            //Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.InternalServerError);
            
        }

        [TestMethod]
        public void TestGetbyId()
        {
            //Arrange
            Paciente mockPaciente = new Paciente() { Id = 0, Nombre = "Prueba" };
            mockRepositorioPaciente.Setup(r => r.GetById(It.IsAny<int>())).Returns(mockPaciente);
            PacienteController controller = new PacienteController(mockRepositorioPaciente.Object, mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.GetbyId(10);

            //Assert
            Paciente paciente;
            response.TryGetContentValue<Paciente>(out paciente);
            Assert.IsTrue(paciente.Id == 0);
        }

        [TestMethod]
        public void TestGetbyIdException()
        {
            //Arrange
            mockRepositorioPaciente.Setup(r => r.GetById(It.IsAny<int>())).Throws(new System.Exception());
            PacienteController controller = new PacienteController(mockRepositorioPaciente.Object, mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.GetbyId(10);

            //Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.InternalServerError);

        }

        [TestMethod]
        public void TestSave()
        {
            //Arrange
            Paciente mockPaciente = new Paciente() { Id = 0, Nombre = "Prueba" };
            mockRepositorioPaciente.Setup(r => r.AddOrUpdate(It.IsAny<Paciente>())).Returns(mockPaciente);
            PacienteController controller = new PacienteController(mockRepositorioPaciente.Object, mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.Save(mockPaciente);

            //Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

        }


        [TestMethod]
        public void TestUpdate()
        {
            //Arrange            
            ICollection<Tratamiento> mockNuevosTratamientos = new List<Tratamiento>() { new Tratamiento() {Id = 2, Paciente_Id = 1 } };
            Paciente mockPaciente = new Paciente() { Id = 1, Nombre = "Prueba", Tratamientos = mockNuevosTratamientos };
            ICollection<Tratamiento> mockViejosTratamientos = new List<Tratamiento>() { new Tratamiento() { Id = 1, Paciente_Id =1 } };
            mockRepositorioPaciente.Setup(r => r.AddOrUpdate(It.IsAny<Paciente>())).Returns(mockPaciente);

            mockRepositorioTratamiento.Setup(t => t.AddOrUpdate(mockNuevosTratamientos.First())).Returns(mockNuevosTratamientos.First());
            mockRepositorioTratamiento.Setup(t => t.GetMany(It.IsAny<Expression<Func<Tratamiento, bool>>>())).Returns(mockViejosTratamientos);
            mockRepositorioTratamiento.Setup(t => t.RemoveRange(It.IsAny<IEnumerable<Tratamiento>>())).Verifiable();

            PacienteController controller = new PacienteController(mockRepositorioPaciente.Object, mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.Save(mockPaciente);

            //Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

        }

        [TestMethod]
        public void TestSaveException()
        {
            //Arrange
            Paciente mockPaciente = new Paciente() { Id = 0, Nombre = "Prueba" };
            mockRepositorioPaciente.Setup(r => r.AddOrUpdate(It.IsAny<Paciente>())).Throws(new Exception());
            PacienteController controller = new PacienteController(mockRepositorioPaciente.Object, mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.Save(mockPaciente);

            //Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.InternalServerError);

        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            Paciente mockPaciente = new Paciente() { Id = 0, Nombre = "Prueba" };
            mockRepositorioPaciente.Setup(r => r.GetById(It.IsAny<int>())).Returns(mockPaciente);
            mockRepositorioPaciente.Setup(r => r.Remove(It.IsAny<Paciente>())).Verifiable();
            PacienteController controller = new PacienteController(mockRepositorioPaciente.Object, mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.deletePaciente(10);

            //Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

        }


        [TestMethod]
        public void TestDeleteException()
        {
            //Arrange            
            mockRepositorioPaciente.Setup(r => r.GetById(It.IsAny<int>())).Throws(new Exception());
            
            PacienteController controller = new PacienteController(mockRepositorioPaciente.Object, mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.deletePaciente(10);

            //Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.InternalServerError);

        }

    }
}
