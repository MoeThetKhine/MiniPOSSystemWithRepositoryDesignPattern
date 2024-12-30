namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.ProductCategory;

public interface IProductCategoryRepository
{
    Task<Result<IEnumerable<ProductCategoryModel>>> GetProductCategoryAsync
        (int pageNo, int pageSize, CancellationToken cs);

    Task<Result<ProductCategoryRequestModel>> CreateProductCategoryAsync
        (ProductCategoryRequestModel productCategoryRequest, CancellationToken cs);
}
