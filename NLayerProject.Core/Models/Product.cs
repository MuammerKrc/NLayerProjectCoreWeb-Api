using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int  Stock { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public string InnerBarcode { get; set; }
        public Category Category { get; set; }
    }
}
