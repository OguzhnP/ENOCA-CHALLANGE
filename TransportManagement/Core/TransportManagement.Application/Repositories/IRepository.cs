
using TransportManagement.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace TransportManagement.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
