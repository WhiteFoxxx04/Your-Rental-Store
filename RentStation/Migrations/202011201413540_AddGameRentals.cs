namespace RentStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGameRentals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(),
                        DateReturned = c.DateTime(),
                        Customer_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Game_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameRentals", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.GameRentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.GameRentals", new[] { "Game_Id" });
            DropIndex("dbo.GameRentals", new[] { "Customer_Id" });
            DropTable("dbo.GameRentals");
        }
    }
}
