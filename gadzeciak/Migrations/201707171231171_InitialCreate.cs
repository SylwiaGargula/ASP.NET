namespace gadzeciak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produkts",
                c => new
                    {
                        IdProdukt = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Opis = c.String(),
                        Dostepnosc = c.Boolean(nullable: false),
                        Zdjecie = c.String(),
                        Kategoria = c.String(),
                        Cena = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdProdukt);
            
            CreateTable(
                "dbo.Uzytkowniks",
                c => new
                    {
                        IdUzytkownik = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Adres = c.String(),
                        Email = c.String(),
                        Haslo = c.String(),
                        Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUzytkownik);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uzytkowniks");
            DropTable("dbo.Produkts");
        }
    }
}
