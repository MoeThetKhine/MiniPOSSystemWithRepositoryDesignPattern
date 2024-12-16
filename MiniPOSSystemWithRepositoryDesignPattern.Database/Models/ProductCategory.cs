namespace MiniPOSSystemWithRepositoryDesignPattern.Database.Models;

public partial class ProductCategory
{
    public string ProductCategoryId { get; set; } = null!;

    public string ProductCategoryName { get; set; } = null!;

    public bool? IsDelete { get; set; }
}
