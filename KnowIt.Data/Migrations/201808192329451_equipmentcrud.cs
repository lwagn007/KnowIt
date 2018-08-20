namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class equipmentcrud : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipment", "EquipmentNote", c => c.String(nullable: false));
            DropColumn("dbo.Equipment", "CreatedUtc");
            DropColumn("dbo.Equipment", "ModifiedUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Equipment", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Equipment", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Equipment", "EquipmentNote");
        }
    }
}
