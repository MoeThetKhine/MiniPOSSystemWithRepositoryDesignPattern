using MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.ProductCategory;

namespace MiniPOSSystemWithRepositoryDesignPattern.RestApi.Controllers.ProductCategory
{
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

    }
}
