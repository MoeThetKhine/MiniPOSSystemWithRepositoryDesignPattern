namespace MiniPOSSystemWithRepositoryDesignPattern.Database.Models;

#region TblProduct

public partial class TblProduct
{
    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? ProductCategoryId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool IsDelete { get; set; }
}

#endregion
