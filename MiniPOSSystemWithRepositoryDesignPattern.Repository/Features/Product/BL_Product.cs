namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Product;

public class BL_Product
{
    private readonly IProductRepository _productRepository;

    public BL_Product(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

   

}
