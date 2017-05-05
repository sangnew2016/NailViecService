namespace Layer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldForInitation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        PhoneContact = c.String(nullable: false),
                        Salary = c.String(),
                        ImageUrl = c.String(),
                        JobId = c.Long(nullable: false),
                        JobTypeId = c.Long(nullable: false),
                        JobStatusId = c.Long(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobStatus", t => t.JobStatusId, cascadeDelete: true)
                .ForeignKey("dbo.JobTypes", t => t.JobTypeId, cascadeDelete: true)
                .Index(t => t.JobTypeId)
                .Index(t => t.JobStatusId);
            
            CreateTable(
                "dbo.JobStatus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobStatusHistories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobId = c.Long(nullable: false),
                        JobStatusId = c.Long(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobStatus", t => t.JobStatusId, cascadeDelete: true)
                .Index(t => t.JobStatusId);
            
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(),
                        FullAddress = c.String(),
                        Latitude = c.String(),
                        Longtitude = c.String(),
                        AreaName = c.String(),
                        StateName = c.String(),
                        CountryName = c.String(),
                        ShopId = c.Long(nullable: false),
                        TotalJobs = c.Double(nullable: false),
                        TotalShops = c.Double(nullable: false),
                        RowVersion = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShopOwners",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        ShopStatusId = c.Long(nullable: false),
                        PlaceId = c.Long(nullable: false),
                        ShopOwnerId = c.Long(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .ForeignKey("dbo.ShopStatus", t => t.ShopStatusId, cascadeDelete: true)
                .ForeignKey("dbo.ShopOwners", t => t.ShopOwnerId, cascadeDelete: true)
                .Index(t => t.ShopStatusId)
                .Index(t => t.PlaceId)
                .Index(t => t.ShopOwnerId);
            
            CreateTable(
                "dbo.ShopStatus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShopStatusHistories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ShopId = c.Long(nullable: false),
                        ShopStatusId = c.Long(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShopStatus", t => t.ShopStatusId, cascadeDelete: true)
                .Index(t => t.ShopStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shops", "ShopOwnerId", "dbo.ShopOwners");
            DropForeignKey("dbo.ShopStatusHistories", "ShopStatusId", "dbo.ShopStatus");
            DropForeignKey("dbo.Shops", "ShopStatusId", "dbo.ShopStatus");
            DropForeignKey("dbo.Shops", "PlaceId", "dbo.Places");
            DropForeignKey("dbo.Jobs", "JobTypeId", "dbo.JobTypes");
            DropForeignKey("dbo.JobStatusHistories", "JobStatusId", "dbo.JobStatus");
            DropForeignKey("dbo.Jobs", "JobStatusId", "dbo.JobStatus");
            DropIndex("dbo.ShopStatusHistories", new[] { "ShopStatusId" });
            DropIndex("dbo.Shops", new[] { "ShopOwnerId" });
            DropIndex("dbo.Shops", new[] { "PlaceId" });
            DropIndex("dbo.Shops", new[] { "ShopStatusId" });
            DropIndex("dbo.JobStatusHistories", new[] { "JobStatusId" });
            DropIndex("dbo.Jobs", new[] { "JobStatusId" });
            DropIndex("dbo.Jobs", new[] { "JobTypeId" });
            DropTable("dbo.ShopStatusHistories");
            DropTable("dbo.ShopStatus");
            DropTable("dbo.Shops");
            DropTable("dbo.ShopOwners");
            DropTable("dbo.Places");
            DropTable("dbo.JobTypes");
            DropTable("dbo.JobStatusHistories");
            DropTable("dbo.JobStatus");
            DropTable("dbo.Jobs");
        }
    }
}
