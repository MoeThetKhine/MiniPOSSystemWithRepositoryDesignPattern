namespace MiniPOSSystemWithRepositoryDesignPattern.Database.Models;

public partial class Invoice
{
    public string InvoiceId { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public bool? IsDelete { get; set; }
}
