using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.Serivces;
using NLayerProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NlayerProject.Service
{
    public class ProductService : ServiceManager<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public bool ControlInnerBarcode(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetWithCategoryByIdAsync(int id)
        {
           return await _unitOfWork.Products.GetWithCategoryByIdAsync(id);
        }
    }
}
