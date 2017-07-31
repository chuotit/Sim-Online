namespace SimOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConsignerLevels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ConsignerID = c.Int(nullable: false),
                        Name = c.String(),
                        PriceFrom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceTo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Percent = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 255),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 255),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Consigners", t => t.ConsignerID, cascadeDelete: true)
                .Index(t => t.ConsignerID);
            
            CreateTable(
                "dbo.Consigners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ConsignerCode = c.String(nullable: false, maxLength: 40, unicode: false),
                        Website = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Hotline = c.String(maxLength: 255),
                        Address = c.String(maxLength: 255),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 255),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 255),
                        Status = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FirstNumbers",
                c => new
                    {
                        FirstNumberID = c.String(nullable: false, maxLength: 4, unicode: false),
                        NetworkID = c.Int(nullable: false),
                        FirstNumberName = c.String(nullable: false, maxLength: 255),
                        Description = c.String(storeType: "ntext"),
                        Alias = c.String(nullable: false, maxLength: 255, unicode: false),
                        HomeFlag = c.Boolean(nullable: false),
                        MetaDescription = c.String(maxLength: 255),
                        MetaKeyword = c.String(maxLength: 255),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 255),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 255),
                        Status = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.FirstNumberID)
                .ForeignKey("dbo.SimNetworks", t => t.NetworkID, cascadeDelete: true)
                .Index(t => t.NetworkID);
            
            CreateTable(
                "dbo.SimNetworks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Alias = c.String(nullable: false, maxLength: 255, unicode: false),
                        Image = c.String(),
                        Description = c.String(storeType: "ntext"),
                        HomeFlag = c.Boolean(nullable: false),
                        MetaDescription = c.String(maxLength: 255),
                        MetaKeyword = c.String(maxLength: 255),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 255),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 255),
                        Status = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.SimNumbers",
                c => new
                    {
                        SimID = c.String(nullable: false, maxLength: 25),
                        ID = c.Int(nullable: false, identity: true),
                        SimName = c.String(nullable: false, maxLength: 25),
                        NetWorkID = c.Int(nullable: false),
                        ConsignerID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MetaDescription = c.String(maxLength: 255),
                        MetaKeyword = c.String(maxLength: 255),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 255),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 255),
                        Status = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.SimID)
                .ForeignKey("dbo.Consigners", t => t.ConsignerID, cascadeDelete: true)
                .ForeignKey("dbo.SimNetworks", t => t.NetWorkID, cascadeDelete: true)
                .Index(t => t.NetWorkID)
                .Index(t => t.ConsignerID);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(maxLength: 256),
                        Address = c.String(maxLength: 256),
                        BirthDay = c.DateTime(),
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
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.SimNumbers", "NetWorkID", "dbo.SimNetworks");
            DropForeignKey("dbo.SimNumbers", "ConsignerID", "dbo.Consigners");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.FirstNumbers", "NetworkID", "dbo.SimNetworks");
            DropForeignKey("dbo.ConsignerLevels", "ConsignerID", "dbo.Consigners");
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SimNumbers", new[] { "ConsignerID" });
            DropIndex("dbo.SimNumbers", new[] { "NetWorkID" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.FirstNumbers", new[] { "NetworkID" });
            DropIndex("dbo.ConsignerLevels", new[] { "ConsignerID" });
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.SimNumbers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.SimNetworks");
            DropTable("dbo.FirstNumbers");
            DropTable("dbo.Errors");
            DropTable("dbo.Consigners");
            DropTable("dbo.ConsignerLevels");
        }
    }
}
