namespace SimOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableProperties1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SimNumbers");
            AlterColumn("dbo.SimNumbers", "SimID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SimNumbers", "SimID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SimNumbers");
            AlterColumn("dbo.SimNumbers", "SimID", c => c.String(nullable: false, maxLength: 25));
            AddPrimaryKey("dbo.SimNumbers", "SimID");
        }
    }
}
