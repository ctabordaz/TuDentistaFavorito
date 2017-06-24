namespace DentistaFavoritoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Identificacion = c.String(),
                        Edad = c.Int(nullable: false),
                        DatosContacto = c.String(),
                        UltimaConsulta = c.DateTime(nullable: false),
                        ProximaConsulta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tratamiento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaConclusion = c.DateTime(nullable: false),
                        Costo = c.Double(nullable: false),
                        Detalle = c.String(),
                        Paciente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paciente", t => t.Paciente_Id)
                .Index(t => t.Paciente_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tratamiento", "Paciente_Id", "dbo.Paciente");
            DropIndex("dbo.Tratamiento", new[] { "Paciente_Id" });
            DropTable("dbo.Tratamiento");
            DropTable("dbo.Paciente");
        }
    }
}
