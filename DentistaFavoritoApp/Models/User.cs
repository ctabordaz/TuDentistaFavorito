using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DentistaFavoritoApp.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Contrasena { get; set; }
    }
}