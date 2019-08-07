namespace PodilskyNVK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SchoolDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchoolLessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolDay_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolDays", t => t.SchoolDay_Id)
                .Index(t => t.SchoolDay_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchoolLessons", "SchoolDay_Id", "dbo.SchoolDays");
            DropIndex("dbo.SchoolLessons", new[] { "SchoolDay_Id" });
            DropTable("dbo.SchoolLessons");
            DropTable("dbo.SchoolDays");
        }
    }
}
