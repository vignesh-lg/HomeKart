namespace HomeKartDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upload8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "HashCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "HashCode");
        }
    }
}
