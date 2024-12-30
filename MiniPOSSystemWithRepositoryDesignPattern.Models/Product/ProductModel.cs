namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Product;

#region ProductModel

public class ProductModel
{
    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? ProductCategoryId { get; set; }

    public DateTime? CreatedDate { get; set; }

}

#endregion
