namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Product;

public class BL_Product
{
    private readonly IProductRepository _productRepository;

    public BL_Product(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<IEnumerable<ProductModel>>> GetProductAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        Result<IEnumerable<ProductModel>> response;
        try
        {
            response = await _productRepository.GetProductAsync(pageNo,pageSize,cs);

        }
        catch (Exception ex)
        {
            response =  Result<IEnumerable<ProductModel>>.Fail(ex);
        }
    result:
        return response;
    }
}
