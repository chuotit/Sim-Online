namespace SimOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AppRoleGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GroupId, t.RoleId })
                .ForeignKey("dbo.AppGroups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.AppRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AppUserGroups",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId })
                .ForeignKey("dbo.AppGroups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
            AddColumn("dbo.AppRoles", "Description", c => c.String(maxLength: 250));
            AddColumn("dbo.AppRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUserGroups", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.AppUserGroups", "GroupId", "dbo.AppGroups");
            DropForeignKey("dbo.AppRoleGroups", "RoleId", "dbo.AppRoles");
            DropForeignKey("dbo.AppRoleGroups", "GroupId", "dbo.AppGroups");
            DropIndex("dbo.AppUserGroups", new[] { "GroupId" });
            DropIndex("dbo.AppUserGroups", new[] { "UserId" });
            DropIndex("dbo.AppRoleGroups", new[] { "RoleId" });
            DropIndex("dbo.AppRoleGroups", new[] { "GroupId" });
            DropColumn("dbo.AppRoles", "Discriminator");
            DropColumn("dbo.AppRoles", "Description");
            DropTable("dbo.AppUserGroups");
            DropTable("dbo.AppRoleGroups");
            DropTable("dbo.AppGroups");
        }
    }
}
