namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleModelUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoleAdmins", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleAdmins", "Admin_AdminId", "dbo.Admins");
            DropIndex("dbo.RoleAdmins", new[] { "Role_RoleId" });
            DropIndex("dbo.RoleAdmins", new[] { "Admin_AdminId" });
            AddColumn("dbo.Admins", "Role_RoleId", c => c.Int());
            AddColumn("dbo.Admins", "Role_RoleId1", c => c.Int());
            AddColumn("dbo.Roles", "Admin_AdminId", c => c.Int());
            CreateIndex("dbo.Admins", "Role_RoleId");
            CreateIndex("dbo.Admins", "Role_RoleId1");
            CreateIndex("dbo.Roles", "Admin_AdminId");
            AddForeignKey("dbo.Admins", "Role_RoleId", "dbo.Roles", "RoleId");
            AddForeignKey("dbo.Admins", "Role_RoleId1", "dbo.Roles", "RoleId");
            AddForeignKey("dbo.Roles", "Admin_AdminId", "dbo.Admins", "AdminId");
            DropTable("dbo.RoleAdmins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoleAdmins",
                c => new
                    {
                        Role_RoleId = c.Int(nullable: false),
                        Admin_AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleId, t.Admin_AdminId });
            
            DropForeignKey("dbo.Roles", "Admin_AdminId", "dbo.Admins");
            DropForeignKey("dbo.Admins", "Role_RoleId1", "dbo.Roles");
            DropForeignKey("dbo.Admins", "Role_RoleId", "dbo.Roles");
            DropIndex("dbo.Roles", new[] { "Admin_AdminId" });
            DropIndex("dbo.Admins", new[] { "Role_RoleId1" });
            DropIndex("dbo.Admins", new[] { "Role_RoleId" });
            DropColumn("dbo.Roles", "Admin_AdminId");
            DropColumn("dbo.Admins", "Role_RoleId1");
            DropColumn("dbo.Admins", "Role_RoleId");
            CreateIndex("dbo.RoleAdmins", "Admin_AdminId");
            CreateIndex("dbo.RoleAdmins", "Role_RoleId");
            AddForeignKey("dbo.RoleAdmins", "Admin_AdminId", "dbo.Admins", "AdminId", cascadeDelete: true);
            AddForeignKey("dbo.RoleAdmins", "Role_RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
        }
    }
}
