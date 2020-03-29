namespace ProductSell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductMIgration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checks",
                c => new
                    {
                        CheckID = c.Int(nullable: false, identity: true),
                        SellerID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CheckID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerID, cascadeDelete: true)
                .Index(t => t.SellerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SellerID);
            
            CreateTable(
                "dbo.Sells",
                c => new
                    {
                        SellID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        CheckID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SellID)
                .ForeignKey("dbo.Checks", t => t.CheckID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CheckID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Count = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sells", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Sells", "CheckID", "dbo.Checks");
            DropForeignKey("dbo.Checks", "SellerID", "dbo.Sellers");
            DropForeignKey("dbo.Checks", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Sells", new[] { "CheckID" });
            DropIndex("dbo.Sells", new[] { "ProductID" });
            DropIndex("dbo.Checks", new[] { "CustomerID" });
            DropIndex("dbo.Checks", new[] { "SellerID" });
            DropTable("dbo.Products");
            DropTable("dbo.Sells");
            DropTable("dbo.Sellers");
            DropTable("dbo.Customers");
            DropTable("dbo.Checks");
        }
    }
}
