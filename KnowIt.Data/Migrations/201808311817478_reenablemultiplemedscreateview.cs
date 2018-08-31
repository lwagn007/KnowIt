namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reenablemultiplemedscreateview : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhysicianPreference", "MedicationID", "dbo.Medication");
            DropIndex("dbo.PhysicianPreference", new[] { "MedicationID" });
            AddColumn("dbo.PhysicianPreference", "Medication_MedicationID", c => c.Int());
            AddColumn("dbo.PhysicianPreference", "Medication_MedicationID1", c => c.Int());
            AddColumn("dbo.PhysicianPreference", "PhysicianPreference_PhysicianPreferenceID", c => c.Int());
            AddColumn("dbo.Medication", "PhysicianPreference_PhysicianPreferenceID", c => c.Int());
            CreateIndex("dbo.PhysicianPreference", "Medication_MedicationID");
            CreateIndex("dbo.PhysicianPreference", "Medication_MedicationID1");
            CreateIndex("dbo.PhysicianPreference", "PhysicianPreference_PhysicianPreferenceID");
            CreateIndex("dbo.Medication", "PhysicianPreference_PhysicianPreferenceID");
            AddForeignKey("dbo.Medication", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference", "PhysicianPreferenceID");
            AddForeignKey("dbo.PhysicianPreference", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference", "PhysicianPreferenceID");
            AddForeignKey("dbo.PhysicianPreference", "Medication_MedicationID1", "dbo.Medication", "MedicationID");
            AddForeignKey("dbo.PhysicianPreference", "Medication_MedicationID", "dbo.Medication", "MedicationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhysicianPreference", "Medication_MedicationID", "dbo.Medication");
            DropForeignKey("dbo.PhysicianPreference", "Medication_MedicationID1", "dbo.Medication");
            DropForeignKey("dbo.PhysicianPreference", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference");
            DropForeignKey("dbo.Medication", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference");
            DropIndex("dbo.Medication", new[] { "PhysicianPreference_PhysicianPreferenceID" });
            DropIndex("dbo.PhysicianPreference", new[] { "PhysicianPreference_PhysicianPreferenceID" });
            DropIndex("dbo.PhysicianPreference", new[] { "Medication_MedicationID1" });
            DropIndex("dbo.PhysicianPreference", new[] { "Medication_MedicationID" });
            DropColumn("dbo.Medication", "PhysicianPreference_PhysicianPreferenceID");
            DropColumn("dbo.PhysicianPreference", "PhysicianPreference_PhysicianPreferenceID");
            DropColumn("dbo.PhysicianPreference", "Medication_MedicationID1");
            DropColumn("dbo.PhysicianPreference", "Medication_MedicationID");
            CreateIndex("dbo.PhysicianPreference", "MedicationID");
            AddForeignKey("dbo.PhysicianPreference", "MedicationID", "dbo.Medication", "MedicationID", cascadeDelete: true);
        }
    }
}
