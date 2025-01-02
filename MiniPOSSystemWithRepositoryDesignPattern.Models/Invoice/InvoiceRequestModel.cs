using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Invoice
{
    public class InvoiceRequestModel
    {
        public DateTime? InvoiceDate { get; set; }

        public decimal? TotalAmount { get; set; }

    }
}
