using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        Task<T> SelectAsync(Guid id);
    }
}
