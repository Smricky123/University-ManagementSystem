namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleAssign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "masterRole", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "masterRole");
        }
    }
}
