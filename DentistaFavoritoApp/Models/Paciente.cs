using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace DentistaFavoritoApp.Models
{
    /// <summary>
    /// Informacion del paciente
    /// </summary>
    [DataContract]
    public class Paciente
    {
        /// <summary>
        /// Identificacion del paciente en base de datos
        /// </summary>
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// Nombre del paciente
        /// </summary>
        [DataMember]
        public string Nombre { get; set; }
        /// <summary>
        /// Numero de identificacion del paciente
        /// </summary>
        [DataMember]
        public long Identificacion { get; set; }
        /// <summary>
        /// Edad del paciente
        /// </summary>
        [DataMember]
        public int Edad { get; set; }
        /// <summary>
        /// Informacion de contacto del paciente
        /// </summary>
        [DataMember]
        public string DatosContacto { get; set; }
        /// <summary>
        /// Ultima vez que el paciente estuvo en consulta
        /// </summary>
        [DataMember]
        public DateTime UltimaConsulta { get; set; }
        /// <summary>
        /// Proxima cita del paciente
        /// </summary>
        [DataMember]
        public DateTime ProximaConsulta { get; set; }

        /// <summary>
        /// Lista de los tratamientos asignados al paciente
        /// </summary>
        [DataMember]
        public ICollection<Tratamiento> Tratamientos { get; set; }
    }
}