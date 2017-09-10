namespace SimOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForeignKeyAgentAppUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUsers", "AgentID", c => c.Int());
            CreateIndex("dbo.AppUsers", "AgentID");
            AddForeignKey("dbo.AppUsers", "AgentID", "dbo.Agents", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUsers", "AgentID", "dbo.Agents");
            DropIndex("dbo.AppUsers", new[] { "AgentID" });
            DropColumn("dbo.AppUsers", "AgentID");
        }
    }
}
