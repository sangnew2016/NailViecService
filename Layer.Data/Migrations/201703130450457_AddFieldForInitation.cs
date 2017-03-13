namespace Layer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldForInitation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        StateId = c.Long(nullable: false),
                        TotalJobs = c.Double(nullable: false),
                        TotalShops = c.Double(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Longtitude = c.String(),
                        Latitude = c.String(),
                        UserId = c.Guid(nullable: false),
                        CityId = c.Long(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        CountryId = c.Long(nullable: false),
                        TotalJobs = c.Double(nullable: false),
                        TotalShops = c.Double(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        TotalJobs = c.Double(nullable: false),
                        TotalShops = c.Double(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        PhoneContact = c.String(nullable: false),
                        Salary = c.String(),
                        ImageUrl = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        NewsType_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsTypes", t => t.NewsType_Id)
                .Index(t => t.NewsType_Id);
            
            CreateTable(
                "dbo.NewsTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsHistories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NewsId = c.Long(nullable: false),
                        NewsStatusId = c.Long(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.News", t => t.NewsId, cascadeDelete: true)
                .ForeignKey("dbo.NewsStatus", t => t.NewsStatusId, cascadeDelete: true)
                .Index(t => t.NewsId)
                .Index(t => t.NewsStatusId);
            
            CreateTable(
                "dbo.NewsStatus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsHistories", "NewsStatusId", "dbo.NewsStatus");
            DropForeignKey("dbo.NewsHistories", "NewsId", "dbo.News");
            DropForeignKey("dbo.News", "NewsType_Id", "dbo.NewsTypes");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropForeignKey("dbo.Shops", "CityId", "dbo.Cities");
            DropIndex("dbo.NewsHistories", new[] { "NewsStatusId" });
            DropIndex("dbo.NewsHistories", new[] { "NewsId" });
            DropIndex("dbo.News", new[] { "NewsType_Id" });
            DropIndex("dbo.States", new[] { "CountryId" });
            DropIndex("dbo.Shops", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "StateId" });
            DropTable("dbo.NewsStatus");
            DropTable("dbo.NewsHistories");
            DropTable("dbo.NewsTypes");
            DropTable("dbo.News");
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.Shops");
            DropTable("dbo.Cities");
        }
    }
}
