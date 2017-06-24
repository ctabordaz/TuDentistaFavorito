using DentistaFavoritoApp.Models;
using DentistaFavoritoApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DentistaFavoritoApp.ApiControllers
{
   [RoutePrefix("api/pacientes")]
    public class PacienteController : ApiController
    {
        private IRepository<Paciente> repositorioPaciente;

        public PacienteController()
        {
            repositorioPaciente = new RepositorioPaciente();
        }

        public PacienteController(IRepository<Paciente> repositorioPacietne)
        {
            this.repositorioPaciente = repositorioPacietne;
        }

        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var listaPacientes = repositorioPaciente.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, listaPacientes);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("save")]
        public HttpResponseMessage Save(Paciente paciente)
        {
            try
            {
                repositorioPaciente.Add(paciente);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("delete")]
        public HttpResponseMessage deletePaciente(int Id)
        {
            try
            {
                var paciente = repositorioPaciente.GetById(Id);
                repositorioPaciente.Remove(paciente);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
