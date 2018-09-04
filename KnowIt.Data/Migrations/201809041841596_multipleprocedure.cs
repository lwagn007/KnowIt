namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class multipleprocedure : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhysicianPreference", "ProcedureID", "dbo.Procedure");
            DropIndex("dbo.PhysicianPreference", new[] { "ProcedureID" });
            AddColumn("dbo.PhysicianPreference", "Procedure_ProcedureID", c => c.Int());
            AddColumn("dbo.Procedure", "PhysicianPreference_PhysicianPreferenceID", c => c.Int());
            CreateIndex("dbo.PhysicianPreference", "Procedure_ProcedureID");
            CreateIndex("dbo.Procedure", "PhysicianPreference_PhysicianPreferenceID");
            AddForeignKey("dbo.Procedure", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference", "PhysicianPreferenceID");
            AddForeignKey("dbo.PhysicianPreference", "Procedure_ProcedureID", "dbo.Procedure", "ProcedureID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhysicianPreference", "Procedure_ProcedureID", "dbo.Procedure");
            DropForeignKey("dbo.Procedure", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference");
            DropIndex("dbo.Procedure", new[] { "PhysicianPreference_PhysicianPreferenceID" });
            DropIndex("dbo.PhysicianPreference", new[] { "Procedure_ProcedureID" });
            DropColumn("dbo.Procedure", "PhysicianPreference_PhysicianPreferenceID");
            DropColumn("dbo.PhysicianPreference", "Procedure_ProcedureID");
            CreateIndex("dbo.PhysicianPreference", "ProcedureID");
            AddForeignKey("dbo.PhysicianPreference", "ProcedureID", "dbo.Procedure", "ProcedureID", cascadeDelete: true);
        }
    }
}
