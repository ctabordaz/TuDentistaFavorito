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
    /// <summary>
    /// API para generar el token de acceso
    /// </summary>
    [RoutePrefix("api/token")]
    [AllowAnonymous]
    public class TokenController : ApiController
    {
        public TokenController()
        {

        }

        /// <summary>
        /// Valida el usuario y genera el token
        /// </summary>
        /// <param name="usuario">Usuario que se esta autenticando</param>
        /// <returns>token de acceso</returns>
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
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

        /// <summary>
        /// valida si el usuario es igual al del archivo de configuracion
        /// </summary>
        /// <param name="usuario">usuario a validar</param>
        /// <returns>si el usuario es valido</returns>
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
