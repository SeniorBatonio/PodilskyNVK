namespace PodilskyNVK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Header", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Posts", "Text", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Text", c => c.String());
            AlterColumn("dbo.Posts", "Header", c => c.String());
        }
    }
}
