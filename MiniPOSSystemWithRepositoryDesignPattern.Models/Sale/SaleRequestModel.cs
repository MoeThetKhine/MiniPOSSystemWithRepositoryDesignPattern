using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Sale
{
    public class SaleRequestModel
    {
        public string? ProductId { get; set; }

        public string? InvoiceId { get; set; }

        public decimal? UnitPrice { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
