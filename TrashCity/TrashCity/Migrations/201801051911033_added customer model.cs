namespace TrashCity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcustomermodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerModels",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerFirstName = c.String(),
                        CustomerLastName = c.String(),
                        CustomerAddress = c.String(),
                        CustomerZip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerModels");
        }
    }
}
