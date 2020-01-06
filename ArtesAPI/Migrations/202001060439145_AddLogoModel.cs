namespace ArtesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogoModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logoes",
                c => new
                    {
                        IdLogo = c.Int(nullable: false, identity: true),
                        NameLogo = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserCreate = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UserModified = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        IdCompany = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdLogo)
                .ForeignKey("dbo.Companies", t => t.IdCompany, cascadeDelete: true)
                .Index(t => t.IdCompany);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logoes", "IdCompany", "dbo.Companies");
            DropIndex("dbo.Logoes", new[] { "IdCompany" });
            DropTable("dbo.Logoes");
        }
    }
}
