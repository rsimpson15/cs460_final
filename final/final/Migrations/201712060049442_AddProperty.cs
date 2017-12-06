namespace final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProperty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bid",
                c => new
                    {
                        BidID = c.Int(nullable: false),
                        BuyerID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.BidID)
                .ForeignKey("dbo.Buyer", t => t.BuyerID)
                .ForeignKey("dbo.Item", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.BuyerID)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.Buyer",
                c => new
                    {
                        BuyerID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.BuyerID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        SellerID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Seller", t => t.SellerID, cascadeDelete: true)
                .Index(t => t.SellerID);
            
            CreateTable(
                "dbo.Seller",
                c => new
                    {
                        SellerID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.SellerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "SellerID", "dbo.Seller");
            DropForeignKey("dbo.Bid", "ItemID", "dbo.Item");
            DropForeignKey("dbo.Bid", "BuyerID", "dbo.Buyer");
            DropIndex("dbo.Item", new[] { "SellerID" });
            DropIndex("dbo.Bid", new[] { "ItemID" });
            DropIndex("dbo.Bid", new[] { "BuyerID" });
            DropTable("dbo.Seller");
            DropTable("dbo.Item");
            DropTable("dbo.Buyer");
            DropTable("dbo.Bid");
        }
    }
}
