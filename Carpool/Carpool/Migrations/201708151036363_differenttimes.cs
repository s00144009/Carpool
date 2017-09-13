namespace Carpool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class differenttimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestWeeklyLifts", "MondayStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "MondayEndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "TuesdayStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "TuesdayEndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "WednesdayStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "WednesdayEndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "ThursdayStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "ThursdayEndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "FridayStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "FridayEndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "SaturdayStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "SaturdayEndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "SundayStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "SundayEndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequestWeeklyLifts", "DifferentTimes", c => c.Boolean(nullable: false));
            AddColumn("dbo.WeeklyLifts", "MondayStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeeklyLifts", "MondayEndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeeklyLifts", "TuesdayStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeeklyLifts", "TuesdayEndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeeklyLifts", "WednesdayStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeeklyLifts", "WednesdayEndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeeklyLifts", "ThursdayStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeeklyLifts", "ThursdayEndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeeklyLifts", "FridayStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeeklyLifts", "FridayEndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeeklyLifts", "SaturdayStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeeklyLifts", "SaturdayEndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeeklyLifts", "SundayStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeeklyLifts", "SundayEndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.WeeklyLifts", "DifferentTimes", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Lifts", "InboundStartTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Lifts", "InboundEndTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "OutboundTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "InboundTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "OutboundStartTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "OutboundEndTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "InboundStartTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "InboundEndTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WeeklyLifts", "InboundEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "InboundStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "OutboundEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "OutboundStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequestWeeklyLifts", "InboundTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequestWeeklyLifts", "OutboundTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Lifts", "InboundEndTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Lifts", "InboundStartTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.WeeklyLifts", "DifferentTimes");
            DropColumn("dbo.WeeklyLifts", "SundayEndTime");
            DropColumn("dbo.WeeklyLifts", "SundayStartTime");
            DropColumn("dbo.WeeklyLifts", "SaturdayEndTime");
            DropColumn("dbo.WeeklyLifts", "SaturdayStartTime");
            DropColumn("dbo.WeeklyLifts", "FridayEndTime");
            DropColumn("dbo.WeeklyLifts", "FridayStartTime");
            DropColumn("dbo.WeeklyLifts", "ThursdayEndTime");
            DropColumn("dbo.WeeklyLifts", "ThursdayStartTime");
            DropColumn("dbo.WeeklyLifts", "WednesdayEndTime");
            DropColumn("dbo.WeeklyLifts", "WednesdayStartTime");
            DropColumn("dbo.WeeklyLifts", "TuesdayEndTime");
            DropColumn("dbo.WeeklyLifts", "TuesdayStartTime");
            DropColumn("dbo.WeeklyLifts", "MondayEndTime");
            DropColumn("dbo.WeeklyLifts", "MondayStartTime");
            DropColumn("dbo.RequestWeeklyLifts", "DifferentTimes");
            DropColumn("dbo.RequestWeeklyLifts", "SundayEndTime");
            DropColumn("dbo.RequestWeeklyLifts", "SundayStartTime");
            DropColumn("dbo.RequestWeeklyLifts", "SaturdayEndTime");
            DropColumn("dbo.RequestWeeklyLifts", "SaturdayStartTime");
            DropColumn("dbo.RequestWeeklyLifts", "FridayEndTime");
            DropColumn("dbo.RequestWeeklyLifts", "FridayStartTime");
            DropColumn("dbo.RequestWeeklyLifts", "ThursdayEndTime");
            DropColumn("dbo.RequestWeeklyLifts", "ThursdayStartTime");
            DropColumn("dbo.RequestWeeklyLifts", "WednesdayEndTime");
            DropColumn("dbo.RequestWeeklyLifts", "WednesdayStartTime");
            DropColumn("dbo.RequestWeeklyLifts", "TuesdayEndTime");
            DropColumn("dbo.RequestWeeklyLifts", "TuesdayStartTime");
            DropColumn("dbo.RequestWeeklyLifts", "MondayEndTime");
            DropColumn("dbo.RequestWeeklyLifts", "MondayStartTime");
        }
    }
}
