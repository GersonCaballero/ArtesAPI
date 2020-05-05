namespace ArtesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        IdColor = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImageURL = c.String(),
                        State = c.Boolean(nullable: false),
                        UserCreate = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UserModified = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        IdCompany = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdColor)
                .ForeignKey("dbo.Companies", t => t.IdCompany, cascadeDelete: true)
                .Index(t => t.IdCompany);
            
            CreateTable(
                "dbo.Fonts",
                c => new
                    {
                        IdFont = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        State = c.Boolean(nullable: false),
                        UserCreate = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UserModified = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        IdCompany = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFont)
                .ForeignKey("dbo.Companies", t => t.IdCompany, cascadeDelete: true)
                .Index(t => t.IdCompany);
            
            CreateTable(
                "dbo.GarmentColors",
                c => new
                    {
                        IdGarmentColor = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        State = c.Boolean(nullable: false),
                        UserCreate = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UserModified = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdGarmentColor);
            
            CreateTable(
                "dbo.ValueLogoes",
                c => new
                    {
                        IdValueLogo = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        State = c.Boolean(nullable: false),
                        UserCreate = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UserModified = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdValueLogo);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        IdPet = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImageURL = c.String(),
                        ArchiveURL = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserCreate = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UserModified = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        IdCompany = c.Int(nullable: false),
                        IdValueLogo = c.Int(nullable: false),
                        IdGarmentColor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPet)
                .ForeignKey("dbo.Companies", t => t.IdCompany, cascadeDelete: true)
                .ForeignKey("dbo.GarmentColors", t => t.IdGarmentColor, cascadeDelete: true)
                .ForeignKey("dbo.ValueLogoes", t => t.IdValueLogo, cascadeDelete: true)
                .Index(t => t.IdCompany)
                .Index(t => t.IdValueLogo)
                .Index(t => t.IdGarmentColor);
            
            CreateTable(
                "dbo.Rules",
                c => new
                    {
                        IdRule = c.Int(nullable: false, identity: true),
                        Rules = c.String(),
                        State = c.Boolean(nullable: false),
                        UserCreate = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UserModified = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        IdCompany = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRule)
                .ForeignKey("dbo.Companies", t => t.IdCompany, cascadeDelete: true)
                .Index(t => t.IdCompany);
            
            AddColumn("dbo.Arts", "ImageURL", c => c.String());
            AddColumn("dbo.Companies", "Code", c => c.String());
            AddColumn("dbo.Companies", "City", c => c.String());
            AddColumn("dbo.Companies", "Department", c => c.String());
            AddColumn("dbo.Companies", "ImageURL", c => c.String());
            AddColumn("dbo.Logoes", "ImageURL", c => c.String());
            AddColumn("dbo.Logoes", "ArchiveURL", c => c.String());
            AddColumn("dbo.Logoes", "IdValueLogo", c => c.Int(nullable: false));
            AddColumn("dbo.Logoes", "IdGarmentColor", c => c.Int(nullable: false));
            CreateIndex("dbo.Logoes", "IdValueLogo");
            CreateIndex("dbo.Logoes", "IdGarmentColor");
            AddForeignKey("dbo.Logoes", "IdGarmentColor", "dbo.GarmentColors", "IdGarmentColor", cascadeDelete: true);
            AddForeignKey("dbo.Logoes", "IdValueLogo", "dbo.ValueLogoes", "IdValueLogo", cascadeDelete: true);
            DropColumn("dbo.Arts", "Archive");
            DropColumn("dbo.Companies", "Rules");
            DropColumn("dbo.Companies", "Colors");
            DropColumn("dbo.Companies", "Pet");
            DropColumn("dbo.Companies", "Logos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "Logos", c => c.String());
            AddColumn("dbo.Companies", "Pet", c => c.String());
            AddColumn("dbo.Companies", "Colors", c => c.String());
            AddColumn("dbo.Companies", "Rules", c => c.String());
            AddColumn("dbo.Arts", "Archive", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Rules", "IdCompany", "dbo.Companies");
            DropForeignKey("dbo.Pets", "IdValueLogo", "dbo.ValueLogoes");
            DropForeignKey("dbo.Pets", "IdGarmentColor", "dbo.GarmentColors");
            DropForeignKey("dbo.Pets", "IdCompany", "dbo.Companies");
            DropForeignKey("dbo.Logoes", "IdValueLogo", "dbo.ValueLogoes");
            DropForeignKey("dbo.Logoes", "IdGarmentColor", "dbo.GarmentColors");
            DropForeignKey("dbo.Fonts", "IdCompany", "dbo.Companies");
            DropForeignKey("dbo.Colors", "IdCompany", "dbo.Companies");
            DropIndex("dbo.Rules", new[] { "IdCompany" });
            DropIndex("dbo.Pets", new[] { "IdGarmentColor" });
            DropIndex("dbo.Pets", new[] { "IdValueLogo" });
            DropIndex("dbo.Pets", new[] { "IdCompany" });
            DropIndex("dbo.Logoes", new[] { "IdGarmentColor" });
            DropIndex("dbo.Logoes", new[] { "IdValueLogo" });
            DropIndex("dbo.Fonts", new[] { "IdCompany" });
            DropIndex("dbo.Colors", new[] { "IdCompany" });
            DropColumn("dbo.Logoes", "IdGarmentColor");
            DropColumn("dbo.Logoes", "IdValueLogo");
            DropColumn("dbo.Logoes", "ArchiveURL");
            DropColumn("dbo.Logoes", "ImageURL");
            DropColumn("dbo.Companies", "ImageURL");
            DropColumn("dbo.Companies", "Department");
            DropColumn("dbo.Companies", "City");
            DropColumn("dbo.Companies", "Code");
            DropColumn("dbo.Arts", "ImageURL");
            DropTable("dbo.Rules");
            DropTable("dbo.Pets");
            DropTable("dbo.ValueLogoes");
            DropTable("dbo.GarmentColors");
            DropTable("dbo.Fonts");
            DropTable("dbo.Colors");
        }
    }
}
