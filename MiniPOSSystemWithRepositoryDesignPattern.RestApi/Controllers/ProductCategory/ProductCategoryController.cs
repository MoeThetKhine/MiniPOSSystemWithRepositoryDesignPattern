namespace MiniPOSSystemWithRepositoryDesignPattern.RestApi.Controllers.ProductCategory;

[Route("api/[controller]")]
[ApiController]
public class ProductCategoryController : ControllerBase
{
    private readonly BL_ProductCategory _bL_ProductCategory;

    public ProductCategoryController(BL_ProductCategory bL_ProductCategory)
    {
        _bL_ProductCategory = bL_ProductCategory;
    }

    #region GetProductCategoryAsync

    [HttpGet]
    public async Task<IActionResult> GetProductCategoryAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        var item = await _bL_ProductCategory.GetProductCategoryAsync(pageNo, pageSize, cs);
        return Ok(item);
    }

    #endregion

    #region CreateProductCategoryAsync

    [HttpPost]
    public async Task<IActionResult> CreateProductCategoryAsync(ProductCategoryRequestModel productCategoryRequest, CancellationToken cs)
    {
        var item = await _bL_ProductCategory.CreateProductCategoryAsync(productCategoryRequest, cs);
        return Ok(item);
    }

    #endregion

    #region DeleteProductCategoryAsync

    [HttpPut]
    public async Task<IActionResult> DeleteProductCategoryAsync(string name, CancellationToken cs)
    {
        var item = await _bL_ProductCategory.DeleteProductCategoryAsync(name, cs);
        return Ok(item);
    }

    #endregion
}
