namespace PTCG_Tracker.Data.Migrations 
{

    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationFirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CardCollections1",
                c => new
                    {
                        CardId = c.String(nullable: false, maxLength: 128),
                        CollectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CardCollections1");
        }
    }
}
