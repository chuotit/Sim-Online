namespace SimOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableProperties : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SimNumbers", "ID");
            DropColumn("dbo.SimNumbers", "MetaDescription");
            DropColumn("dbo.SimNumbers", "MetaKeyword");
            DropColumn("dbo.SimNumbers", "CreateBy");
            DropColumn("dbo.SimNumbers", "UpdateBy");
            DropColumn("dbo.SimNumbers", "DisplayOrder");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SimNumbers", "DisplayOrder", c => c.Int());
            AddColumn("dbo.SimNumbers", "UpdateBy", c => c.String(maxLength: 255));
            AddColumn("dbo.SimNumbers", "CreateBy", c => c.String(maxLength: 255));
            AddColumn("dbo.SimNumbers", "MetaKeyword", c => c.String(maxLength: 255));
            AddColumn("dbo.SimNumbers", "MetaDescription", c => c.String(maxLength: 255));
            AddColumn("dbo.SimNumbers", "ID", c => c.Int(nullable: false, identity: true));
        }
    }
}
