namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovies1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieIds (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Shrek', 1, 22-04-2001,15-04-2018, 5)");
/*            Sql("INSERT INTO MovieIds (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Memento', 2, '2000-05-09','2018-12-04', 6)");
            Sql("INSERT INTO MovieIds (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Schindlers list', 3, '1993-30-11','2018-30-04', 1)");
            Sql("INSERT INTO MovieIds (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('The dark knight', 4, '2008-07-14','2018-12-05', 8)");
            Sql("INSERT INTO MovieIds (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Godfather', 5, '1972-15-03','2018-12-04', 10)");
            Sql("INSERT INTO MovieIds (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Westworld', 1, '2016-03-10','2018-22-04',2)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Starwars', 2, '1977-25-05','2018-01-05', 12)");*/
        }
        
        public override void Down()
        {
        }
    }
}
