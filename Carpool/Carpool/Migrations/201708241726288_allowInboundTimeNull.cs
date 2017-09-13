namespace Carpool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allowInboundTimeNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RequestLifts", "InboundTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RequestLifts", "InboundTime", c => c.DateTime(nullable: false));
        }
    }
}
