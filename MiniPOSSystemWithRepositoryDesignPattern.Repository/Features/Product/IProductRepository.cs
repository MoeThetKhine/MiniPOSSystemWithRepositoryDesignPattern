using MiniPOSSystemWithRepositoryDesignPattern.Models.Product;

namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Product;

public interface IProductRepository
{
    Task<Result<IEnumerable<ProductModel>>> GetProductAsync(int pageNo, int pageSize, CancellationToken cs);

}
