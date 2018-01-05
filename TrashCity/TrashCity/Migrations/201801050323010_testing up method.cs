namespace TrashCity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingupmethod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                {
                    RoleId = c.Int(nullable: false, identity: true),
                    RoleType = c.String(),

                })
                .PrimaryKey(t => t.RoleId);
        }
        
        public override void Down()
        {
        }
    }
}
