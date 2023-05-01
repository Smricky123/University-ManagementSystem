namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contextUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tokens", "AdminId", c => c.Int(nullable: false));
            DropColumn("dbo.Tokens", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tokens", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Tokens", "AdminId");
        }
    }
}
