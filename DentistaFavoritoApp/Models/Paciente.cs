using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentistaFavoritoApp.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public int Edad { get; set; }
        public string DatosContacto { get; set; }
        public DateTime UltimaConsulta { get; set; }
        public DateTime ProximaConsulta { get; set; }

        public ICollection<Tratamiento> Tratamientos { get; set; }
    }
}