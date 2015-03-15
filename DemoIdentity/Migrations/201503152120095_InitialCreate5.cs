namespace DemoIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "UserID", c => c.Int(nullable: false));
        }
    }
}
