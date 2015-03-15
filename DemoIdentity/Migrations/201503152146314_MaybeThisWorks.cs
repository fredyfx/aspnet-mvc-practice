namespace DemoIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaybeThisWorks : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "User_Id", newName: "UserID");
            RenameIndex(table: "dbo.Orders", name: "IX_User_Id", newName: "IX_UserID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_UserID", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Orders", name: "UserID", newName: "User_Id");
        }
    }
}
