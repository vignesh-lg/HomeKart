namespace HomeKartDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upload7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CartId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CartId");
        }
    }
}
