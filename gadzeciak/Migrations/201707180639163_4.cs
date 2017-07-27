namespace gadzeciak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Produkts", name: "KategoriaID", newName: "IdKategoria");
            RenameIndex(table: "dbo.Produkts", name: "IX_KategoriaID", newName: "IX_IdKategoria");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Produkts", name: "IX_IdKategoria", newName: "IX_KategoriaID");
            RenameColumn(table: "dbo.Produkts", name: "IdKategoria", newName: "KategoriaID");
        }
    }
}
