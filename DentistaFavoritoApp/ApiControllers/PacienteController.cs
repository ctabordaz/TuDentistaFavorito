using DentistaFavoritoApp.Filters;
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
    [JwtAuthentication]
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
            {
             
                repositorioPaciente.AddOrUpdate(paciente);
                if(paciente.Id != 0)
                {
                    var tratamientos = repositorioTratamientos.GetMany(t => t.Paciente_Id == paciente.Id);
                    var tratamientosEliminar = tratamientos.Where(t => !paciente.Tratamientos.Any(nt => nt.Id == t.Id));
                    repositorioTratamientos.RemoveRange(tratamientosEliminar);

                    foreach (var tratamiento in paciente.Tratamientos)
                    {                       
                        repositorioTratamientos.AddOrUpdate(tratamiento);
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
