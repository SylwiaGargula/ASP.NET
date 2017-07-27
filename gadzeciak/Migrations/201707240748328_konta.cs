namespace gadzeciak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class konta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logowanies",
                c => new
                    {
                        NazwaUzytkownika = c.String(nullable: false, maxLength: 128),
                        Haslo = c.String(nullable: false),
                        Przypomnij = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NazwaUzytkownika);
            
            CreateTable(
                "dbo.Rejestracjas",
                c => new
                    {
                        NazwaUZytkownika = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false),
                        Haslo = c.String(nullable: false, maxLength: 100),
                        ZatwierdzoneHaslo = c.String(),
                    })
                .PrimaryKey(t => t.NazwaUZytkownika);
            
            CreateTable(
                "dbo.ZmienHasloes",
                c => new
                    {
                        StareHaslo = c.String(nullable: false, maxLength: 128),
                        NoweHaslo = c.String(nullable: false, maxLength: 100),
                        ZatwierdzoneHaslo = c.String(),
                    })
                .PrimaryKey(t => t.StareHaslo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ZmienHasloes");
            DropTable("dbo.Rejestracjas");
            DropTable("dbo.Logowanies");
        }
    }
}
