namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDataToMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieIds (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Shrek', 1, '2001-12-15',2018-04-15, 5)");
            Sql("INSERT INTO MovieIds (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Memento', 2, '2001-05-15',2017-03-15, 6)");
            Sql("INSERT INTO MovieIds (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Schindlers list', 3, '1994-07-21',2011-09-04, 1)");
            Sql("INSERT INTO MovieIds (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('The dark knight', 4, '2008-07-15',2018-04-15, 8)");
            Sql("INSERT INTO MovieIds (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Godfather', 5, '2001-12-15',2018-04-15, 10)");
            Sql("INSERT INTO MovieIds (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Westworld', 1, '2001-12-15',2018-04-15,2)");
            Sql("INSERT INTO MovieIds (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Starwars', 2, '2001-12-15',2018-04-15, 12)");
        }
        
        public override void Down()
        {
        }
    }
}
