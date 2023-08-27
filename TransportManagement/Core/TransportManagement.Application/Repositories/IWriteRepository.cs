using TransportManagement.Entities.Entities;

namespace TransportManagement.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> RemoveAsync(string id);
        bool Remove(T model);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
