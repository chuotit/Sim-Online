namespace SimOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTableIdentity2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUsers", newName: "AppUser");
            RenameColumn(table: "dbo.AppUserClaims", name: "ApplicationUser_Id", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.AppUserLogins", name: "ApplicationUser_Id", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.AppUserRoles", name: "ApplicationUser_Id", newName: "IdentityUser_Id");
            RenameIndex(table: "dbo.AppUserRoles", name: "IX_ApplicationUser_Id", newName: "IX_IdentityUser_Id");
            RenameIndex(table: "dbo.AppUserClaims", name: "IX_ApplicationUser_Id", newName: "IX_IdentityUser_Id");
            RenameIndex(table: "dbo.AppUserLogins", name: "IX_ApplicationUser_Id", newName: "IX_IdentityUser_Id");
            AddColumn("dbo.AppUser", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppUser", "Discriminator");
            RenameIndex(table: "dbo.AppUserLogins", name: "IX_IdentityUser_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.AppUserClaims", name: "IX_IdentityUser_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.AppUserRoles", name: "IX_IdentityUser_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.AppUserRoles", name: "IdentityUser_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.AppUserLogins", name: "IdentityUser_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.AppUserClaims", name: "IdentityUser_Id", newName: "ApplicationUser_Id");
            RenameTable(name: "dbo.AppUser", newName: "ApplicationUsers");
        }
    }
}
