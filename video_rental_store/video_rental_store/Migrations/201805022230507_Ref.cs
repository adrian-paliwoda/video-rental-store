namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ref : DbMigration
    {
        public override void Up()
        {
            DropTable("Movies");
        }
        
        public override void Down()
        {
        }
    }
}
