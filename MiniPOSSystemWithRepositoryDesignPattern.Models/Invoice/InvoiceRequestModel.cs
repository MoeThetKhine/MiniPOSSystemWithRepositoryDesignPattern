namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Invoice;

public class InvoiceRequestModel
{
    public DateTime? InvoiceDate { get; set; }

    public decimal? TotalAmount { get; set; }

}
