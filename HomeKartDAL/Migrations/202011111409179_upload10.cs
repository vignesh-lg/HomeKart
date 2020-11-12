namespace HomeKartDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upload10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomExceptionHandler",
                c => new
                    {
                        ExceptionId = c.Int(nullable: false, identity: true),
                        ExceptionMessage = c.String(nullable: false),
                        TraceException = c.String(nullable: false),
                        ControllerName = c.String(nullable: false),
                        ActionName = c.String(nullable: false),
                        ExceptionLogTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExceptionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomExceptionHandler");
        }
    }
}
