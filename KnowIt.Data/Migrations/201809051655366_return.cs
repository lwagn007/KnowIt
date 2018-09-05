namespace KnowIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _return : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        EquipmentID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        EquipmentName = c.String(nullable: false),
                        EquipmentNote = c.String(nullable: false),
                        PhysicianPreference_PhysicianPreferenceID = c.Int(),
                    })
                .PrimaryKey(t => t.EquipmentID)
                .ForeignKey("dbo.PhysicianPreference", t => t.PhysicianPreference_PhysicianPreferenceID)
                .Index(t => t.PhysicianPreference_PhysicianPreferenceID);
            
            CreateTable(
                "dbo.PhysicianPreference",
                c => new
                    {
                        PhysicianPreferenceID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        PhysicianID = c.Int(nullable: false),
                        ProcedureID = c.Int(nullable: false),
                        MedicationID = c.Int(nullable: false),
                        EquipmentID = c.Int(nullable: false),
                        PreferenceNote = c.String(),
                        Equipment_EquipmentID = c.Int(),
                        Medication_MedicationID = c.Int(),
                        Medication_MedicationID1 = c.Int(),
                        PhysicianPreference_PhysicianPreferenceID = c.Int(),
                        Procedure_ProcedureID = c.Int(),
                        Equipment_EquipmentID1 = c.Int(),
                    })
                .PrimaryKey(t => t.PhysicianPreferenceID)
                .ForeignKey("dbo.Equipment", t => t.Equipment_EquipmentID)
                .ForeignKey("dbo.Medication", t => t.Medication_MedicationID)
                .ForeignKey("dbo.Medication", t => t.Medication_MedicationID1)
                .ForeignKey("dbo.Physician", t => t.PhysicianID, cascadeDelete: true)
                .ForeignKey("dbo.PhysicianPreference", t => t.PhysicianPreference_PhysicianPreferenceID)
                .ForeignKey("dbo.Procedure", t => t.Procedure_ProcedureID)
                .ForeignKey("dbo.Equipment", t => t.Equipment_EquipmentID1)
                .Index(t => t.PhysicianID)
                .Index(t => t.Equipment_EquipmentID)
                .Index(t => t.Medication_MedicationID)
                .Index(t => t.Medication_MedicationID1)
                .Index(t => t.PhysicianPreference_PhysicianPreferenceID)
                .Index(t => t.Procedure_ProcedureID)
                .Index(t => t.Equipment_EquipmentID1);
            
            CreateTable(
                "dbo.Medication",
                c => new
                    {
                        MedicationID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        MedicationName = c.String(),
                        MedicationClass = c.String(),
                        MedicationUse = c.String(),
                        Assigned = c.Boolean(nullable: false),
                        PhysicianPreference_PhysicianPreferenceID = c.Int(),
                    })
                .PrimaryKey(t => t.MedicationID)
                .ForeignKey("dbo.PhysicianPreference", t => t.PhysicianPreference_PhysicianPreferenceID)
                .Index(t => t.PhysicianPreference_PhysicianPreferenceID);
            
            CreateTable(
                "dbo.Physician",
                c => new
                    {
                        PhysicianID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        PhysicianFirstName = c.String(),
                        PhysicianLastName = c.String(),
                        Specialty = c.String(),
                    })
                .PrimaryKey(t => t.PhysicianID);
            
            CreateTable(
                "dbo.Procedure",
                c => new
                    {
                        ProcedureID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        ProcedureName = c.String(),
                        ProcedureNote = c.String(),
                        ProcedureRoute = c.String(),
                        PhysicianPreference_PhysicianPreferenceID = c.Int(),
                    })
                .PrimaryKey(t => t.ProcedureID)
                .ForeignKey("dbo.PhysicianPreference", t => t.PhysicianPreference_PhysicianPreferenceID)
                .Index(t => t.PhysicianPreference_PhysicianPreferenceID);
            
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
            DropForeignKey("dbo.PhysicianPreference", "Equipment_EquipmentID1", "dbo.Equipment");
            DropForeignKey("dbo.Procedure", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference");
            DropForeignKey("dbo.PhysicianPreference", "Procedure_ProcedureID", "dbo.Procedure");
            DropForeignKey("dbo.PhysicianPreference", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference");
            DropForeignKey("dbo.PhysicianPreference", "PhysicianID", "dbo.Physician");
            DropForeignKey("dbo.Medication", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference");
            DropForeignKey("dbo.PhysicianPreference", "Medication_MedicationID1", "dbo.Medication");
            DropForeignKey("dbo.PhysicianPreference", "Medication_MedicationID", "dbo.Medication");
            DropForeignKey("dbo.Equipment", "PhysicianPreference_PhysicianPreferenceID", "dbo.PhysicianPreference");
            DropForeignKey("dbo.PhysicianPreference", "Equipment_EquipmentID", "dbo.Equipment");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Procedure", new[] { "PhysicianPreference_PhysicianPreferenceID" });
            DropIndex("dbo.Medication", new[] { "PhysicianPreference_PhysicianPreferenceID" });
            DropIndex("dbo.PhysicianPreference", new[] { "Equipment_EquipmentID1" });
            DropIndex("dbo.PhysicianPreference", new[] { "Procedure_ProcedureID" });
            DropIndex("dbo.PhysicianPreference", new[] { "PhysicianPreference_PhysicianPreferenceID" });
            DropIndex("dbo.PhysicianPreference", new[] { "Medication_MedicationID1" });
            DropIndex("dbo.PhysicianPreference", new[] { "Medication_MedicationID" });
            DropIndex("dbo.PhysicianPreference", new[] { "Equipment_EquipmentID" });
            DropIndex("dbo.PhysicianPreference", new[] { "PhysicianID" });
            DropIndex("dbo.Equipment", new[] { "PhysicianPreference_PhysicianPreferenceID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Procedure");
            DropTable("dbo.Physician");
            DropTable("dbo.Medication");
            DropTable("dbo.PhysicianPreference");
            DropTable("dbo.Equipment");
        }
    }
}
