namespace HomeKartDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upload5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Address", c => c.String());
            AddColumn("dbo.Orders", "Pincode", c => c.Int(nullable: false));
            AddColumn("dbo.User", "Address", c => c.String());
            AddColumn("dbo.User", "City", c => c.String());
            AddColumn("dbo.User", "Pincode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Pincode");
            DropColumn("dbo.User", "City");
            DropColumn("dbo.User", "Address");
            DropColumn("dbo.Orders", "Pincode");
            DropColumn("dbo.Orders", "Address");
            DropColumn("dbo.Orders", "OrderDate");
        }
    }
}
