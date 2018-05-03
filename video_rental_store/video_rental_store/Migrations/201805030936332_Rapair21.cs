namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rapair21 : DbMigration
    {
        public override void Up()
        {
            Sql("Update Movies Set Name = 'Drama' Where Id = 6");
        }
        
        public override void Down()
        {
        }
    }
}
