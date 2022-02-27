namespace Family.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xxvyhj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parents", "DivorceDate", c => c.Boolean(nullable: false));
            DropColumn("dbo.Parents", "Divorced");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parents", "Divorced", c => c.Boolean(nullable: false));
            DropColumn("dbo.Parents", "DivorceDate");
        }
    }
}
