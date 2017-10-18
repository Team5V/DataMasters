namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOffer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Offers", "Sold");
            DropTable("dbo.Sales");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Date = c.DateTime(nullable: false),
                        Offers = c.String(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Date);
            
            AddColumn("dbo.Offers", "Sold", c => c.Int(nullable: false));
        }
    }
}
