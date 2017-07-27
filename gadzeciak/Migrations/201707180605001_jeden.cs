namespace gadzeciak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jeden : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategorias",
                c => new
                    {
                        IdKategoria = c.Int(nullable: false, identity: true),
                        Nazwa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdKategoria);
            
            AddColumn("dbo.Produkts", "OfertaSpecjalna", c => c.Boolean(nullable: false));
            AddColumn("dbo.Produkts", "Polecane", c => c.Boolean(nullable: false));
            AddColumn("dbo.Produkts", "KategoriaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Produkts", "KategoriaID");
            AddForeignKey("dbo.Produkts", "KategoriaID", "dbo.Kategorias", "IdKategoria", cascadeDelete: true);
            DropColumn("dbo.Produkts", "Kategoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produkts", "Kategoria", c => c.String());
            DropForeignKey("dbo.Produkts", "KategoriaID", "dbo.Kategorias");
            DropIndex("dbo.Produkts", new[] { "KategoriaID" });
            DropColumn("dbo.Produkts", "KategoriaID");
            DropColumn("dbo.Produkts", "Polecane");
            DropColumn("dbo.Produkts", "OfertaSpecjalna");
            DropTable("dbo.Kategorias");
        }
    }
}
