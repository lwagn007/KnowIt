namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medication", "OwnerID", c => c.Guid(nullable: false));
            DropColumn("dbo.Medication", "MedicationName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medication", "MedicationName", c => c.String());
            DropColumn("dbo.Medication", "OwnerID");
        }
    }
}
