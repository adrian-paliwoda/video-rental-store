namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId_Id", c => c.Int(nullable: false));
           // CreateIndex("dbo.Movies", "GenreId_Id");
         //   AddForeignKey("dbo.Movies", "GenreId_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId_Id" });
            DropColumn("dbo.Movies", "GenreId_Id");
        }
    }
}
