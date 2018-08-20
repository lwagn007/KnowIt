namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigrationprocedurecrud : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Equipment", "Procedure_ProcedureID", "dbo.Procedure");
            DropForeignKey("dbo.Medication", "Procedure_ProcedureID", "dbo.Procedure");
            DropForeignKey("dbo.Physician", "Procedure_ProcedureID", "dbo.Procedure");
            DropIndex("dbo.Equipment", new[] { "Procedure_ProcedureID" });
            DropIndex("dbo.Medication", new[] { "Procedure_ProcedureID" });
            DropIndex("dbo.Physician", new[] { "Procedure_ProcedureID" });
            AddColumn("dbo.Procedure", "OwnerID", c => c.Guid(nullable: false));
            AddColumn("dbo.Procedure", "ProcedureNote", c => c.String());
            DropColumn("dbo.Equipment", "Procedure_ProcedureID");
            DropColumn("dbo.Medication", "Procedure_ProcedureID");
            DropColumn("dbo.Physician", "Procedure_ProcedureID");
            DropColumn("dbo.Procedure", "PhysicianID");
            DropColumn("dbo.Procedure", "EquipmentID");
            DropColumn("dbo.Procedure", "MedicationID");
            DropColumn("dbo.Procedure", "ProcedureFocus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Procedure", "ProcedureFocus", c => c.String());
            AddColumn("dbo.Procedure", "MedicationID", c => c.Int(nullable: false));
            AddColumn("dbo.Procedure", "EquipmentID", c => c.Int(nullable: false));
            AddColumn("dbo.Procedure", "PhysicianID", c => c.Int(nullable: false));
            AddColumn("dbo.Physician", "Procedure_ProcedureID", c => c.Int());
            AddColumn("dbo.Medication", "Procedure_ProcedureID", c => c.Int());
            AddColumn("dbo.Equipment", "Procedure_ProcedureID", c => c.Int());
            DropColumn("dbo.Procedure", "ProcedureNote");
            DropColumn("dbo.Procedure", "OwnerID");
            CreateIndex("dbo.Physician", "Procedure_ProcedureID");
            CreateIndex("dbo.Medication", "Procedure_ProcedureID");
            CreateIndex("dbo.Equipment", "Procedure_ProcedureID");
            AddForeignKey("dbo.Physician", "Procedure_ProcedureID", "dbo.Procedure", "ProcedureID");
            AddForeignKey("dbo.Medication", "Procedure_ProcedureID", "dbo.Procedure", "ProcedureID");
            AddForeignKey("dbo.Equipment", "Procedure_ProcedureID", "dbo.Procedure", "ProcedureID");
        }
    }
}
