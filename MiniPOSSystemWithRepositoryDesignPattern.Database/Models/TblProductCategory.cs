namespace MiniPOSSystemWithRepositoryDesignPattern.Database.Models;

#region TblProductCategory

public partial class TblProductCategory
{
    public string ProductCategoryId { get; set; } = null!;

    public string? ProductCategoryName { get; set; }

    public bool? IsDelete { get; set; }
}

#endregion