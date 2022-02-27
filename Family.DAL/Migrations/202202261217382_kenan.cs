namespace Family.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kenan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MotherId = c.Int(nullable: false),
                        FatherId = c.Int(nullable: false),
                        MarriedDate = c.DateTime(nullable: false),
                        IsMaried = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.FatherId)
                .ForeignKey("dbo.People", t => t.MotherId)
                .Index(t => t.MotherId)
                .Index(t => t.FatherId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        BirthOfDay = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        IsLife = c.Boolean(nullable: false),
                        ParentId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parents", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        Relation = c.Int(nullable: false),
                        RequestDate = c.DateTime(nullable: false),
                        Response = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.ReceiverId)
                .ForeignKey("dbo.People", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parents", "MotherId", "dbo.People");
            DropForeignKey("dbo.Parents", "FatherId", "dbo.People");
            DropForeignKey("dbo.Requests", "SenderId", "dbo.People");
            DropForeignKey("dbo.Requests", "ReceiverId", "dbo.People");
            DropForeignKey("dbo.People", "ParentId", "dbo.Parents");
            DropIndex("dbo.Requests", new[] { "ReceiverId" });
            DropIndex("dbo.Requests", new[] { "SenderId" });
            DropIndex("dbo.People", new[] { "ParentId" });
            DropIndex("dbo.Parents", new[] { "FatherId" });
            DropIndex("dbo.Parents", new[] { "MotherId" });
            DropTable("dbo.Requests");
            DropTable("dbo.People");
            DropTable("dbo.Parents");
        }
    }
}
