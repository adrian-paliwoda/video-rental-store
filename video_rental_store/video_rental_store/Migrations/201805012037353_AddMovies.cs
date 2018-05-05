namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieIds (Name, Genre_Id) VALUES('Shrek', 1)");
            Sql("INSERT INTO MovieIds (Name, Genre_Id) VALUES('Memento', 2)");
            Sql("INSERT INTO MovieIds (Name, Genre_Id) VALUES('Schindlers list', 3)");
            Sql("INSERT INTO MovieIds (Name, Genre_Id) VALUES('The dark knight', 4)");
            Sql("INSERT INTO MovieIds (Name, Genre_Id) VALUES('Godfather', 5)");
            Sql("INSERT INTO MovieIds (Name, Genre_Id) VALUES('Westworld', 1)");
            Sql("INSERT INTO MovieIds (Name, Genre_Id) VALUES('Starwars', 2)");
        }
        
        public override void Down()
        {
        }
    }
}
