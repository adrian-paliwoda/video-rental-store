namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repair15 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate,AddedDate,NumberInStock ) VALUES('Shrek', 1, 2001-04-22,'2018-15-04', 5)");
        }
        
        public override void Down()
        {
        }
    }
}
