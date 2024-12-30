namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.ProductCategory;

public class BL_ProductCategory
{
    private readonly IProductCategoryRepository _productCategory;

    public BL_ProductCategory(IProductCategoryRepository productCategory)
    {
        _productCategory = productCategory;
    }

    #region GetProductCategoryAsync

    public async Task<Result<IEnumerable<ProductCategoryModel>>> GetProductCategoryAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        Result<IEnumerable<ProductCategoryModel>> result;

        try
        {
            result = await _productCategory.GetProductCategoryAsync(pageNo, pageSize, cs);
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
            result = await _productCategory.CreateProductCategoryAsync(productCategoryRequest, cs);
        }
        catch (Exception ex)
        {
            result = Result<ProductCategoryRequestModel>.Fail(ex);
        }
        return result;
    }

    #endregion

}
