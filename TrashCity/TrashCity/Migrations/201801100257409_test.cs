namespace TrashCity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ScheduleManagers", "dateToChange", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ScheduleManagers", "dateToChange", c => c.DateTime(nullable: false));
        }
    }
}
