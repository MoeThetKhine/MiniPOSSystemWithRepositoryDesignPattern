
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

    #region GetProductAsync

    [HttpGet]
    public async Task<IActionResult> GetProductAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        var lst = await _bL_Product.GetProductAsync(pageNo,pageSize,cs);
        return Ok(lst);
    }

    #endregion
}
