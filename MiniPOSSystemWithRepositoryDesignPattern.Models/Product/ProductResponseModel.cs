using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Product
{
    public class ProductResponseModel
    {
        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public string? ProductCategoryId { get; set; }
    }
}
