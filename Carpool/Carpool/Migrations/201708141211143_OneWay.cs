namespace Carpool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneWay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lifts", "OneWayLift", c => c.Boolean(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "DriverEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RequestWeeklyLifts", "DriverEmail");
            DropColumn("dbo.Lifts", "OneWayLift");
        }
    }
}
