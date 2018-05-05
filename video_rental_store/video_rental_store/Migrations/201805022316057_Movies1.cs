namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movies1 : DbMigration
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
                        AddedDate = c.DateTime(nullable: true),
                        ReleaseDate = c.DateTime(nullable: true),
                        NumberInStock = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);

            CreateTable(
                    "dbo.Genres",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
        }
    }
}
