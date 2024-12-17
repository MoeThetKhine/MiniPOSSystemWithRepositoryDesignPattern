namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Product;

#region ProductRequestModel

public class ProductRequestModel
{
    public string ProductId { get; set; } = null!;

    public string ProductCategoryId { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public int Qty { get; set; }

    public decimal Price { get; set; }

    public DateTime? CreatedDate { get; set; }
}

#endregion