namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Sale;

#region SaleRequestModel

public class SaleRequestModel
{
    public string? ProductId { get; set; }

    public string? InvoiceId { get; set; }

    public decimal? UnitPrice { get; set; }

    public DateTime? CreateDate { get; set; }
}

#endregion