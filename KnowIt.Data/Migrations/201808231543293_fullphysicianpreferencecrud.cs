namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fullphysicianpreferencecrud : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhysicianPreference", "MedicationID", c => c.Int(nullable: false));
            AddColumn("dbo.PhysicianPreference", "EquipmentID", c => c.Int(nullable: false));
            AddColumn("dbo.PhysicianPreference", "PreferenceNote", c => c.String());
            CreateIndex("dbo.PhysicianPreference", "MedicationID");
            CreateIndex("dbo.PhysicianPreference", "EquipmentID");
            AddForeignKey("dbo.PhysicianPreference", "EquipmentID", "dbo.Equipment", "EquipmentID", cascadeDelete: true);
            AddForeignKey("dbo.PhysicianPreference", "MedicationID", "dbo.Medication", "MedicationID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhysicianPreference", "MedicationID", "dbo.Medication");
            DropForeignKey("dbo.PhysicianPreference", "EquipmentID", "dbo.Equipment");
            DropIndex("dbo.PhysicianPreference", new[] { "EquipmentID" });
            DropIndex("dbo.PhysicianPreference", new[] { "MedicationID" });
            DropColumn("dbo.PhysicianPreference", "PreferenceNote");
            DropColumn("dbo.PhysicianPreference", "EquipmentID");
            DropColumn("dbo.PhysicianPreference", "MedicationID");
        }
    }
}
