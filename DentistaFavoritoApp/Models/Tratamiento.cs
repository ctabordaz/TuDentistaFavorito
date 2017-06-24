using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistaFavoritoApp.Models
{
    public class Tratamiento
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaConclusion { get; set; }
        public double Costo { get; set; }
        public string Detalle { get; set; }
        
        
        public virtual Paciente Paciente { get; set; }
    }
}