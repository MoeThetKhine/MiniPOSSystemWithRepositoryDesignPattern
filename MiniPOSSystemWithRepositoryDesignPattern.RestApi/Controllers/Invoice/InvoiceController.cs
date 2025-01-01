using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Invoice;

namespace MiniPOSSystemWithRepositoryDesignPattern.RestApi.Controllers.Invoice
{
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

    }
}
