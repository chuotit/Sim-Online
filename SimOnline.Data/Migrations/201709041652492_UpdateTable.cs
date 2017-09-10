namespace SimOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agents", "AgentCode", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Agents", "AgentCode", c => c.String(nullable: false, maxLength: 40, unicode: false));
        }
    }
}
