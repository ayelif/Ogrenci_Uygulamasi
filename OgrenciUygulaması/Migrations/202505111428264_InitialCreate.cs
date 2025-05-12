namespace OgrenciUygulaması.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tBolums",
                c => new
                    {
                        bolumID = c.Int(nullable: false, identity: true),
                        bolumAd = c.String(),
                        fakulteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.bolumID)
                .ForeignKey("dbo.tFakultes", t => t.fakulteID, cascadeDelete: true)
                .Index(t => t.fakulteID);
            
            CreateTable(
                "dbo.tFakultes",
                c => new
                    {
                        fakulteID = c.Int(nullable: false, identity: true),
                        fakulteAd = c.String(),
                    })
                .PrimaryKey(t => t.fakulteID);
            
            CreateTable(
                "dbo.tOgrencis",
                c => new
                    {
                        ogrenciID = c.Int(nullable: false, identity: true),
                        ad = c.String(),
                        soyad = c.String(),
                        bolumID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ogrenciID)
                .ForeignKey("dbo.tBolums", t => t.bolumID, cascadeDelete: true)
                .Index(t => t.bolumID);
            
            CreateTable(
                "dbo.tOgrenciDers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ogrenciID = c.Int(nullable: false),
                        dersID = c.Int(nullable: false),
                        yil = c.String(),
                        yariyil = c.String(),
                        vize = c.Int(nullable: false),
                        final = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tDers", t => t.dersID, cascadeDelete: true)
                .ForeignKey("dbo.tOgrencis", t => t.ogrenciID, cascadeDelete: true)
                .Index(t => t.ogrenciID)
                .Index(t => t.dersID);
            
            CreateTable(
                "dbo.tDers",
                c => new
                    {
                        dersID = c.Int(nullable: false, identity: true),
                        dersAd = c.String(),
                    })
                .PrimaryKey(t => t.dersID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tOgrenciDers", "ogrenciID", "dbo.tOgrencis");
            DropForeignKey("dbo.tOgrenciDers", "dersID", "dbo.tDers");
            DropForeignKey("dbo.tOgrencis", "bolumID", "dbo.tBolums");
            DropForeignKey("dbo.tBolums", "fakulteID", "dbo.tFakultes");
            DropIndex("dbo.tOgrenciDers", new[] { "dersID" });
            DropIndex("dbo.tOgrenciDers", new[] { "ogrenciID" });
            DropIndex("dbo.tOgrencis", new[] { "bolumID" });
            DropIndex("dbo.tBolums", new[] { "fakulteID" });
            DropTable("dbo.tDers");
            DropTable("dbo.tOgrenciDers");
            DropTable("dbo.tOgrencis");
            DropTable("dbo.tFakultes");
            DropTable("dbo.tBolums");
        }
    }
}
