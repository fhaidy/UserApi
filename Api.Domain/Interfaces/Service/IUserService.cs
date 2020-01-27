using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Service
{
    public interface IUserService
    {
        Task<User> Get(Guid id);
        Task<IEnumerable<User>> Get();
        Task<User> Put(User obj);
        Task<User> Post(User obj);
        Task<bool> Delete(Guid id);
    }
}
