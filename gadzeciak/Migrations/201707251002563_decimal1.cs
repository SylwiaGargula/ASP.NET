namespace gadzeciak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decimal1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PozycjaZamowienias", "Cena", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PozycjaZamowienias", "Cena", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
