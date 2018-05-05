namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetSomeMovies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieIds", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.MovieIds", new[] { "Genre_Id" });
            AddColumn("dbo.MovieIds", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MovieIds", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MovieIds", "NumberInStock", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieIds", "Genre_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MovieIds", "Genre_Id");
            AddForeignKey("dbo.MovieIds", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieIds", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.MovieIds", new[] { "Genre_Id" });
            AlterColumn("dbo.MovieIds", "Genre_Id", c => c.Int());
            DropColumn("dbo.MovieIds", "NumberInStock");
            DropColumn("dbo.MovieIds", "AddedDate");
            DropColumn("dbo.MovieIds", "ReleaseDate");
            CreateIndex("dbo.MovieIds", "Genre_Id");
            AddForeignKey("dbo.MovieIds", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
