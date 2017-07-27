namespace gadzeciak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class klucz : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Rejestracjas");
            AddColumn("dbo.Rejestracjas", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Rejestracjas", "NazwaUZytkownika", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Rejestracjas", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Rejestracjas");
            AlterColumn("dbo.Rejestracjas", "NazwaUZytkownika", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Rejestracjas", "ID");
            AddPrimaryKey("dbo.Rejestracjas", "NazwaUZytkownika");
        }
    }
}
