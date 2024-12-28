namespace MiniPOSSystemWithRepositoryDesignPattern.Database.Models;

public partial class TblProductCategory
{
    public string ProductCategoryId { get; set; } = null!;

    public string? ProductCategoryName { get; set; }

    public bool? IsDelete { get; set; }
}
