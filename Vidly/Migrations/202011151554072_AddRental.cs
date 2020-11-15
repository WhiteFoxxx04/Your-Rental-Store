namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Rental",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Movie_Id)
                .Index(t => t.Game_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Rental", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Rental", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rental", "Game_Id", "dbo.Games");
            DropIndex("dbo.Rental", new[] { "Movie_Id" });
            DropIndex("dbo.Rental", new[] { "Customer_Id" });
            DropIndex("dbo.Rental", new[] { "Game_Id"});
            DropTable("dbo.Rental");
        }
    }
}
