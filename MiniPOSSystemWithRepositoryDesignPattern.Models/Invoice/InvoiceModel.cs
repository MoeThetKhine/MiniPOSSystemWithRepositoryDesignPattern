namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Invoice
{
    public class InvoiceModel
    {
        public string InvoiceId { get; set; } = null!;

        public decimal TotalAmount { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public bool? IsDelete { get; set; }
    }
}
