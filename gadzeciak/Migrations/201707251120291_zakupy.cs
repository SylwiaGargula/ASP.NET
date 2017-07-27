namespace gadzeciak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zakupy : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Zamowienies", "Login");
            DropColumn("dbo.Zamowienies", "Imie");
            DropColumn("dbo.Zamowienies", "Nazwisko");
            DropColumn("dbo.Zamowienies", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zamowienies", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Zamowienies", "Nazwisko", c => c.String(nullable: false, maxLength: 160));
            AddColumn("dbo.Zamowienies", "Imie", c => c.String(nullable: false, maxLength: 160));
            AddColumn("dbo.Zamowienies", "Login", c => c.String());
        }
    }
}
