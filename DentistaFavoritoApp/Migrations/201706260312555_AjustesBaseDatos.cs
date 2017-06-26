namespace DentistaFavoritoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustesBaseDatos : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Paciente", new[] { "Identificacion" });
            AlterColumn("dbo.Paciente", "Nombre", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Paciente", "DatosContacto", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Tratamiento", "Detalle", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tratamiento", "Detalle", c => c.String());
            AlterColumn("dbo.Paciente", "DatosContacto", c => c.String());
            AlterColumn("dbo.Paciente", "Nombre", c => c.String());
            CreateIndex("dbo.Paciente", "Identificacion", unique: true);
        }
    }
}
