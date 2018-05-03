namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactor1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Movies", new[] { "GenreId_Id" });
            DropColumn("dbo.Movies", "GenreId_Id");
        }
        
        public override void Down()
        {
        }
    }
}
