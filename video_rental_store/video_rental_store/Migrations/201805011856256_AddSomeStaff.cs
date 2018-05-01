namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeStaff : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers( Name, IsSubscribedToNewsletter,MemberShipTypeId, BirthDate) VALUES('Jan Kowalski', 1, 1, '1999-12-12')");
            Sql("INSERT INTO Customers( Name, IsSubscribedToNewsletter,MemberShipTypeId, BirthDate) VALUES('Jan Nowak', 1, 1, '1999-12-12')");
            Sql("INSERT INTO Customers( Name, IsSubscribedToNewsletter,MemberShipTypeId, BirthDate) VALUES('Adam Kowalski', 1, 1, '1999-12-12')");

        }
        
        public override void Down()
        {
        }
    }
}
