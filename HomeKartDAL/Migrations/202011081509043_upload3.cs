namespace HomeKartDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upload3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "CategoryId_CategoryId", "dbo.ProductCategory");
            DropIndex("dbo.Product", new[] { "CategoryId_CategoryId" });
            AddColumn("dbo.Product", "CategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "CategoryId_CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "CategoryId_CategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Product", "CategoryId");
            CreateIndex("dbo.Product", "CategoryId_CategoryId");
            AddForeignKey("dbo.Product", "CategoryId_CategoryId", "dbo.ProductCategory", "CategoryId", cascadeDelete: true);
        }
    }
}
