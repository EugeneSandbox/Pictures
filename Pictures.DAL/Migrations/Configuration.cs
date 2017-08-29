using System.Data.Entity.Migrations;



namespace Pictures.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(DatabaseContext context)
        {
        }

       
    }
}
