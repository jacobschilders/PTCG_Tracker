namespace PTCG_Tracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abilities",
                c => new
                    {
                        AbilityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Text = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.AbilityId);
            
            CreateTable(
                "dbo.Attacks",
                c => new
                    {
                        AttackId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Text = c.String(),
                        Damage = c.String(),
                        Card_CardId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AttackId)
                .ForeignKey("dbo.Cards", t => t.Card_CardId)
                .Index(t => t.Card_CardId);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        ImageURL = c.String(),
                        Type = c.String(nullable: false),
                        SuperType = c.String(nullable: false),
                        SubType = c.String(nullable: false),
                        HP = c.Int(nullable: false),
                        RetreatCost = c.Int(nullable: false),
                        SetNumber = c.Int(nullable: false),
                        Series = c.String(),
                        Set = c.String(),
                        WeaknessId = c.Int(),
                        ResistanceId = c.Int(),
                        AbilityId = c.Int(),
                        Artist = c.String(),
                        Rarity = c.String(),
                    })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.Abilities", t => t.AbilityId)
                .ForeignKey("dbo.Resistances", t => t.ResistanceId)
                .ForeignKey("dbo.Weaknesses", t => t.WeaknessId)
                .Index(t => t.WeaknessId)
                .Index(t => t.ResistanceId)
                .Index(t => t.AbilityId);
            
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        CollectionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Public = c.Boolean(nullable: false),
                        CardsUntilComplete = c.Int(nullable: false),
                        ModifiedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.CollectionId);
            
            CreateTable(
                "dbo.Resistances",
                c => new
                    {
                        ResistanceId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.ResistanceId);
            
            CreateTable(
                "dbo.Weaknesses",
                c => new
                    {
                        WeaknessId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.WeaknessId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CardCollections",
                c => new
                    {
                        CollectionId = c.String(nullable: false, maxLength: 128),
                        CardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CollectionId, t.CardId })
                .ForeignKey("dbo.Cards", t => t.CollectionId, cascadeDelete: true)
                .ForeignKey("dbo.Collections", t => t.CardId, cascadeDelete: true)
                .Index(t => t.CollectionId)
                .Index(t => t.CardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Cards", "WeaknessId", "dbo.Weaknesses");
            DropForeignKey("dbo.Cards", "ResistanceId", "dbo.Resistances");
            DropForeignKey("dbo.CardCollections", "CardId", "dbo.Collections");
            DropForeignKey("dbo.CardCollections", "CollectionId", "dbo.Cards");
            DropForeignKey("dbo.Attacks", "Card_CardId", "dbo.Cards");
            DropForeignKey("dbo.Cards", "AbilityId", "dbo.Abilities");
            DropIndex("dbo.CardCollections", new[] { "CardId" });
            DropIndex("dbo.CardCollections", new[] { "CollectionId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Cards", new[] { "AbilityId" });
            DropIndex("dbo.Cards", new[] { "ResistanceId" });
            DropIndex("dbo.Cards", new[] { "WeaknessId" });
            DropIndex("dbo.Attacks", new[] { "Card_CardId" });
            DropTable("dbo.CardCollections");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Weaknesses");
            DropTable("dbo.Resistances");
            DropTable("dbo.Collections");
            DropTable("dbo.Cards");
            DropTable("dbo.Attacks");
            DropTable("dbo.Abilities");
        }
    }
}
