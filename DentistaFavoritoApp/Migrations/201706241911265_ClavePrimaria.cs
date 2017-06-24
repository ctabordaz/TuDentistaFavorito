namespace DentistaFavoritoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClavePrimaria : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tratamiento", "Paciente_Id", "dbo.Paciente");
            DropIndex("dbo.Tratamiento", new[] { "Paciente_Id" });
            AlterColumn("dbo.Tratamiento", "Paciente_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tratamiento", "Paciente_Id");
            AddForeignKey("dbo.Tratamiento", "Paciente_Id", "dbo.Paciente", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tratamiento", "Paciente_Id", "dbo.Paciente");
            DropIndex("dbo.Tratamiento", new[] { "Paciente_Id" });
            AlterColumn("dbo.Tratamiento", "Paciente_Id", c => c.Int());
            CreateIndex("dbo.Tratamiento", "Paciente_Id");
            AddForeignKey("dbo.Tratamiento", "Paciente_Id", "dbo.Paciente", "Id");
        }
    }
}
