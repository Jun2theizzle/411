namespace ClassCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseFix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserComment = c.String(),
                        Lecture_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lectures", t => t.Lecture_ID)
                .Index(t => t.Lecture_ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CRN = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Lectures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CourseID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Lecture_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lectures", t => t.Lecture_ID)
                .Index(t => t.Lecture_ID);
            
            CreateTable(
                "dbo.UserDatas",
                c => new
                    {
                        UserDataID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Points = c.Int(nullable: false),
                        UserType = c.Int(),
                    })
                .PrimaryKey(t => t.UserDataID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserDataCourses",
                c => new
                    {
                        UserData_UserDataID = c.Int(nullable: false),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserData_UserDataID, t.Course_ID })
                .ForeignKey("dbo.UserDatas", t => t.UserData_UserDataID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_ID, cascadeDelete: true)
                .Index(t => t.UserData_UserDataID)
                .Index(t => t.Course_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserDataCourses", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.UserDataCourses", "UserData_UserDataID", "dbo.UserDatas");
            DropForeignKey("dbo.Notes", "Lecture_ID", "dbo.Lectures");
            DropForeignKey("dbo.Comments", "Lecture_ID", "dbo.Lectures");
            DropForeignKey("dbo.Lectures", "CourseID", "dbo.Courses");
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.UserDataCourses", new[] { "Course_ID" });
            DropIndex("dbo.UserDataCourses", new[] { "UserData_UserDataID" });
            DropIndex("dbo.Notes", new[] { "Lecture_ID" });
            DropIndex("dbo.Comments", new[] { "Lecture_ID" });
            DropIndex("dbo.Lectures", new[] { "CourseID" });
            DropTable("dbo.UserDataCourses");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UserDatas");
            DropTable("dbo.Notes");
            DropTable("dbo.Lectures");
            DropTable("dbo.Courses");
            DropTable("dbo.Comments");
        }
    }
}
