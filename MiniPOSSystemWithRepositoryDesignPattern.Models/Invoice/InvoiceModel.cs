namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Invoice;

#region InvoiceModel

public class InvoiceModel
{
    public string InvoiceId { get; set; } = null!;

    public DateTime? InvoiceDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public bool? IsDelete { get; set; }
}

#endregion
