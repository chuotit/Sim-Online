namespace SimOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSimnumberProperties : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SimNumbers");
            AlterColumn("dbo.SimNumbers", "SimID", c => c.String(nullable: false, maxLength: 11, unicode: false));
            AlterColumn("dbo.SimNumbers", "SimName", c => c.String(nullable: false, maxLength: 25, unicode: false));
            AddPrimaryKey("dbo.SimNumbers", "SimID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SimNumbers");
            AlterColumn("dbo.SimNumbers", "SimName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.SimNumbers", "SimID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SimNumbers", "SimID");
        }
    }
}
