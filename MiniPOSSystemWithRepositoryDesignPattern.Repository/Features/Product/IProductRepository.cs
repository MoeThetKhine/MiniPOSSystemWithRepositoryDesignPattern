namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Product;

public interface IProductRepository
{
    Task<Result<IEnumerable<ProductModel>>> GetProductAsync (CancellationToken cs);
    Task<Result<IEnumerable<ProductModel>>> GetProductByCategoryIdAsync(string CategoryId , CancellationToken cs);
    Task<Result<ProductRequestModel>> CreateProductAsync(ProductRequestModel productRequestModel, CancellationToken cancellationToken);
}
