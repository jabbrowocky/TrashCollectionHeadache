namespace TrashCity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migratingtofixerror : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeModels", "RouteZipCode", c => c.Int(nullable: false));
            DropColumn("dbo.EmployeeModels", "EmployeeZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeModels", "EmployeeZipCode", c => c.Int(nullable: false));
            DropColumn("dbo.EmployeeModels", "RouteZipCode");
        }
    }
}
