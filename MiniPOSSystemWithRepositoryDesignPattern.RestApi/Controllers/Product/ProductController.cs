namespace MiniPOSSystemWithRepositoryDesignPattern.RestApi.Controllers.Product;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly BL_Product _bL_Product;

    public ProductController(BL_Product bL_Product)
    {
        _bL_Product = bL_Product;
    }

   
}
