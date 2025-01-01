namespace MiniPOSSystemWithRepositoryDesignPattern.RestApi.Controllers.Sale;

[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly BL_Sale _bL_Sale;

    public SaleController(BL_Sale bL_Sale)
    {
        _bL_Sale = bL_Sale;
    }

    [HttpGet]
    public async Task<IActionResult> GetSaleListAsync(int pageSize, int pageNo, CancellationToken cs)
    {
        var result = await _bL_Sale.GetSaleListAsync(pageSize, pageNo, cs); 
        return Ok(result);
    }
}
