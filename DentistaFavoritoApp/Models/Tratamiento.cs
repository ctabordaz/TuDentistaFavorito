using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DentistaFavoritoApp.Models
{
    [DataContract]
    public class Tratamiento
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public DateTime FechaConclusion { get; set; }
        [DataMember]
        public double Costo { get; set; }
        [DataMember]
        public string Detalle { get; set; }
        [DataMember]
        public virtual int Paciente_Id { get; set; }


    }
}