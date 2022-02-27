namespace Family.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xxx : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parents", "Divorced", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parents", "Divorced");
        }
    }
}
