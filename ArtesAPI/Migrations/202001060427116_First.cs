namespace ArtesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arts",
                c => new
                    {
                        IdArt = c.Int(nullable: false, identity: true),
                        ArtName = c.String(),
                        Description = c.String(),
                        Archive = c.Byte(nullable: false),
                        State = c.Boolean(nullable: false),
                        UserCreate = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UserModified = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdArt)
                .ForeignKey("dbo.Users", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Description = c.String(),
                        State = c.String(),
                        UserCreate = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UserModified = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        IdUserType = c.Int(nullable: false),
                        IdCompany = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUser)
                .ForeignKey("dbo.Companies", t => t.IdCompany, cascadeDelete: true)
                .ForeignKey("dbo.UserTypes", t => t.IdUserType, cascadeDelete: true)
                .Index(t => t.IdUserType)
                .Index(t => t.IdCompany);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        IdCompany = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Description = c.String(),
                        Rules = c.String(),
                        Direction = c.String(),
                        State = c.Boolean(nullable: false),
                        Colors = c.String(),
                        Pet = c.String(),
                        Logos = c.String(),
                        UserCreate = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UserModified = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        IdCompanyType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCompany)
                .ForeignKey("dbo.CompanyTypes", t => t.IdCompanyType, cascadeDelete: true)
                .Index(t => t.IdCompanyType);
            
            CreateTable(
                "dbo.CompanyTypes",
                c => new
                    {
                        IdCompanyType = c.Int(nullable: false, identity: true),
                        CompanyTypeName = c.String(),
                        State = c.Boolean(nullable: false),
                        UserCreate = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UserModified = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdCompanyType);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        IdUserType = c.Int(nullable: false, identity: true),
                        UserTypeName = c.String(),
                        State = c.Boolean(nullable: false),
                        UserCreate = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UserModified = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdUserType);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arts", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Users", "IdUserType", "dbo.UserTypes");
            DropForeignKey("dbo.Users", "IdCompany", "dbo.Companies");
            DropForeignKey("dbo.Companies", "IdCompanyType", "dbo.CompanyTypes");
            DropIndex("dbo.Companies", new[] { "IdCompanyType" });
            DropIndex("dbo.Users", new[] { "IdCompany" });
            DropIndex("dbo.Users", new[] { "IdUserType" });
            DropIndex("dbo.Arts", new[] { "IdUser" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.CompanyTypes");
            DropTable("dbo.Companies");
            DropTable("dbo.Users");
            DropTable("dbo.Arts");
        }
    }
}
