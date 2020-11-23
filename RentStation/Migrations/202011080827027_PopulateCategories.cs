namespace RentStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Play Station')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'XBox')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3, 'Nintendo Switch')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (4, 'PC Games')");
        }
        
        public override void Down()
        {
        }
    }
}
