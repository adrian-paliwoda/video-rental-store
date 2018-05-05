namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieIds", "GenreId_Id", c => c.Int(nullable: false));
           // CreateIndex("dbo.MovieIds", "GenreId_Id");
         //   AddForeignKey("dbo.MovieIds", "GenreId_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieIds", "GenreId_Id", "dbo.Genres");
            DropIndex("dbo.MovieIds", new[] { "GenreId_Id" });
            DropColumn("dbo.MovieIds", "GenreId_Id");
        }
    }
}
