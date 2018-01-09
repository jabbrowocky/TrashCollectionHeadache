namespace TrashCity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madepickupdaydefaulttonull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerModels", "CollectionDay", c => c.Int());
            AlterColumn("dbo.ScheduleManagers", "tempCollectionDay", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ScheduleManagers", "tempCollectionDay", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerModels", "CollectionDay", c => c.Int(nullable: false));
        }
    }
}
