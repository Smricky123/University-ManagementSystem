namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleupdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        viewRole = c.Boolean(nullable: false),
                        createRole = c.Boolean(nullable: false),
                        updateRole = c.Boolean(nullable: false),
                        deleteRole = c.Boolean(nullable: false),
                        masterRole = c.Boolean(nullable: false),
                        Admin_AdminId = c.Int(),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.Admins", t => t.Admin_AdminId)
                .Index(t => t.Admin_AdminId);
            
            AddColumn("dbo.Admins", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.Admins", "Role_RoleId", c => c.Int());
            AddColumn("dbo.Admins", "Role_RoleId1", c => c.Int());
            CreateIndex("dbo.Admins", "Role_RoleId");
            CreateIndex("dbo.Admins", "Role_RoleId1");
            AddForeignKey("dbo.Admins", "Role_RoleId", "dbo.Roles", "RoleId");
            AddForeignKey("dbo.Admins", "Role_RoleId1", "dbo.Roles", "RoleId");
            DropColumn("dbo.Admins", "ImagePath");
            DropColumn("dbo.Admins", "viewRole");
            DropColumn("dbo.Admins", "createRole");
            DropColumn("dbo.Admins", "updateRole");
            DropColumn("dbo.Admins", "deleteRole");
            DropColumn("dbo.Admins", "masterRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "masterRole", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "deleteRole", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "updateRole", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "createRole", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "viewRole", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "ImagePath", c => c.String());
            DropForeignKey("dbo.Roles", "Admin_AdminId", "dbo.Admins");
            DropForeignKey("dbo.Admins", "Role_RoleId1", "dbo.Roles");
            DropForeignKey("dbo.Admins", "Role_RoleId", "dbo.Roles");
            DropIndex("dbo.Roles", new[] { "Admin_AdminId" });
            DropIndex("dbo.Admins", new[] { "Role_RoleId1" });
            DropIndex("dbo.Admins", new[] { "Role_RoleId" });
            DropColumn("dbo.Admins", "Role_RoleId1");
            DropColumn("dbo.Admins", "Role_RoleId");
            DropColumn("dbo.Admins", "RoleId");
            DropTable("dbo.Roles");
        }
    }
}
