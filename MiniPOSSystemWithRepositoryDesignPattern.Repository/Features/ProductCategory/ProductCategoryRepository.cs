namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.ProductCategory;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly AppDbContext _db;

    public ProductCategoryRepository(AppDbContext db)
    {
        _db = db;
    }
   
    #region GetProductCategoryAsync

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

    #endregion

    #region CreateProductCategoryAsync

    public async Task<Result<ProductCategoryRequestModel>> CreateProductCategoryAsync(ProductCategoryRequestModel productCategoryRequest, CancellationToken cs)
    {
        Result<ProductCategoryRequestModel> result;

        try
        {
            var existingCategory = _db.TblProductCategories.AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProductCategoryName  == productCategoryRequest.ProductCategoryName && !x.IsDelete);

            if(existingCategory is not null)
            {
                result = Result<ProductCategoryRequestModel>.Conflict("Product Category is already exist.");
            }

            #region Create New ProductCategory

            string categoryId = Ulid.NewUlid().ToString();

            var item = new TblProductCategory()
            {
                ProductCategoryId = categoryId,
                ProductCategoryName = productCategoryRequest.ProductCategoryName,
                IsDelete = false,
            };

            #endregion

            await _db.TblProductCategories.AddAsync(item, cs);
            await _db.SaveChangesAsync(cs);

            result = Result<ProductCategoryRequestModel>.Success();
        }
        catch(Exception ex)
        {
            result = Result<ProductCategoryRequestModel>.Fail(ex);
        }
        return result;
    }

    #endregion

    public async Task<Result<ProductCategoryModel>> DeleteProductCategoryAsync(string name, CancellationToken cs)
    {
        Result<ProductCategoryModel> result;

        try
        {
            var category = await _db.TblProductCategories
                .FirstOrDefaultAsync(x => x.ProductCategoryName == name && !x.IsDelete);

            if(category is null)
            {
                result = Result<ProductCategoryModel>.Conflict("Product Category does not exist.");
            }
            category.IsDelete = true;

            _db.TblProductCategories.Attach(category);
            _db.Entry(category).State = EntityState.Modified;
            await _db.SaveChangesAsync(cs);

            result = Result<ProductCategoryModel>.Success();
        }
        catch(Exception ex)
        {
            result = Result<ProductCategoryModel>.Fail(ex);
        }
        return result;
    }
}
