using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DentistaFavoritoApp.Repositories;
using DentistaFavoritoApp.Models;
using System.Collections.Generic;
using DentistaFavoritoApp.ApiControllers;
using System.Net.Http;
using System.Web.Http;
using System.Linq;

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
            mockRepositorioPaciente.Setup(r => r.GetById(10)).Returns(mockPaciente);
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
            mockRepositorioPaciente.Setup(r => r.GetById(10)).Throws(new System.Exception());
            PacienteController controller = new PacienteController(mockRepositorioPaciente.Object, mockRepositorioTratamiento.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.GetbyId(10);

            //Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.InternalServerError);

        }
    }
}
