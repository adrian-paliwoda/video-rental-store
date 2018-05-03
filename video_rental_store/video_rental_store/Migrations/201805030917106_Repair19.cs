namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repair19 : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Movies WHERE Name = 'Shrek'");
        }
        
        public override void Down()
        {
        }
    }
}
