namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Product;

public interface IProductRepository
{
    Task<Result<ProductRequestModel>> CreateProductAsync(ProductRequestModel productRequestModel, CancellationToken cancellationToken);
}
