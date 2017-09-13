namespace Carpool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredRemove : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WeeklyLifts", "MondayStartTime", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "MondayEndTime", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "TuesdayStartTime", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "TuesdayEndTime", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "WednesdayStartTime", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "WednesdayEndTime", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "ThursdayStartTime", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "ThursdayEndTime", c => c.DateTime(nullable: true,precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "FridayStartTime", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "FridayEndTime", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "SaturdayStartTime", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "SaturdayEndTime", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "SundayStartTime", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "SundayEndTime", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WeeklyLifts", "SundayEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "SundayStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "SaturdayEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "SaturdayStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "FridayEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "FridayStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "ThursdayEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "ThursdayStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "WednesdayEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "WednesdayStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "TuesdayEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "TuesdayStartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "MondayEndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WeeklyLifts", "MondayStartTime", c => c.DateTime(nullable: false));
        }
    }
}
