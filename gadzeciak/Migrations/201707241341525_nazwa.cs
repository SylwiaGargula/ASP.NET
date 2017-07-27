namespace gadzeciak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nazwa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uzytkowniks", "NazwaUzytkownika", c => c.String());
            DropColumn("dbo.Uzytkowniks", "Admin");
            DropTable("dbo.Logowanies");
            DropTable("dbo.Rejestracjas");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.ZmienHasloes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ZmienHasloes",
                c => new
                    {
                        StareHaslo = c.String(nullable: false, maxLength: 128),
                        NoweHaslo = c.String(nullable: false, maxLength: 100),
                        ZatwierdzoneHaslo = c.String(),
                    })
                .PrimaryKey(t => t.StareHaslo);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        IsEmailVerified = c.Boolean(nullable: false),
                        ActivationCode = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRolesID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRolesID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Rejestracjas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NazwaUZytkownika = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Haslo = c.String(nullable: false, maxLength: 100),
                        ZatwierdzoneHaslo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Logowanies",
                c => new
                    {
                        NazwaUzytkownika = c.String(nullable: false, maxLength: 128),
                        Haslo = c.String(nullable: false),
                        Przypomnij = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NazwaUzytkownika);
            
            AddColumn("dbo.Uzytkowniks", "Admin", c => c.Boolean(nullable: false));
            DropColumn("dbo.Uzytkowniks", "NazwaUzytkownika");
        }
    }
}
