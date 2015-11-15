namespace AttributesForAutomapper.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        BorrowDateTime = c.DateTime(nullable: false),
                        ExpiredDateTime = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StudentIdFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentIdFk, cascadeDelete: true)
                .Index(t => t.StudentIdFk);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 32),
                        Family = c.String(maxLength: 64),
                        Email = c.String(maxLength: 128),
                        RegisterDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "StudentIdFk", "dbo.Student");
            DropIndex("dbo.Book", new[] { "StudentIdFk" });
            DropTable("dbo.Student");
            DropTable("dbo.Book");
        }
    }
}
