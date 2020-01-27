using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SqlContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(SqlContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var obj = await SelectAsync(id);
                if (obj == null)
                    return false;
                _dataset.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public async Task<T> InsertAsync(T obj)
        {
            try
            {
                if (obj.Id == Guid.Empty)
                    obj.Id = Guid.NewGuid();
                obj.CreateAt = DateTime.Now;
                _dataset.Add(obj);
                await _context.SaveChangesAsync();
            }   
            catch (Exception exc)
            {

                throw exc;
            }
            return obj;
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty || id == null)
                    return null;
                return await _dataset.SingleOrDefaultAsync(item => item.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T obj)
        {
            try
            {
                var originalObj = await SelectAsync(obj.Id);
                if (originalObj == null)
                    return null;
                obj.CreateAt = originalObj.CreateAt;
                obj.UpdateAt = DateTime.Now;
                _context.Entry(originalObj).CurrentValues.SetValues(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }
    }
}
