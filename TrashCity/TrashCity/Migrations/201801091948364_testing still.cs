namespace TrashCity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingstill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduleManagers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        dateToChange = c.DateTime(nullable: false),
                        tempCollectionDay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.CustomerModels", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleManagers", "CustomerId", "dbo.CustomerModels");
            DropIndex("dbo.ScheduleManagers", new[] { "CustomerId" });
            DropTable("dbo.ScheduleManagers");
        }
    }
}
