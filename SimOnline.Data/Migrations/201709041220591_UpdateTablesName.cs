namespace SimOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTablesName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ConsignerLevels", newName: "AgentLevels");
            RenameTable(name: "dbo.Consigners", newName: "Agents");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Agents", newName: "Consigners");
            RenameTable(name: "dbo.AgentLevels", newName: "ConsignerLevels");
        }
    }
}
