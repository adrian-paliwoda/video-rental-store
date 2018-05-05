namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repair20 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Shrek', 1, '04-22-2001','04-15-2018', 5)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Memento', 2, '05-09-2000','04-12-2018', 2)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Schindlers list', 3, '11-30-1993','04-30-2018', 1)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('The dark knight', 4, '07-14-2008','05-12-2018', 3)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Godfather', 5, '03-15-1972','04-12-2018', 3)");
            Sql("INSERT INTO MovieIds (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Westworld', 1, '03-10-2016','04-22-2018',2)");
            Sql("INSERT INTO MovieIds (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Starwars', 2, '05-25-1997','05-01-2018', 3)");
        }

        public override void Down()
        {
        }
    }
}
