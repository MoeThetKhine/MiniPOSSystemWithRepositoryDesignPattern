namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Product;

#region IProductRepository

public interface IProductRepository
{
    Task<Result<IEnumerable<ProductModel>>> GetProductAsync (CancellationToken cs);
    Task<Result<IEnumerable<ProductModel>>> GetProductByCategoryIdAsync
        (string CategoryId , CancellationToken cs);
    Task<Result<ProductRequestModel>> CreateProductAsync
        (ProductRequestModel productRequestModel, CancellationToken cancellationToken);
    Task<Result<ProductResponseModel>> UpdateProductAsync
        (string productId, ProductResponseModel productResponse, CancellationToken cs);
}

#endregion
