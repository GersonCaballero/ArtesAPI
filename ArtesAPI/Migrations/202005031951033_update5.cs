namespace ArtesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "IdCompanyType", "dbo.CompanyTypes");
            DropIndex("dbo.Companies", new[] { "IdCompanyType" });
            AddColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "State", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "Description");
            DropColumn("dbo.Companies", "IdCompanyType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "IdCompanyType", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Description", c => c.String());
            AlterColumn("dbo.Users", "State", c => c.String());
            DropColumn("dbo.Users", "Password");
            CreateIndex("dbo.Companies", "IdCompanyType");
            AddForeignKey("dbo.Companies", "IdCompanyType", "dbo.CompanyTypes", "IdCompanyType", cascadeDelete: true);
        }
    }
}
