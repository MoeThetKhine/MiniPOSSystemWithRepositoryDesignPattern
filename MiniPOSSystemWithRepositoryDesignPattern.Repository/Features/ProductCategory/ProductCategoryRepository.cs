using MiniPOSSystemWithRepositoryDesignPattern.Models.ProductCategory;

namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.ProductCategory;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly AppDbContext _db;

    public ProductCategoryRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Result<IEnumerable<ProductCategoryModel>>> GetProductCategoryAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        Result<IEnumerable<ProductCategoryModel>> result;

        try
        {
            var category = _db.TblProductCategories
                .AsNoTracking()
                .Where(x => !x.IsDelete);

            var lst = await category.Select(x => new ProductCategoryModel()
            {
                ProductCategoryId = x.ProductCategoryId,
                ProductCategoryName = x.ProductCategoryName,
                IsDelete = false,
            }).ToListAsync(cs);

            result = Result<IEnumerable<ProductCategoryModel>>.Success(lst);
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<ProductCategoryModel>>.Fail(ex);
        }
        return result;
    }
}
