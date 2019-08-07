namespace PodilskyNVK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassLessons", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.ClassLessons", "Lesson_Id", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "SchoolDayId", "dbo.SchoolDays");
            DropIndex("dbo.Lessons", new[] { "SchoolDayId" });
            DropIndex("dbo.ClassLessons", new[] { "Class_Id" });
            DropIndex("dbo.ClassLessons", new[] { "Lesson_Id" });
            DropTable("dbo.SchoolDays");
            DropTable("dbo.Lessons");
            DropTable("dbo.Classes");
            DropTable("dbo.ClassLessons");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClassLessons",
                c => new
                    {
                        Class_Id = c.Int(nullable: false),
                        Lesson_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Class_Id, t.Lesson_Id });
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolDayId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchoolDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ClassLessons", "Lesson_Id");
            CreateIndex("dbo.ClassLessons", "Class_Id");
            CreateIndex("dbo.Lessons", "SchoolDayId");
            AddForeignKey("dbo.Lessons", "SchoolDayId", "dbo.SchoolDays", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClassLessons", "Lesson_Id", "dbo.Lessons", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClassLessons", "Class_Id", "dbo.Classes", "Id", cascadeDelete: true);
        }
    }
}
