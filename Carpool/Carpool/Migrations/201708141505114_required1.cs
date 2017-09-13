namespace Carpool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lifts", "InboundStartTime", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Lifts", "InboundEndTime", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lifts", "InboundEndTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Lifts", "InboundStartTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}
