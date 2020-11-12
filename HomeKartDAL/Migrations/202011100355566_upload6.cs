namespace HomeKartDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upload6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "Address");
            DropColumn("dbo.User", "City");
            DropColumn("dbo.User", "Pincode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Pincode", c => c.Int(nullable: false));
            AddColumn("dbo.User", "City", c => c.String());
            AddColumn("dbo.User", "Address", c => c.String());
        }
    }
}
