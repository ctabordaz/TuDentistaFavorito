using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DentistaFavoritoApp.Models
{
    /// <summary>
    /// Informacion del tratamiento
    /// </summary>
    [DataContract]
    public class Tratamiento
    {
        /// <summary>
        /// Identificacion del tratamiento en base de datos
        /// </summary>
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// Fecha en la que inicio el tratamiento
        /// </summary>
        [DataMember]
        public DateTime FechaInicio { get; set; }
        /// <summary>
        /// Fecha en la que finaliza el tratamiento
        /// </summary>
        [DataMember]
        public DateTime FechaConclusion { get; set; }
        /// <summary>
        /// Costo del tratamiento
        /// </summary>
        [DataMember]
        public double Costo { get; set; }
        /// <summary>
        /// Detalle e informacion del tratamiento
        /// </summary>
        [DataMember]
        public string Detalle { get; set; }
        /// <summary>
        /// Paciente del tratamiento
        /// </summary>
        [DataMember]
        public virtual int Paciente_Id { get; set; }


    }
}