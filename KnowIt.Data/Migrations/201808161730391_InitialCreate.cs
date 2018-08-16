namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        EquipmentID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        EquipmentNote = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        Procedure_ProcedureID = c.Int(),
                    })
                .PrimaryKey(t => t.EquipmentID)
                .ForeignKey("dbo.Procedure", t => t.Procedure_ProcedureID)
                .Index(t => t.Procedure_ProcedureID);
            
            CreateTable(
                "dbo.Medication",
                c => new
                    {
                        MedicationID = c.Int(nullable: false, identity: true),
                        MedicationName = c.String(),
                        MedicationList = c.String(),
                        Procedure_ProcedureID = c.Int(),
                    })
                .PrimaryKey(t => t.MedicationID)
                .ForeignKey("dbo.Procedure", t => t.Procedure_ProcedureID)
                .Index(t => t.Procedure_ProcedureID);
            
            CreateTable(
                "dbo.Physician",
                c => new
                    {
                        PhysicianID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        PhysicianFirstName = c.String(),
                        PhysicianLastName = c.String(),
                        Specialty = c.Int(nullable: false),
                        Procedure_ProcedureID = c.Int(),
                    })
                .PrimaryKey(t => t.PhysicianID)
                .ForeignKey("dbo.Procedure", t => t.Procedure_ProcedureID)
                .Index(t => t.Procedure_ProcedureID);
            
            CreateTable(
                "dbo.Procedure",
                c => new
                    {
                        ProcedureID = c.Int(nullable: false, identity: true),
                        PhysicianID = c.Int(nullable: false),
                        EquipmentID = c.Int(nullable: false),
                        MedicationID = c.Int(nullable: false),
                        ProcedureName = c.String(),
                        ProcedureFocus = c.String(),
                        ProcedureRoute = c.String(),
                    })
                .PrimaryKey(t => t.ProcedureID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Physician", "Procedure_ProcedureID", "dbo.Procedure");
            DropForeignKey("dbo.Medication", "Procedure_ProcedureID", "dbo.Procedure");
            DropForeignKey("dbo.Equipment", "Procedure_ProcedureID", "dbo.Procedure");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Physician", new[] { "Procedure_ProcedureID" });
            DropIndex("dbo.Medication", new[] { "Procedure_ProcedureID" });
            DropIndex("dbo.Equipment", new[] { "Procedure_ProcedureID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Procedure");
            DropTable("dbo.Physician");
            DropTable("dbo.Medication");
            DropTable("dbo.Equipment");
        }
    }
}
