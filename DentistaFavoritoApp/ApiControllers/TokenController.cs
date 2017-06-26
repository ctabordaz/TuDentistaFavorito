using DentistaFavoritoApp.JWT;
using DentistaFavoritoApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace DentistaFavoritoApp.ApiControllers
{
    [RoutePrefix("api/token")]
    [AllowAnonymous]
    public class TokenController : ApiController
    {
        public TokenController()
        {

        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Get(User usuario)
        {
            if (validarUsuario(usuario))
            {
                var response = new
                {
                    Token = JwtManager.GenerateToken(usuario.Usuario)
                };
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        private bool validarUsuario(User usuario)
        {
            try
            {
                if (usuario.Usuario == ConfigurationManager.AppSettings["Usuario"].ToString() && usuario.Contrasena == ConfigurationManager.AppSettings["Contrasena"].ToString())
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
    }
}
