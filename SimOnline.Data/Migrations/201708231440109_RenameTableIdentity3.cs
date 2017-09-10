namespace SimOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTableIdentity3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AppUser", newName: "AppUsers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AppUsers", newName: "AppUser");
        }
    }
}
