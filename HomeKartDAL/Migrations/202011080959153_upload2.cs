namespace HomeKartDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upload2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 20),
                        Price = c.Int(nullable: false),
                        ProductImageName = c.String(nullable: false, maxLength: 200),
                        ProductImage = c.String(nullable: false, maxLength: 200),
                        CategoryId_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductCategory", t => t.CategoryId_CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId_CategoryId);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CategoryId_CategoryId", "dbo.ProductCategory");
            DropIndex("dbo.Product", new[] { "CategoryId_CategoryId" });
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Product");
        }
    }
}
