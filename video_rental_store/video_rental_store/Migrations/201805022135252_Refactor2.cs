namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactor2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.MovieIds", new[] { "Genre_Id" });
            DropColumn("dbo.MovieIds", "Genre_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieIds", "Genre_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MovieIds", "Genre_Id");
            AddForeignKey("dbo.MovieIds", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
