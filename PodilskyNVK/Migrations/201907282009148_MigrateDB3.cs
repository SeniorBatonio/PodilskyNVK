namespace PodilskyNVK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "CreationDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "CreationDateTime");
        }
    }
}
