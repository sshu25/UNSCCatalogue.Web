namespace UNSCCatalogue.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateOfPurchase = c.DateTime(),
                        CategoryID = c.Long(nullable: false),
                        BrandID = c.Long(nullable: false),
                        AvailabilityStatus = c.Boolean(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.BrandID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
        }
    }
}
