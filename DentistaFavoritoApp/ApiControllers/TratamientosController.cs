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
    [RoutePrefix("api/tratamientos")]
    [JwtAuthentication]
    public class TratamientosController : ApiController
    {
        private IRepository<Tratamiento> repositorioTratamientos;
        
        public TratamientosController()
        {
            this.repositorioTratamientos = new RepositorioTratamiento();
        }

        public TratamientosController(IRepository<Tratamiento> repositorioTratamientos)
        {
            this.repositorioTratamientos = repositorioTratamientos;
        }

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
