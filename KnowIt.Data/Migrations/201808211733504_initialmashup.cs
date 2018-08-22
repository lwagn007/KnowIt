namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmashup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MashUp",
                c => new
                    {
                        MashUpID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        PhysicianID = c.Int(nullable: false),
                        ProcedureID = c.Int(nullable: false),
                        EquipmentID = c.Int(nullable: false),
                        MedicationID = c.Int(nullable: false),
                        MashUpNote = c.String(),
                    })
                .PrimaryKey(t => t.MashUpID);
            
            AddColumn("dbo.Equipment", "MashUp_MashUpID", c => c.Int());
            AddColumn("dbo.Medication", "MashUp_MashUpID", c => c.Int());
            AddColumn("dbo.Physician", "MashUp_MashUpID", c => c.Int());
            AddColumn("dbo.Procedure", "MashUp_MashUpID", c => c.Int());
            CreateIndex("dbo.Equipment", "MashUp_MashUpID");
            CreateIndex("dbo.Medication", "MashUp_MashUpID");
            CreateIndex("dbo.Physician", "MashUp_MashUpID");
            CreateIndex("dbo.Procedure", "MashUp_MashUpID");
            AddForeignKey("dbo.Equipment", "MashUp_MashUpID", "dbo.MashUp", "MashUpID");
            AddForeignKey("dbo.Medication", "MashUp_MashUpID", "dbo.MashUp", "MashUpID");
            AddForeignKey("dbo.Physician", "MashUp_MashUpID", "dbo.MashUp", "MashUpID");
            AddForeignKey("dbo.Procedure", "MashUp_MashUpID", "dbo.MashUp", "MashUpID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Procedure", "MashUp_MashUpID", "dbo.MashUp");
            DropForeignKey("dbo.Physician", "MashUp_MashUpID", "dbo.MashUp");
            DropForeignKey("dbo.Medication", "MashUp_MashUpID", "dbo.MashUp");
            DropForeignKey("dbo.Equipment", "MashUp_MashUpID", "dbo.MashUp");
            DropIndex("dbo.Procedure", new[] { "MashUp_MashUpID" });
            DropIndex("dbo.Physician", new[] { "MashUp_MashUpID" });
            DropIndex("dbo.Medication", new[] { "MashUp_MashUpID" });
            DropIndex("dbo.Equipment", new[] { "MashUp_MashUpID" });
            DropColumn("dbo.Procedure", "MashUp_MashUpID");
            DropColumn("dbo.Physician", "MashUp_MashUpID");
            DropColumn("dbo.Medication", "MashUp_MashUpID");
            DropColumn("dbo.Equipment", "MashUp_MashUpID");
            DropTable("dbo.MashUp");
        }
    }
}
