namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieRental1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MovieRental", "DateRented", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieRental", "DateRented", c => c.DateTime(nullable: false));
        }
    }
}
