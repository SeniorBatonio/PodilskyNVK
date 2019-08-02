namespace PodilskyNVK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostThemes", "PostId", "dbo.Posts");
            DropForeignKey("dbo.PostThemes", "ThemeId", "dbo.Themes");
            DropIndex("dbo.PostThemes", new[] { "PostId" });
            DropIndex("dbo.PostThemes", new[] { "ThemeId" });
            CreateTable(
                "dbo.ThemePosts",
                c => new
                    {
                        Theme_Id = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Theme_Id, t.Post_Id })
                .ForeignKey("dbo.Themes", t => t.Theme_Id, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Theme_Id)
                .Index(t => t.Post_Id);
            
            DropTable("dbo.PostThemes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PostThemes",
                c => new
                    {
                        PostThemeId = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        ThemeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostThemeId);
            
            DropForeignKey("dbo.ThemePosts", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.ThemePosts", "Theme_Id", "dbo.Themes");
            DropIndex("dbo.ThemePosts", new[] { "Post_Id" });
            DropIndex("dbo.ThemePosts", new[] { "Theme_Id" });
            DropTable("dbo.ThemePosts");
            CreateIndex("dbo.PostThemes", "ThemeId");
            CreateIndex("dbo.PostThemes", "PostId");
            AddForeignKey("dbo.PostThemes", "ThemeId", "dbo.Themes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PostThemes", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
