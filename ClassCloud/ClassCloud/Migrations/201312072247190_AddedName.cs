namespace ClassCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedName : DbMigration
    {
        public override void Up()
        {

            AddColumn("dbo.Notes", "Name", c => c.String(nullable : false));

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "UserData_UserDataID", "dbo.UserDatas");
            DropForeignKey("dbo.Lectures", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Comments", "Lecture_ID", "dbo.Lectures");
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Courses", new[] { "UserData_UserDataID" });
            DropIndex("dbo.Lectures", new[] { "CourseID" });
            DropIndex("dbo.Comments", new[] { "Lecture_ID" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserDatas");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Notes");
            DropTable("dbo.Lectures");
            DropTable("dbo.Courses");
            DropTable("dbo.Comments");
        }
    }
}
