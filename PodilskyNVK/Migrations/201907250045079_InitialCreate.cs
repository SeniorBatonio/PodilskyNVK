namespace PodilskyNVK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emploees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AboutEmploee = c.String(),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.Post_Id);
            
            CreateTable(
                "dbo.PostThemes",
                c => new
                    {
                        PostThemeId = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        ThemeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostThemeId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Themes", t => t.ThemeId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.ThemeId);
            
            CreateTable(
                "dbo.Themes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostThemes", "ThemeId", "dbo.Themes");
            DropForeignKey("dbo.PostThemes", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Photos", "Post_Id", "dbo.Posts");
            DropIndex("dbo.PostThemes", new[] { "ThemeId" });
            DropIndex("dbo.PostThemes", new[] { "PostId" });
            DropIndex("dbo.Photos", new[] { "Post_Id" });
            DropTable("dbo.Themes");
            DropTable("dbo.PostThemes");
            DropTable("dbo.Photos");
            DropTable("dbo.Posts");
            DropTable("dbo.Emploees");
        }
    }
}
