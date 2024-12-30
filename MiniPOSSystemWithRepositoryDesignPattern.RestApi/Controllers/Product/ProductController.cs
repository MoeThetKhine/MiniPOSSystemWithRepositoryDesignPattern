﻿namespace MiniPOSSystemWithRepositoryDesignPattern.RestApi.Controllers.Product;

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

    [HttpGet]
    public async Task<IActionResult> GetProductAsync(CancellationToken cs)
    {
        var item = await _bL_Product.GetProductAsync(cs);
        return Ok(item);
    }

    [HttpGet]
    public async Task<IActionResult> GetProductByCategoryIdAsync(string categoryId , CancellationToken cs)
    {
        var item = await _bL_Product.GetProductByCategoryIdAsync(categoryId, cs);
        return Ok(item);
    }

}
