namespace Carpool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carpoolcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GMailers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ToEmail = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        IsHtml = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Lifts",
                c => new
                    {
                        LiftID = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        StartPoint = c.String(nullable: false, maxLength: 50),
                        EndPoint = c.String(nullable: false, maxLength: 50),
                        LiftDate = c.DateTime(nullable: false),
                        OutboundStartTime = c.DateTime(nullable: false),
                        OutboundEndTime = c.DateTime(nullable: false),
                        InboundStartTime = c.DateTime(nullable: false),
                        InboundEndTime = c.DateTime(nullable: false),
                        UserEmailAddress = c.String(),
                        UserId = c.String(),
                        requestLifts_RequestId = c.Int(),
                    })
                .PrimaryKey(t => t.LiftID)
                .ForeignKey("dbo.RequestLifts", t => t.requestLifts_RequestId, cascadeDelete: true)
                .Index(t => t.requestLifts_RequestId);
            
            CreateTable(
                "dbo.RequestLifts",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        StartPoint = c.String(nullable: false),
                        MeetingPoint = c.String(nullable: false),
                        EndPoint = c.String(nullable: false),
                        OutboundTime = c.DateTime(nullable: false),
                        InboundTime = c.DateTime(nullable: false),
                        PassengerEmail = c.String(),
                        EmailSent = c.Boolean(nullable: false),
                        DriverId = c.Int(nullable: false),
                        bookingStatus = c.String(),
                    })
                .PrimaryKey(t => t.RequestId);
            
            CreateTable(
                "dbo.RequestWeeklyLifts",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        StartPoint = c.String(nullable: false),
                        MeetingPoint = c.String(nullable: false),
                        EndPoint = c.String(nullable: false),
                        Monday = c.Boolean(nullable: false),
                        Tuesday = c.Boolean(nullable: false),
                        Wednesday = c.Boolean(nullable: false),
                        Thursday = c.Boolean(nullable: false),
                        Friday = c.Boolean(nullable: false),
                        Saturday = c.Boolean(nullable: false),
                        Sunday = c.Boolean(nullable: false),
                        OutboundTime = c.DateTime(nullable: false),
                        InboundTime = c.DateTime(nullable: false),
                        PassengerEmail = c.String(),
                        EmailSent = c.Boolean(nullable: false),
                        DriverId = c.Int(nullable: false),
                        bookingStatus = c.String(),
                    })
                .PrimaryKey(t => t.RequestId);
            
            CreateTable(
                "dbo.WeeklyLifts",
                c => new
                    {
                        LiftID = c.Int(nullable: false, identity: true),
                        StartPoint = c.String(nullable: false, maxLength: 50),
                        EndPoint = c.String(nullable: false, maxLength: 50),
                        Monday = c.Boolean(nullable: false),
                        Tuesday = c.Boolean(nullable: false),
                        Wednesday = c.Boolean(nullable: false),
                        Thursday = c.Boolean(nullable: false),
                        Friday = c.Boolean(nullable: false),
                        Saturday = c.Boolean(nullable: false),
                        Sunday = c.Boolean(nullable: false),
                        OutboundStartTime = c.DateTime(nullable: false),
                        OutboundEndTime = c.DateTime(nullable: false),
                        InboundStartTime = c.DateTime(nullable: false),
                        InboundEndTime = c.DateTime(nullable: false),
                        UserEmailAddress = c.String(),
                        UserId = c.String(),
                        bookingStatus = c.String(),
                    })
                .PrimaryKey(t => t.LiftID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lifts", "requestLifts_RequestId", "dbo.RequestLifts");
            DropIndex("dbo.Lifts", new[] { "requestLifts_RequestId" });
            DropTable("dbo.WeeklyLifts");
            DropTable("dbo.RequestWeeklyLifts");
            DropTable("dbo.RequestLifts");
            DropTable("dbo.Lifts");
            DropTable("dbo.GMailers");
        }
    }
}
