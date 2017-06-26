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
    /// <summary>
    /// API para administrar los pacientes
    /// </summary>
    [RoutePrefix("api/pacientes")]
    [JwtAuthentication]
    public class PacienteController : ApiController
    {
        /// <summary>
        /// Repositorio de acceso de datos a los pacientes
        /// </summary>
        private IRepository<Paciente> repositorioPaciente;
        /// <summary>
        /// Repositorio de acceso de datos a los tratamientos
        /// </summary>
        private IRepository<Tratamiento> repositorioTratamientos;

        /// <summary>
        /// Se inicializan los repositorios
        /// </summary>
        public PacienteController()
        {
            repositorioPaciente = new RepositorioPaciente();
            this.repositorioTratamientos = new RepositorioTratamiento();
        }

        /// <summary>
        /// Se asignan los repositorios
        /// </summary>
        /// <param name="repositorioPaciente"></param>
        /// <param name="repositorioTratamientos"></param>
        public PacienteController(IRepository<Paciente> repositorioPaciente, IRepository<Tratamiento> repositorioTratamientos)
        {
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioTratamientos = repositorioTratamientos;

        }

        /// <summary>
        /// Lista todos los pacientes registrados
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Devuelve el paciente asociado a un Id
        /// </summary>
        /// <param name="id">Identificacion unica en base de datos</param>
        /// <returns></returns>
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

        /// <summary>
        /// Guarda o actualiza un paciente en la base de datos y sus tratamientos
        /// Verifica la diferencia entre los tratamientos a actualizar y los tratamientos en base de datos
        /// y elimina los que faltan
        /// </summary>
        /// <param name="paciente">Paciente a guardar o almacenar</param>
        /// <returns></returns>
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

        /// <summary>
        /// Elimina un paciente de la base de datos
        /// </summary>
        /// <param name="Id">Identificacion del paciente en la base de datos</param>
        /// <returns></returns>
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
