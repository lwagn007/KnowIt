namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuffmultiple : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhysicianPreference", "MedicationName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhysicianPreference", "MedicationName");
        }
    }
}
