namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Product;

#region ProductRequestModel

public class ProductRequestModel
{
    public string ProductName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? ProductCategoryId { get; set; }

    public DateTime? CreatedDate { get; set; }

}

#endregion