namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberShipTypes", "SignUpFee", c => c.Short(nullable: false));
            DropColumn("dbo.MemberShipTypes", "SignTypeFee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberShipTypes", "SignTypeFee", c => c.Short(nullable: false));
            DropColumn("dbo.MemberShipTypes", "SignUpFee");
        }
    }
}
