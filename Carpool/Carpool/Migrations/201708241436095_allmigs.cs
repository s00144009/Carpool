namespace Carpool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allmigs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lifts", "liftType", c => c.Int(nullable: false));
            AddColumn("dbo.Lifts", "Description", c => c.String());
            AddColumn("dbo.RequestLifts", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RequestLifts", "Description");
            DropColumn("dbo.Lifts", "Description");
            DropColumn("dbo.Lifts", "liftType");
        }
    }
}
