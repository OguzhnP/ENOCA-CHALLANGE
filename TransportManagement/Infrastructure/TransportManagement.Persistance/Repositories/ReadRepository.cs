
using Microsoft.EntityFrameworkCore;
using TransportManagement.Application.Repositories;
using TransportManagement.Entities.Entities;
using TransportManagement.Persistance.Context;

namespace TransportManagement.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly TransportManagementDbContext _context;

        public ReadRepository(TransportManagementDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

       

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
           
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(data => data.Id == int.Parse(id));
        }

    }
}
