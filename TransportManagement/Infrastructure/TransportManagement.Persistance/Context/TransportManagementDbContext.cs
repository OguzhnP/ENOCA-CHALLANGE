using Microsoft.EntityFrameworkCore;
using TransportManagement.Entities.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TransportManagement.Persistance.Context
{
    public class TransportManagementDbContext : DbContext
    {

        public TransportManagementDbContext(DbContextOptions<TransportManagementDbContext> options) : base(options)
        { }
        public DbSet<Carriers> Carriers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<CarrierConfigurations> CarrierConfigurations { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker:  entityler üzerinde yapılan değişikliklerin ya da yeni eklenen verilerin yakalanmasını sağlayan prop'tur, update operasyonlarında track edilen verileri yakalar ve elde etmemizi sağlar.

            var datas = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow,
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
