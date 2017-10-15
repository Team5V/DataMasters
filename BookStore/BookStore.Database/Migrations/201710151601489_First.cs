namespace BookStore.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "FullName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Authors", "Bio", c => c.String(maxLength: 200));
            AddColumn("dbo.Books", "Language", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Books", "Genre", c => c.Int(nullable: false));
            DropColumn("dbo.Authors", "FirstName");
            DropColumn("dbo.Authors", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "LastName", c => c.String());
            AddColumn("dbo.Authors", "FirstName", c => c.String());
            AlterColumn("dbo.Books", "Genre", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String());
            DropColumn("dbo.Books", "Language");
            DropColumn("dbo.Authors", "Bio");
            DropColumn("dbo.Authors", "FullName");
        }
    }
}
