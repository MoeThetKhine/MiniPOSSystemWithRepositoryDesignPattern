namespace MiniPOSSystemWithRepositoryDesignPattern.Database.Models;

#region ProductCategory

public partial class ProductCategory
{
    public string ProductCategoryId { get; set; } = null!;

    public string ProductCategoryName { get; set; } = null!;

    public bool? IsDelete { get; set; }
}

#endregion