namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class physicianpreferencecrud : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhysicianPreference",
                c => new
                    {
                        PhysicianPreferenceID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        PhysicianID = c.Int(nullable: false),
                        ProcedureID = c.Int(nullable: false),
                        PhysicianLastName = c.String(),
                        PhysicianFirstName = c.String(),
                        Specialty = c.String(),
                        ProcedureName = c.String(),
                    })
                .PrimaryKey(t => t.PhysicianPreferenceID)
                .ForeignKey("dbo.Physician", t => t.PhysicianID, cascadeDelete: true)
                .ForeignKey("dbo.Procedure", t => t.ProcedureID, cascadeDelete: true)
                .Index(t => t.PhysicianID)
                .Index(t => t.ProcedureID);
            
            DropColumn("dbo.Procedure", "PhysicianID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Procedure", "PhysicianID", c => c.Int(nullable: false));
            DropForeignKey("dbo.PhysicianPreference", "ProcedureID", "dbo.Procedure");
            DropForeignKey("dbo.PhysicianPreference", "PhysicianID", "dbo.Physician");
            DropIndex("dbo.PhysicianPreference", new[] { "ProcedureID" });
            DropIndex("dbo.PhysicianPreference", new[] { "PhysicianID" });
            DropTable("dbo.PhysicianPreference");
        }
    }
}
