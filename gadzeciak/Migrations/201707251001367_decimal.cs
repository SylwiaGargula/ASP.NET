namespace gadzeciak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _decimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Zamowienies", "Total", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zamowienies", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
