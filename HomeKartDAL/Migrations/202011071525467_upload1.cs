namespace HomeKartDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upload1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.User", new[] { "CellNumber" });
            DropColumn("dbo.User", "UserName");
            DropColumn("dbo.User", "Address");
            DropColumn("dbo.User", "PinCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "PinCode", c => c.Int(nullable: false));
            AddColumn("dbo.User", "Address", c => c.String(nullable: false, maxLength: 70));
            AddColumn("dbo.User", "UserName", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.User", "CellNumber", unique: true);
        }
    }
}
