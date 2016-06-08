namespace AirAtlantique.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedlogintosamacountname : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Employes", new[] { "login" });
            AddColumn("dbo.Employes", "samAccountName", c => c.String(maxLength: 20));
            CreateIndex("dbo.Employes", "samAccountName", unique: true);
            DropColumn("dbo.Employes", "login");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employes", "login", c => c.String(maxLength: 20));
            DropIndex("dbo.Employes", new[] { "samAccountName" });
            DropColumn("dbo.Employes", "samAccountName");
            CreateIndex("dbo.Employes", "login", unique: true);
        }
    }
}
