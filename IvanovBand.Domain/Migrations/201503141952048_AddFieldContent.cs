namespace IvanovBand.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Content", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Videos", "Content");
        }
    }
}
