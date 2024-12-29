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

    #region CreateProductAsync

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(ProductRequestModel productRequestModel, CancellationToken cancellationToken)
    {
       var item = await _bL_Product.CreateProductAsync(productRequestModel, cancellationToken);
        return Ok(item);
    }

    #endregion

}
