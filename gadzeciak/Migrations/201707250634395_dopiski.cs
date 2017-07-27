namespace gadzeciak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dopiski : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produkts", "Zdjecie2", c => c.String());
            AddColumn("dbo.Produkts", "Zdjecie3", c => c.String());
            AlterColumn("dbo.Produkts", "Nazwa", c => c.String(nullable: false, maxLength: 160));
            AlterColumn("dbo.Produkts", "Opis", c => c.String(nullable: false));
            AlterColumn("dbo.Kategorias", "Nazwa", c => c.String(nullable: false));
            AlterColumn("dbo.Uzytkowniks", "Imie", c => c.String(nullable: false));
            AlterColumn("dbo.Uzytkowniks", "Nazwisko", c => c.String(nullable: false));
            AlterColumn("dbo.Uzytkowniks", "Adres", c => c.String(nullable: false));
            AlterColumn("dbo.Uzytkowniks", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Uzytkowniks", "Haslo", c => c.String(nullable: false));
            AlterColumn("dbo.Uzytkowniks", "NazwaUzytkownika", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Uzytkowniks", "NazwaUzytkownika", c => c.String());
            AlterColumn("dbo.Uzytkowniks", "Haslo", c => c.String());
            AlterColumn("dbo.Uzytkowniks", "Email", c => c.String());
            AlterColumn("dbo.Uzytkowniks", "Adres", c => c.String());
            AlterColumn("dbo.Uzytkowniks", "Nazwisko", c => c.String());
            AlterColumn("dbo.Uzytkowniks", "Imie", c => c.String());
            AlterColumn("dbo.Kategorias", "Nazwa", c => c.String());
            AlterColumn("dbo.Produkts", "Opis", c => c.String());
            AlterColumn("dbo.Produkts", "Nazwa", c => c.String());
            DropColumn("dbo.Produkts", "Zdjecie3");
            DropColumn("dbo.Produkts", "Zdjecie2");
        }
    }
}
