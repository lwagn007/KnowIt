namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class multipleequipment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhysicianPreference", "EquipmentID", "dbo.Equipment");
            DropIndex("dbo.PhysicianPreference", new[] { "EquipmentID" });
            AddColumn("dbo.Equipment", "PhysicianPreference_PhysicianPreferenceID", c => c.Int());
            AddColumn("dbo.PhysicianPreference", "Equipment_EquipmentID", c => c.Int());
            AddColumn("dbo.PhysicianPreference", "Equipment_EquipmentID1", c => c.Int());
            CreateIndex("dbo.Equipment", "PhysicianPreference_PhysicianPreferenceID");
            CreateIndex("dbo.PhysicianPreference", "Equipment_EquipmentID");
            CreateIndex("dbo.PhysicianPreference", "Equipment_EquipmentID1");
            AddForeignKey("dbo.Equipment", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference", "PhysicianPreferenceID");
            AddForeignKey("dbo.PhysicianPreference", "Equipment_EquipmentID1", "dbo.Equipment", "EquipmentID");
            AddForeignKey("dbo.PhysicianPreference", "Equipment_EquipmentID", "dbo.Equipment", "EquipmentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhysicianPreference", "Equipment_EquipmentID", "dbo.Equipment");
            DropForeignKey("dbo.PhysicianPreference", "Equipment_EquipmentID1", "dbo.Equipment");
            DropForeignKey("dbo.Equipment", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference");
            DropIndex("dbo.PhysicianPreference", new[] { "Equipment_EquipmentID1" });
            DropIndex("dbo.PhysicianPreference", new[] { "Equipment_EquipmentID" });
            DropIndex("dbo.Equipment", new[] { "PhysicianPreference_PhysicianPreferenceID" });
            DropColumn("dbo.PhysicianPreference", "Equipment_EquipmentID1");
            DropColumn("dbo.PhysicianPreference", "Equipment_EquipmentID");
            DropColumn("dbo.Equipment", "PhysicianPreference_PhysicianPreferenceID");
            CreateIndex("dbo.PhysicianPreference", "EquipmentID");
            AddForeignKey("dbo.PhysicianPreference", "EquipmentID", "dbo.Equipment", "EquipmentID", cascadeDelete: true);
        }
    }
}
