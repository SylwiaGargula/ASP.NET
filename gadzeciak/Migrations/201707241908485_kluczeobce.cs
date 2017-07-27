namespace gadzeciak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kluczeobce : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.UserRoles", "RoleID");
            CreateIndex("dbo.UserRoles", "UserID");
            AddForeignKey("dbo.UserRoles", "RoleID", "dbo.Roles", "RoleID", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "UserID", "dbo.Uzytkowniks", "IdUzytkownik", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserID", "dbo.Uzytkowniks");
            DropForeignKey("dbo.UserRoles", "RoleID", "dbo.Roles");
            DropIndex("dbo.UserRoles", new[] { "UserID" });
            DropIndex("dbo.UserRoles", new[] { "RoleID" });
        }
    }
}
