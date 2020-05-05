namespace ArtesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Arts", "IdUser", "dbo.Users");
            DropIndex("dbo.Arts", new[] { "IdUser" });
            AddColumn("dbo.Arts", "IdCompany", c => c.Int(nullable: false));
            CreateIndex("dbo.Arts", "IdCompany");
            AddForeignKey("dbo.Arts", "IdCompany", "dbo.Companies", "IdCompany", cascadeDelete: true);
            DropColumn("dbo.Arts", "IdUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Arts", "IdUser", c => c.Int(nullable: false));
            DropForeignKey("dbo.Arts", "IdCompany", "dbo.Companies");
            DropIndex("dbo.Arts", new[] { "IdCompany" });
            DropColumn("dbo.Arts", "IdCompany");
            CreateIndex("dbo.Arts", "IdUser");
            AddForeignKey("dbo.Arts", "IdUser", "dbo.Users", "IdUser", cascadeDelete: true);
        }
    }
}
