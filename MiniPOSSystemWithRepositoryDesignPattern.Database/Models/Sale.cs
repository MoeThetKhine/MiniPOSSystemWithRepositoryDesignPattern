namespace MiniPOSSystemWithRepositoryDesignPattern.Database.Models;

public partial class Sale
{
    public string SaleId { get; set; } = null!;

    public string InvoiceId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public int ProductQty { get; set; }

    public decimal UnitPrice { get; set; }

    public DateTime? CreateDate { get; set; }
}
