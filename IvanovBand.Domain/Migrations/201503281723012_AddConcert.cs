namespace IvanovBand.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConcert : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Concerts",
                c => new
                    {
                        ConcertId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ConcertId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Concerts");
        }
    }
}
