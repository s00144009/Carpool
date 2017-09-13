namespace Carpool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dt2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RequestWeeklyLifts", "MondayStartTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "MondayEndTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "TuesdayStartTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "TuesdayEndTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "WednesdayStartTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "WednesdayEndTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "ThursdayStartTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "ThursdayEndTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "FridayStartTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "FridayEndTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "SaturdayStartTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "SaturdayEndTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "SundayStartTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "SundayEndTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RequestWeeklyLifts", "SundayEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequestWeeklyLifts", "SundayStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequestWeeklyLifts", "SaturdayEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequestWeeklyLifts", "SaturdayStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequestWeeklyLifts", "FridayEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequestWeeklyLifts", "FridayStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequestWeeklyLifts", "ThursdayEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequestWeeklyLifts", "ThursdayStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequestWeeklyLifts", "WednesdayEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequestWeeklyLifts", "WednesdayStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequestWeeklyLifts", "TuesdayEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequestWeeklyLifts", "TuesdayStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequestWeeklyLifts", "MondayEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequestWeeklyLifts", "MondayStartTime", c => c.DateTime(nullable: false));
        }
    }
}
