namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Offers");
            AddColumn("dbo.Offers", "BookId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Offers", "BookId");
            CreateIndex("dbo.Offers", "BookId");
            AddForeignKey("dbo.Offers", "BookId", "dbo.Books", "Id");
            DropColumn("dbo.Offers", "Book_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Offers", "Book_Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Offers", "BookId", "dbo.Books");
            DropIndex("dbo.Offers", new[] { "BookId" });
            DropPrimaryKey("dbo.Offers");
            DropColumn("dbo.Offers", "BookId");
            AddPrimaryKey("dbo.Offers", "Book_Id");
        }
    }
}
