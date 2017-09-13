namespace Carpool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clean : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WeeklyLifts", "OutboundStartTime", c => c.DateTime(nullable: true));
            AlterColumn("dbo.WeeklyLifts", "OutboundEndTime", c => c.DateTime(nullable: true));
            AlterColumn("dbo.WeeklyLifts", "InboundStartTime", c => c.DateTime(nullable: true));
            AlterColumn("dbo.WeeklyLifts", "InboundEndTime", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WeeklyLifts", "InboundEndTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "InboundStartTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "OutboundEndTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.WeeklyLifts", "OutboundStartTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}
