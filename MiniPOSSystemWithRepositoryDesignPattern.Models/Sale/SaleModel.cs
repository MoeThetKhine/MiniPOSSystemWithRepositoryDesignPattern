using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Sale
{
    public class SaleModel
    {
        public string SaleId { get; set; } = null!;

        public string InvoiceId { get; set; } = null!;

        public string ProductId { get; set; } = null!;

        public int ProductQty { get; set; }

        public decimal UnitPrice { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
