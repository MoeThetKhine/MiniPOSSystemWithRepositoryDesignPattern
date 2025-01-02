namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Invoice;

#region InvoiceRequestModel

public class InvoiceRequestModel
{
    public DateTime? InvoiceDate { get; set; }

    public decimal? TotalAmount { get; set; }

}

#endregion