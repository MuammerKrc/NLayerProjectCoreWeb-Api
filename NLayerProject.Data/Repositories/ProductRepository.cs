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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        protected AppDbContext appDbContext { get => _dbContext as AppDbContext; }

        public async Task<Product> GetWithCategoryByIdAsync(int id)
        {
            var product = await appDbContext.Products.Where(i => i.Id == id)
                                                    .Include(i => i.Category)
                                                    .FirstOrDefaultAsync();
            return product;
        }

    }
}
