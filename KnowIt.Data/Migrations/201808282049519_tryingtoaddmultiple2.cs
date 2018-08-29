namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingtoaddmultiple2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhysicianPreference", "Assigned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhysicianPreference", "Assigned");
        }
    }
}
