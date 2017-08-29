using System.Data.Entity;
using Pictures.DAL.Models;


namespace Pictures.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("TestDB")
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<PictureDbo> Pictures { get; set; }
    }
}
