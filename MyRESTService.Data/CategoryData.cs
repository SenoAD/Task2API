using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRESTService.Data.Interfaces;
using MyRESTService.Data;
using MyRESTService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MyRESTService.Data
{
    public class CategoryData : ICategoryData
    {
        private readonly AppDbContext _appDbContext;
        public CategoryData(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task Delete(int id)
        {
            var category = await _appDbContext.Categories.FindAsync(id);
            _appDbContext.Categories.Remove(category);

            // Step 3: Save changes to persist the deletion
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _appDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _appDbContext.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<IEnumerable<Category>> GetByName(string name)
        {
            return await _appDbContext.Categories.Where(c => c.CategoryName.Contains(name)).ToListAsync();
        }
            
        public Task<int> GetCountCategories(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Insert(Category entity)
        {
            await _appDbContext.Categories.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public Task<int> InsertWithIdentity(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Update(int id, Category entity)
        {
            var category = await _appDbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            category.CategoryName = entity.CategoryName;
            await _appDbContext.SaveChangesAsync();
            return category;
        }
    }
}
