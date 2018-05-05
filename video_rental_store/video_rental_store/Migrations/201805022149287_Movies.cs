namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.MovieIds",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        GenreId = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieIds", "GenreId", "dbo.Genres");
            DropIndex("dbo.MovieIds", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.MovieIds");
        }
    }
}
