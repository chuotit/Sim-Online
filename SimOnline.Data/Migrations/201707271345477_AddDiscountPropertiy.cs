namespace SimOnline.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiscountPropertiy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SimNumbers", "Discount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SimNumbers", "Discount");
        }
    }
}
