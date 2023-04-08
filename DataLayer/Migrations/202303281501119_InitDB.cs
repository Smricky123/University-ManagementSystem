namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Pass = c.String(maxLength: 8),
                        Name = c.String(),
                        Phone = c.String(maxLength: 11),
                        ImagePath = c.String(),
                        viewRole = c.Boolean(nullable: false),
                        createRole = c.Boolean(nullable: false),
                        updateRole = c.Boolean(nullable: false),
                        deleteRole = c.Boolean(nullable: false),
                        masterRole = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Credit = c.Int(nullable: false),
                        FacultyMember_FacultyId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Faculties", t => t.FacultyMember_FacultyId)
                .Index(t => t.FacultyMember_FacultyId);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        Pass = c.String(maxLength: 8),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Designation = c.String(),
                        Phone = c.String(maxLength: 11),
                        ImagePath = c.String(),
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.FacultyId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .Index(t => t.Department_DepartmentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Pass = c.String(maxLength: 8),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Dept = c.String(),
                        Phone = c.String(maxLength: 11),
                        ImagePath = c.String(),
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .Index(t => t.Department_DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Course_CourseId })
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Course_CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Faculties", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.StudentCourses", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Courses", "FacultyMember_FacultyId", "dbo.Faculties");
            DropIndex("dbo.StudentCourses", new[] { "Course_CourseId" });
            DropIndex("dbo.StudentCourses", new[] { "Student_StudentId" });
            DropIndex("dbo.Students", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Faculties", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Courses", new[] { "FacultyMember_FacultyId" });
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Departments");
            DropTable("dbo.Students");
            DropTable("dbo.Faculties");
            DropTable("dbo.Courses");
            DropTable("dbo.Admins");
        }
    }
}
