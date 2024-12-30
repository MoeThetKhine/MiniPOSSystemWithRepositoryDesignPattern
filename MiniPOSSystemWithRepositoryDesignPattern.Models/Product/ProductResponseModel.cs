namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Product;

#region ProductResponseModel 

public class ProductResponseModel
{
    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? ProductCategoryId { get; set; }
}

#endregion