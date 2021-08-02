namespace climateResearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.measuring_instrument", "name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.measuring_instrument", "description", c => c.String(maxLength: 300));
            AlterColumn("dbo.observation_point", "name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.observation_point", "description", c => c.String(maxLength: 300));
            AlterColumn("dbo.sensor", "name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.physical_quantity", "name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.physical_quantity", "name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.sensor", "name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.observation_point", "description", c => c.String(maxLength: 100));
            AlterColumn("dbo.observation_point", "name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.measuring_instrument", "description", c => c.String(maxLength: 100));
            AlterColumn("dbo.measuring_instrument", "name", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
