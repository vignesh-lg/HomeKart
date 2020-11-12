namespace HomeKartDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upload : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 70),
                        CellNumber = c.Long(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        PinCode = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.CellNumber, unique: true)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "Email" });
            DropIndex("dbo.User", new[] { "CellNumber" });
            DropTable("dbo.User");
        }
    }
}
