namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class progressindexmultiplemeds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhysicianPreference", "Medication_MedicationID", "dbo.Medication");
            AddColumn("dbo.PhysicianPreference", "Medication_MedicationID1", c => c.Int());
            AddColumn("dbo.PhysicianPreference", "PhysicianPreference_PhysicianPreferenceID", c => c.Int());
            AddColumn("dbo.PhysicianPreference", "Equipment_EquipmentID1", c => c.Int());
            CreateIndex("dbo.PhysicianPreference", "Medication_MedicationID1");
            CreateIndex("dbo.PhysicianPreference", "PhysicianPreference_PhysicianPreferenceID");
            CreateIndex("dbo.PhysicianPreference", "Equipment_EquipmentID1");
            AddForeignKey("dbo.PhysicianPreference", "Medication_MedicationID", "dbo.Medication", "MedicationID");
            AddForeignKey("dbo.PhysicianPreference", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference", "PhysicianPreferenceID");
            AddForeignKey("dbo.PhysicianPreference", "Equipment_EquipmentID1", "dbo.Equipment", "EquipmentID");
            AddForeignKey("dbo.PhysicianPreference", "Medication_MedicationID1", "dbo.Medication", "MedicationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhysicianPreference", "Medication_MedicationID1", "dbo.Medication");
            DropForeignKey("dbo.PhysicianPreference", "Equipment_EquipmentID1", "dbo.Equipment");
            DropForeignKey("dbo.PhysicianPreference", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference");
            DropForeignKey("dbo.PhysicianPreference", "Medication_MedicationID", "dbo.Medication");
            DropIndex("dbo.PhysicianPreference", new[] { "Equipment_EquipmentID1" });
            DropIndex("dbo.PhysicianPreference", new[] { "PhysicianPreference_PhysicianPreferenceID" });
            DropIndex("dbo.PhysicianPreference", new[] { "Medication_MedicationID1" });
            DropColumn("dbo.PhysicianPreference", "Equipment_EquipmentID1");
            DropColumn("dbo.PhysicianPreference", "PhysicianPreference_PhysicianPreferenceID");
            DropColumn("dbo.PhysicianPreference", "Medication_MedicationID1");
            AddForeignKey("dbo.PhysicianPreference", "Medication_MedicationID", "dbo.Medication", "MedicationID");
        }
    }
}
