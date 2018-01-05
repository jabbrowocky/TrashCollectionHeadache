namespace TrashCity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedacouplepropstocustomermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "AmountOwed", c => c.Double(nullable: false));
            AddColumn("dbo.CustomerModels", "CollectionDay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerModels", "CollectionDay");
            DropColumn("dbo.CustomerModels", "AmountOwed");
        }
    }
}
