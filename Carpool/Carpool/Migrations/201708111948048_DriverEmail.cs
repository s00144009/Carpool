namespace Carpool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DriverEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestLifts", "DriverEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RequestLifts", "DriverEmail");
        }
    }
}
