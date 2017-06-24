using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentistaFavoritoApp.Entity
{
    public class DentistaInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<DentistaContext>
    {
        public override void InitializeDatabase(DentistaContext context)
        {
            base.InitializeDatabase(context);
        }
    }
}