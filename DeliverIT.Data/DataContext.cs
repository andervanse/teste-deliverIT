using DeliverIT.Data.Mappings;
using DeliverIT.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeliverIT.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ContaPagar> ContasPagar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaPagarConfiguration());
        }
    }
}
