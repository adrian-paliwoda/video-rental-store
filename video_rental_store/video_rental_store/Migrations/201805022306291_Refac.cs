namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refac : DbMigration
    {
        public override void Up()
        {
            DropTable("MovieIds");
            DropTable("Genres");
        }
        
        public override void Down()
        {
        }
    }
}
