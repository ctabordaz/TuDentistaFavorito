using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace DentistaFavoritoApp.Models
{
    [DataContract]
    public class Paciente
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Identificacion { get; set; }
        [DataMember]
        public int Edad { get; set; }
        [DataMember]
        public string DatosContacto { get; set; }
        [DataMember]
        public DateTime UltimaConsulta { get; set; }
        [DataMember]
        public DateTime ProximaConsulta { get; set; }

        [DataMember]
        public ICollection<Tratamiento> Tratamientos { get; set; }
    }
}