namespace Carpool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saturday : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RequestWeeklyLifts", "SaturdayStartTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.RequestWeeklyLifts", "SaturdayEndTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RequestWeeklyLifts", "SaturdayEndTime", c => c.DateTime());
            AlterColumn("dbo.RequestWeeklyLifts", "SaturdayStartTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
