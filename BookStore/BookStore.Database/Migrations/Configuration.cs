using System.Data.Entity.Migrations;

namespace BookStore.Data.Migrations
{

    public sealed class Configuration : DbMigrationsConfiguration<BookStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BookStoreContext context)
        {
            
        }
    }
}
