namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PhysicianPreference", "PhysicianLastName");
            DropColumn("dbo.PhysicianPreference", "PhysicianFirstName");
            DropColumn("dbo.PhysicianPreference", "Specialty");
            DropColumn("dbo.PhysicianPreference", "ProcedureName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhysicianPreference", "ProcedureName", c => c.String());
            AddColumn("dbo.PhysicianPreference", "Specialty", c => c.String());
            AddColumn("dbo.PhysicianPreference", "PhysicianFirstName", c => c.String());
            AddColumn("dbo.PhysicianPreference", "PhysicianLastName", c => c.String());
        }
    }
}
