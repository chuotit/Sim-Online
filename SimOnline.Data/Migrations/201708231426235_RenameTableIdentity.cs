namespace SimOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTableIdentity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IdentityRoles", newName: "AppRoles");
            RenameTable(name: "dbo.IdentityUserRoles", newName: "AppUserRoles");
            RenameTable(name: "dbo.IdentityUserClaims", newName: "AppUserClaims");
            RenameTable(name: "dbo.IdentityUserLogins", newName: "AppUserLogins");
            DropPrimaryKey("dbo.AppUserClaims");
            AlterColumn("dbo.AppUserClaims", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.AppUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.AppUserClaims", "UserId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AppUserClaims");
            AlterColumn("dbo.AppUserClaims", "UserId", c => c.String());
            AlterColumn("dbo.AppUserClaims", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.AppUserClaims", "Id");
            RenameTable(name: "dbo.AppUserLogins", newName: "IdentityUserLogins");
            RenameTable(name: "dbo.AppUserClaims", newName: "IdentityUserClaims");
            RenameTable(name: "dbo.AppUserRoles", newName: "IdentityUserRoles");
            RenameTable(name: "dbo.AppRoles", newName: "IdentityRoles");
        }
    }
}
