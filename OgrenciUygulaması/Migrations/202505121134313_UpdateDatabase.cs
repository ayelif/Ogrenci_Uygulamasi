namespace OgrenciUygulaması.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tOgrenciDers", "vize", c => c.Int());
            AlterColumn("dbo.tOgrenciDers", "final", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tOgrenciDers", "final", c => c.Int(nullable: false));
            AlterColumn("dbo.tOgrenciDers", "vize", c => c.Int(nullable: false));
        }
    }
}
