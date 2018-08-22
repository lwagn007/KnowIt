namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class physicianfk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Procedure", "PhysicianID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Procedure", "PhysicianID");
        }
    }
}
