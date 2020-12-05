namespace PTCG_Tracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attacks", "EnergyCost", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attacks", "EnergyCost");
        }
    }
}
