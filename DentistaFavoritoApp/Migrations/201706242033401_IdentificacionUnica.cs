namespace DentistaFavoritoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentificacionUnica : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Paciente", "Identificacion", c => c.Long(nullable: false));
            CreateIndex("dbo.Paciente", "Identificacion", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Paciente", new[] { "Identificacion" });
            AlterColumn("dbo.Paciente", "Identificacion", c => c.String());
        }
    }
}
