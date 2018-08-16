namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialupdatephysiciancrud : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Physician", "Specialty", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Physician", "Specialty", c => c.Int(nullable: false));
        }
    }
}
