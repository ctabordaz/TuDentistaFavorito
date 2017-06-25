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
        private IRepository<Tratamiento> repositorioTratamientos;

        public PacienteController()
        {
            repositorioPaciente = new RepositorioPaciente();
            this.repositorioTratamientos = new RepositorioTratamiento();
        }

        public PacienteController(IRepository<Paciente> repositorioPaciente, IRepository<Tratamiento> repositorioTratamientos)
        {
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioTratamientos = repositorioTratamientos;

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

        [Route("getbyId")]
        public HttpResponseMessage GetbyId(int id)
        {
            try
            {
                var paciente = repositorioPaciente.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, paciente);
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
            {   if(paciente.Id == 0)
                {
                    repositorioPaciente.Add(paciente);
                }else
                {
                    repositorioPaciente.Update(paciente);
                    foreach (var tratamiento in paciente.Tratamientos)
                    {
                        if(tratamiento.Id== 0)
                        {
                            repositorioTratamientos.Add(tratamiento);
                        }else
                        {
                            repositorioTratamientos.Update(tratamiento);
                        }
                    }
                }
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
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
