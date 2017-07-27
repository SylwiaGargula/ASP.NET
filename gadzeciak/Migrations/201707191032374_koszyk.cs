namespace gadzeciak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class koszyk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DaneDoKoszykas",
                c => new
                    {
                        IdDanych = c.Int(nullable: false, identity: true),
                        Razem = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdDanych);
            
            CreateTable(
                "dbo.ElementKoszykas",
                c => new
                    {
                        IdElementKoszyka = c.Int(nullable: false, identity: true),
                        Ilosc = c.Int(nullable: false),
                        DataUtworzenia = c.DateTime(nullable: false),
                        IdSesjiKoszyka = c.String(),
                        ProduktId = c.Int(nullable: false),
                        DaneDoKoszyka_IdDanych = c.Int(),
                    })
                .PrimaryKey(t => t.IdElementKoszyka)
                .ForeignKey("dbo.Produkts", t => t.ProduktId, cascadeDelete: true)
                .ForeignKey("dbo.DaneDoKoszykas", t => t.DaneDoKoszyka_IdDanych)
                .Index(t => t.ProduktId)
                .Index(t => t.DaneDoKoszyka_IdDanych);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ElementKoszykas", "DaneDoKoszyka_IdDanych", "dbo.DaneDoKoszykas");
            DropForeignKey("dbo.ElementKoszykas", "ProduktId", "dbo.Produkts");
            DropIndex("dbo.ElementKoszykas", new[] { "DaneDoKoszyka_IdDanych" });
            DropIndex("dbo.ElementKoszykas", new[] { "ProduktId" });
            DropTable("dbo.ElementKoszykas");
            DropTable("dbo.DaneDoKoszykas");
        }
    }
}
