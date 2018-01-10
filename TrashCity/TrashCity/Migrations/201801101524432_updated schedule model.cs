namespace TrashCity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedschedulemodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ScheduleManagers", "temporaryCollectionDay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ScheduleManagers", "temporaryCollectionDay", c => c.Int());
        }
    }
}
