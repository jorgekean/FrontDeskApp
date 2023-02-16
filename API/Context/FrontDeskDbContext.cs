using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{   
    public class FrontDeskDbContext : DbContext
    {
        #region Constructors
        public FrontDeskDbContext() : base()
        {
        }
        public FrontDeskDbContext(DbContextOptions<FrontDeskDbContext> options) : base(options)
        {
        }
        #endregion

        #region DbSets
        public DbSet<Customer> Customers { get; set; }
        public DbSet<StorageArea> StorageAreas { get; set; }
        public DbSet<BoxStorageStatus> BoxStorageStatuses { get; set; }
        #endregion

    }
}
