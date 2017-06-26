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
    /// API para administrar los tratamientos
    /// </summary>
    [RoutePrefix("api/tratamientos")]
    [JwtAuthentication]
    public class TratamientosController : ApiController
    {
        /// <summary>
        /// Repositorio de acceso de datos a los tratamientos
        /// </summary>
        private IRepository<Tratamiento> repositorioTratamientos;
        
        /// <summary>
        /// Se inicializa los repositorios
        /// </summary>
        public TratamientosController()
        {
            this.repositorioTratamientos = new RepositorioTratamiento();
        }

        /// <summary>
        /// se asignan los repositorios
        /// </summary>
        /// <param name="repositorioTratamientos"></param>
        public TratamientosController(IRepository<Tratamiento> repositorioTratamientos)
        {
            this.repositorioTratamientos = repositorioTratamientos;
        }

        /// <summary>
        /// lista todos los tratamientos registrados
        /// </summary>
        /// <returns>lista de tratamientos</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var tratamientos = repositorioTratamientos.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, tratamientos);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }


        /// <summary>
        /// Lista todos los trataientos asociados a un paciente
        /// </summary>
        /// <param name="id">identificacion del paciente en base de datos</param>
        /// <returns></returns>
        [Route("getAllbyPaciente")]
        public HttpResponseMessage GetAllPaciente(int id)
        {
            try
            {
                var tratamientos = repositorioTratamientos.GetMany(x=> x.Paciente_Id==id);
                return Request.CreateResponse(HttpStatusCode.OK, tratamientos);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }


        /// <summary>
        /// Elimina un tratamiento 
        /// </summary>
        /// <param name="Id">identificacion del tratamiento en base de datos</param>
        /// <returns></returns>
        [HttpGet]
        [Route("delete")]
        public HttpResponseMessage deleteTratamiento(int Id)
        {
            try
            {
                var tratamiento = repositorioTratamientos.GetById(Id);
                repositorioTratamientos.Remove(tratamiento);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
