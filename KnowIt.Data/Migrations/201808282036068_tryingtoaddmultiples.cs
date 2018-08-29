namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingtoaddmultiples : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhysicianPreference", "EquipmentID", "dbo.Equipment");
            DropForeignKey("dbo.PhysicianPreference", "MedicationID", "dbo.Medication");
            DropIndex("dbo.PhysicianPreference", new[] { "MedicationID" });
            DropIndex("dbo.PhysicianPreference", new[] { "EquipmentID" });
            AddColumn("dbo.Equipment", "PhysicianPreference_PhysicianPreferenceID", c => c.Int());
            AddColumn("dbo.Medication", "PhysicianPreference_PhysicianPreferenceID", c => c.Int());
            AddColumn("dbo.PhysicianPreference", "Equipment_EquipmentID", c => c.Int());
            AddColumn("dbo.PhysicianPreference", "Medication_MedicationID", c => c.Int());
            CreateIndex("dbo.Equipment", "PhysicianPreference_PhysicianPreferenceID");
            CreateIndex("dbo.Medication", "PhysicianPreference_PhysicianPreferenceID");
            CreateIndex("dbo.PhysicianPreference", "Equipment_EquipmentID");
            CreateIndex("dbo.PhysicianPreference", "Medication_MedicationID");
            AddForeignKey("dbo.Equipment", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference", "PhysicianPreferenceID");
            AddForeignKey("dbo.Medication", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference", "PhysicianPreferenceID");
            AddForeignKey("dbo.PhysicianPreference", "Equipment_EquipmentID", "dbo.Equipment", "EquipmentID");
            AddForeignKey("dbo.PhysicianPreference", "Medication_MedicationID", "dbo.Medication", "MedicationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhysicianPreference", "Medication_MedicationID", "dbo.Medication");
            DropForeignKey("dbo.PhysicianPreference", "Equipment_EquipmentID", "dbo.Equipment");
            DropForeignKey("dbo.Medication", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference");
            DropForeignKey("dbo.Equipment", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference");
            DropIndex("dbo.PhysicianPreference", new[] { "Medication_MedicationID" });
            DropIndex("dbo.PhysicianPreference", new[] { "Equipment_EquipmentID" });
            DropIndex("dbo.Medication", new[] { "PhysicianPreference_PhysicianPreferenceID" });
            DropIndex("dbo.Equipment", new[] { "PhysicianPreference_PhysicianPreferenceID" });
            DropColumn("dbo.PhysicianPreference", "Medication_MedicationID");
            DropColumn("dbo.PhysicianPreference", "Equipment_EquipmentID");
            DropColumn("dbo.Medication", "PhysicianPreference_PhysicianPreferenceID");
            DropColumn("dbo.Equipment", "PhysicianPreference_PhysicianPreferenceID");
            CreateIndex("dbo.PhysicianPreference", "EquipmentID");
            CreateIndex("dbo.PhysicianPreference", "MedicationID");
            AddForeignKey("dbo.PhysicianPreference", "MedicationID", "dbo.Medication", "MedicationID", cascadeDelete: true);
            AddForeignKey("dbo.PhysicianPreference", "EquipmentID", "dbo.Equipment", "EquipmentID", cascadeDelete: true);
        }
    }
}
