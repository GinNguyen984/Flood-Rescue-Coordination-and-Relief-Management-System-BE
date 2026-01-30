
using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly RescueManagementDbContext _rescueManagementDbContext;

        public GenericRepository(RescueManagementDbContext rescueManagementDbContext) 
        {
            _rescueManagementDbContext = rescueManagementDbContext;
        }
        public async Task AddNewAsync(T itemToAdd)
        {
            await _rescueManagementDbContext.AddAsync(itemToAdd);
            await _rescueManagementDbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var item = await _rescueManagementDbContext.FindAsync<T>(id);

            if(item == null)
            {
                throw new Exception("Item not found");
            }
            _rescueManagementDbContext.Remove(item);

            int result = await _rescueManagementDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _rescueManagementDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _rescueManagementDbContext.FindAsync<T>(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            int result = await _rescueManagementDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task UpdateAsync(T itemToUpdate)
        {
            _rescueManagementDbContext.Update(itemToUpdate);
            await _rescueManagementDbContext.SaveChangesAsync();
        }
    }
}
