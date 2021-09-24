using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using NLayerProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Repositories
{
    class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        protected AppDbContext _context => _dbContext as AppDbContext;

        public async Task<Category> GetWithProductsByIdAsync(int id)
        {
            return await _context.Categories
                                        .Include(i => i.Products)
                                        .SingleOrDefaultAsync(i=>i.Id==id);
        }
    }
}
