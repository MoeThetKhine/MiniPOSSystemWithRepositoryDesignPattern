namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.ProductCategory;

#region IProductCategoryRepository

public interface IProductCategoryRepository
{
    Task<Result<IEnumerable<ProductCategoryModel>>> GetProductCategoryAsync
        (int pageNo, int pageSize, CancellationToken cs);

    Task<Result<ProductCategoryRequestModel>> CreateProductCategoryAsync
        (ProductCategoryRequestModel productCategoryRequest, CancellationToken cs);

    Task<Result<ProductCategoryModel>> DeleteProductCategoryAsync
        (string name, CancellationToken cs);
}

#endregion