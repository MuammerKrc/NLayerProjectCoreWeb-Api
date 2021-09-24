using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly List<int> _categoryId;

        public ProductSeed(List<int> categoryId)
        {
            _categoryId = categoryId;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product() { Id = 1, Name = "Pilot Kalem", Price = 12.653m, Stock = 100, CategoryId = _categoryId[0] },
                new Product() { Id = 2, Name = "Kurşun Kalem", Price = 2.653m, Stock = 50, CategoryId = _categoryId[0] },
                new Product() { Id = 3, Name = "Tükenmez Kalem", Price = 7.2753m, Stock = 25, CategoryId = _categoryId[0] },
                new Product() { Id = 4, Name = "Cizgili Defter", Price = 3.653m, Stock = 100, CategoryId = _categoryId[1] },
                new Product() { Id = 5, Name = "Kareli Defter", Price = 4.653m, Stock = 75, CategoryId = _categoryId[1] }
                );
        }

        
    }
}
