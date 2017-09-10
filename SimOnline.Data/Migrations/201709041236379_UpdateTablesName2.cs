namespace SimOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTablesName2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SimNumbers", newName: "SimStores");
            RenameColumn(table: "dbo.AgentLevels", name: "ConsignerID", newName: "AgentID");
            RenameColumn(table: "dbo.SimStores", name: "ConsignerID", newName: "AgentID");
            RenameIndex(table: "dbo.AgentLevels", name: "IX_ConsignerID", newName: "IX_AgentID");
            RenameIndex(table: "dbo.SimStores", name: "IX_ConsignerID", newName: "IX_AgentID");
            AddColumn("dbo.Agents", "AgentCode", c => c.String(nullable: false, maxLength: 40, unicode: false));
            DropColumn("dbo.Agents", "ConsignerCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agents", "ConsignerCode", c => c.String(nullable: false, maxLength: 40, unicode: false));
            DropColumn("dbo.Agents", "AgentCode");
            RenameIndex(table: "dbo.SimStores", name: "IX_AgentID", newName: "IX_ConsignerID");
            RenameIndex(table: "dbo.AgentLevels", name: "IX_AgentID", newName: "IX_ConsignerID");
            RenameColumn(table: "dbo.SimStores", name: "AgentID", newName: "ConsignerID");
            RenameColumn(table: "dbo.AgentLevels", name: "AgentID", newName: "ConsignerID");
            RenameTable(name: "dbo.SimStores", newName: "SimNumbers");
        }
    }
}
