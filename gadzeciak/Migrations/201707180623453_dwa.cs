namespace gadzeciak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dwa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kategorias", "Nazwa", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kategorias", "Nazwa", c => c.Int(nullable: false));
        }
    }
}
