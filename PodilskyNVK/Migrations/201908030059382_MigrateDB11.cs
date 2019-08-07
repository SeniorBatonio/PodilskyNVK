namespace PodilskyNVK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SchoolLessons", "SchoolDay_Id", "dbo.SchoolDays");
            DropIndex("dbo.SchoolLessons", new[] { "SchoolDay_Id" });
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolDayId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolDays", t => t.SchoolDayId, cascadeDelete: true)
                .Index(t => t.SchoolDayId);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClassLessons",
                c => new
                    {
                        Class_Id = c.Int(nullable: false),
                        Lesson_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Class_Id, t.Lesson_Id })
                .ForeignKey("dbo.Classes", t => t.Class_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lessons", t => t.Lesson_Id, cascadeDelete: true)
                .Index(t => t.Class_Id)
                .Index(t => t.Lesson_Id);
            
            DropTable("dbo.SchoolLessons");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SchoolLessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolDay_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Lessons", "SchoolDayId", "dbo.SchoolDays");
            DropForeignKey("dbo.ClassLessons", "Lesson_Id", "dbo.Lessons");
            DropForeignKey("dbo.ClassLessons", "Class_Id", "dbo.Classes");
            DropIndex("dbo.ClassLessons", new[] { "Lesson_Id" });
            DropIndex("dbo.ClassLessons", new[] { "Class_Id" });
            DropIndex("dbo.Lessons", new[] { "SchoolDayId" });
            DropTable("dbo.ClassLessons");
            DropTable("dbo.Classes");
            DropTable("dbo.Lessons");
            CreateIndex("dbo.SchoolLessons", "SchoolDay_Id");
            AddForeignKey("dbo.SchoolLessons", "SchoolDay_Id", "dbo.SchoolDays", "Id");
        }
    }
}
