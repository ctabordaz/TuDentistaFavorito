using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentistaFavoritoApp.Entity
{
    /// <summary>
    /// Inicializador de base de datos
    /// Crea o actualiza la base de datos
    /// </summary>
    public class DentistaInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<DentistaContext>
    {

        /// <summary>
        /// Ejecuta las tareas para inicializar la base de datos
        /// como el seed
        /// </summary>
        /// <param name="context">contexto de la base de datos</param>
        public override void InitializeDatabase(DentistaContext context)
        {
            base.InitializeDatabase(context);
        }
    }
}