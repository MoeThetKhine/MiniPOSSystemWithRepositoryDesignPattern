namespace MiniPOSSystemWithRepositoryDesignPattern.Models.ProductCategory;

public class ProductCategoryModel
{
    public string ProductCategoryId { get; set; } = null!;

    public string ProductCategoryName { get; set; } = null!;

    public bool? IsDelete { get; set; }
}
