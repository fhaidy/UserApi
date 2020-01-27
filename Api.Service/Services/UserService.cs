using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);           
        }

        public async Task<User> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _repository.SelectAsync();
        }

        public async Task<User> Post(User obj)
        {
            return await _repository.InsertAsync(obj);
        }

        public async Task<User> Put(User obj)
        {
            return await _repository.UpdateAsync(obj);
        }
    }
}
