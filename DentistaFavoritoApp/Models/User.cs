using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DentistaFavoritoApp.Models
{
    /// <summary>
    /// credenciales del usuario de la aplicacion
    /// </summary>
    [DataContract]
    public class User
    {
        /// <summary>
        /// nombre del usuario de aplicacion
        /// </summary>
        [DataMember]
        public string Usuario { get; set; }
        /// <summary>
        /// Contraseña del usuario de aplicacion
        /// </summary>
        [DataMember]
        public string Contrasena { get; set; }
    }
}