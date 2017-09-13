namespace Carpool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weeklyDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestWeeklyLifts", "Description", c => c.String());
            AddColumn("dbo.WeeklyLifts", "Description", c => c.String());
            DropColumn("dbo.RequestWeeklyLifts", "DifferentTimes");
            DropColumn("dbo.WeeklyLifts", "DifferentTimes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WeeklyLifts", "DifferentTimes", c => c.Boolean(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "DifferentTimes", c => c.Boolean(nullable: false));
            DropColumn("dbo.WeeklyLifts", "Description");
            DropColumn("dbo.RequestWeeklyLifts", "Description");
        }
    }
}
