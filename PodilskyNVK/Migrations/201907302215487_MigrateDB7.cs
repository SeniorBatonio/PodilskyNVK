namespace PodilskyNVK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Emploees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Emploees", "AboutEmploee", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Emploees", "AboutEmploee", c => c.String());
            AlterColumn("dbo.Emploees", "Name", c => c.String());
        }
    }
}
