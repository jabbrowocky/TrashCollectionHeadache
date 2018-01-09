namespace TrashCity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testyyyyyyyyyy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CustomerModels", "UserId");
            AddForeignKey("dbo.CustomerModels", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerModels", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.CustomerModels", new[] { "UserId" });
            DropColumn("dbo.CustomerModels", "UserId");
        }
    }
}
