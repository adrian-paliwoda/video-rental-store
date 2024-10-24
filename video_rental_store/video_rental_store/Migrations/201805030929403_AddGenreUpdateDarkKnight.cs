namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreUpdateDarkKnight : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Comedy')");
            Sql("Update MovieIds Set GenreId = 1 WHERE Name = 'The dark knight'");
            Sql("Update MovieIds Set GenreId = 6 WHERE Name = 'Schindlers list'");
            Sql("Update MovieIds Set GenreId = 5 WHERE Name = 'Shrek'");
        }
        
        public override void Down()
        {
        }
    }
}
