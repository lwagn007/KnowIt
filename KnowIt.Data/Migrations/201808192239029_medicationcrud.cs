namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class medicationcrud : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipment", "EquipmentName", c => c.String(nullable: false));
            AddColumn("dbo.Medication", "MedicationName", c => c.String());
            AddColumn("dbo.Medication", "MedicationClass", c => c.String());
            AddColumn("dbo.Medication", "MedicationUse", c => c.String());
            DropColumn("dbo.Equipment", "EquipmentNote");
            DropColumn("dbo.Medication", "MedicationList");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medication", "MedicationList", c => c.String());
            AddColumn("dbo.Equipment", "EquipmentNote", c => c.String(nullable: false));
            DropColumn("dbo.Medication", "MedicationUse");
            DropColumn("dbo.Medication", "MedicationClass");
            DropColumn("dbo.Medication", "MedicationName");
            DropColumn("dbo.Equipment", "EquipmentName");
        }
    }
}
