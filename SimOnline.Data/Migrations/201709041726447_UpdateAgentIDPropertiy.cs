namespace SimOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAgentIDPropertiy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppUsers", "AgentID", "dbo.Agents");
            DropForeignKey("dbo.AgentLevels", "AgentID", "dbo.Agents");
            DropForeignKey("dbo.SimStores", "AgentID", "dbo.Agents");
            DropIndex("dbo.AgentLevels", new[] { "AgentID" });
            DropIndex("dbo.AppUsers", new[] { "AgentID" });
            DropIndex("dbo.SimStores", new[] { "AgentID" });
            DropPrimaryKey("dbo.Agents");
            AddColumn("dbo.Agents", "AgentId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AgentLevels", "AgentID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AppUsers", "AgentID", c => c.String(maxLength: 128));
            AlterColumn("dbo.SimStores", "AgentID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Agents", "AgentId");
            CreateIndex("dbo.AgentLevels", "AgentID");
            CreateIndex("dbo.AppUsers", "AgentID");
            CreateIndex("dbo.SimStores", "AgentID");
            AddForeignKey("dbo.AppUsers", "AgentID", "dbo.Agents", "AgentId");
            AddForeignKey("dbo.AgentLevels", "AgentID", "dbo.Agents", "AgentId", cascadeDelete: true);
            AddForeignKey("dbo.SimStores", "AgentID", "dbo.Agents", "AgentId", cascadeDelete: true);
            DropColumn("dbo.Agents", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agents", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.SimStores", "AgentID", "dbo.Agents");
            DropForeignKey("dbo.AgentLevels", "AgentID", "dbo.Agents");
            DropForeignKey("dbo.AppUsers", "AgentID", "dbo.Agents");
            DropIndex("dbo.SimStores", new[] { "AgentID" });
            DropIndex("dbo.AppUsers", new[] { "AgentID" });
            DropIndex("dbo.AgentLevels", new[] { "AgentID" });
            DropPrimaryKey("dbo.Agents");
            AlterColumn("dbo.SimStores", "AgentID", c => c.Int(nullable: false));
            AlterColumn("dbo.AppUsers", "AgentID", c => c.Int());
            AlterColumn("dbo.AgentLevels", "AgentID", c => c.Int(nullable: false));
            DropColumn("dbo.Agents", "AgentId");
            AddPrimaryKey("dbo.Agents", "ID");
            CreateIndex("dbo.SimStores", "AgentID");
            CreateIndex("dbo.AppUsers", "AgentID");
            CreateIndex("dbo.AgentLevels", "AgentID");
            AddForeignKey("dbo.SimStores", "AgentID", "dbo.Agents", "ID", cascadeDelete: true);
            AddForeignKey("dbo.AgentLevels", "AgentID", "dbo.Agents", "ID", cascadeDelete: true);
            AddForeignKey("dbo.AppUsers", "AgentID", "dbo.Agents", "ID", cascadeDelete: true);
        }
    }
}
