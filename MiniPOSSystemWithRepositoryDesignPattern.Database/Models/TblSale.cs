namespace MiniPOSSystemWithRepositoryDesignPattern.Database.Models;

#region TblSale

public partial class TblSale
{
    public string SaleId { get; set; } = null!;

    public string? ProductId { get; set; }

    public string? InvoiceId { get; set; }

    public decimal? UnitPrice { get; set; }

    public DateTime? CreateDate { get; set; }
}

#endregion