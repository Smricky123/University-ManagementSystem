namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dtosUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "Id");
        }
    }
}
