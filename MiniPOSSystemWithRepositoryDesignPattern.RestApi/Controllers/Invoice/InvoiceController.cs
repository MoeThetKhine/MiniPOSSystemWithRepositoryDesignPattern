using MiniPOSSystemWithRepositoryDesignPattern.Models.Invoice;

namespace MiniPOSSystemWithRepositoryDesignPattern.RestApi.Controllers.Invoice;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly BL_Invoice _bL_Invoice;

    public InvoiceController(BL_Invoice bL_Invoice)
    {
        _bL_Invoice = bL_Invoice;
    }

    #region GetInvoiceListAsync

    [HttpGet]
    public async Task<IActionResult> GetInvoiceListAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        var result = await _bL_Invoice.GetInvoiceListAsync(pageNo, pageSize, cs);
        return Ok(result);
    }

    #endregion

    [HttpPost]
    public async Task<IActionResult> CreateInvoiceAsync(InvoiceRequestModel invoiceRequest, CancellationToken cs)
    {
        var result = await _bL_Invoice.CreateInvoiceAsync(invoiceRequest, cs);
        return Ok(result);
    }

}
