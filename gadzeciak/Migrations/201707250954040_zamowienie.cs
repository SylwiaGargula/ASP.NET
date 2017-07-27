namespace gadzeciak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zamowienie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Zamowienies",
                c => new
                    {
                        IdZamowienia = c.Int(nullable: false, identity: true),
                        DataZamowienia = c.DateTime(nullable: false),
                        Login = c.String(),
                        Imie = c.String(nullable: false, maxLength: 160),
                        Nazwisko = c.String(nullable: false, maxLength: 160),
                        Ulica = c.String(nullable: false, maxLength: 70),
                        Miasto = c.String(nullable: false, maxLength: 70),
                        Wojewodztwo = c.String(nullable: false, maxLength: 70),
                        KodPocztowy = c.String(nullable: false, maxLength: 10),
                        Panstwo = c.String(nullable: false, maxLength: 70),
                        NumerTelefonu = c.String(nullable: false, maxLength: 24),
                        Email = c.String(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdZamowienia);
            
            CreateTable(
                "dbo.PozycjaZamowienias",
                c => new
                    {
                        IdPozycjiZamowienia = c.Int(nullable: false, identity: true),
                        Ilosc = c.Int(nullable: false),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdProdukt = c.Int(nullable: false),
                        IdZamowienia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPozycjiZamowienia)
                .ForeignKey("dbo.Produkts", t => t.IdProdukt, cascadeDelete: true)
                .ForeignKey("dbo.Zamowienies", t => t.IdZamowienia, cascadeDelete: true)
                .Index(t => t.IdProdukt)
                .Index(t => t.IdZamowienia);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PozycjaZamowienias", "IdZamowienia", "dbo.Zamowienies");
            DropForeignKey("dbo.PozycjaZamowienias", "IdProdukt", "dbo.Produkts");
            DropIndex("dbo.PozycjaZamowienias", new[] { "IdZamowienia" });
            DropIndex("dbo.PozycjaZamowienias", new[] { "IdProdukt" });
            DropTable("dbo.PozycjaZamowienias");
            DropTable("dbo.Zamowienies");
        }
    }
}
