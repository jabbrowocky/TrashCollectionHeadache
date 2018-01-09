namespace TrashCity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedscheduler : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ScheduleManagers", "CustomerId", "dbo.CustomerModels");
            DropPrimaryKey("dbo.ScheduleManagers");
            AddColumn("dbo.ScheduleManagers", "changeId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ScheduleManagers", "temporaryCollectionDay", c => c.Int());
            AddPrimaryKey("dbo.ScheduleManagers", "changeId");
            AddForeignKey("dbo.ScheduleManagers", "CustomerId", "dbo.CustomerModels", "CustomerId", cascadeDelete: true);
            DropColumn("dbo.ScheduleManagers", "tempCollectionDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ScheduleManagers", "tempCollectionDay", c => c.Int());
            DropForeignKey("dbo.ScheduleManagers", "CustomerId", "dbo.CustomerModels");
            DropPrimaryKey("dbo.ScheduleManagers");
            DropColumn("dbo.ScheduleManagers", "temporaryCollectionDay");
            DropColumn("dbo.ScheduleManagers", "changeId");
            AddPrimaryKey("dbo.ScheduleManagers", "CustomerId");
            AddForeignKey("dbo.ScheduleManagers", "CustomerId", "dbo.CustomerModels", "CustomerId");
        }
    }
}
