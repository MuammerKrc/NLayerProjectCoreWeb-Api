using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Serivces
{
    public interface IProductService:IService<Product>
    {
        bool ControlInnerBarcode(Product product);
        Task<Product> GetWithCategoryByIdAsync();

    }
}
