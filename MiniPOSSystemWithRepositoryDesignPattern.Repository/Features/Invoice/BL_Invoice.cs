﻿namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Invoice;

public class BL_Invoice
{
    private readonly IInvoiceRepository _invoiceRepository;

    public BL_Invoice(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public async Task<Result<IEnumerable<InvoiceModel>>> GetInvoiceListAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        Result<IEnumerable<InvoiceModel>> result;

        try
        {
            result = await _invoiceRepository.GetInvoiceListAsync(pageNo, pageSize, cs);
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<InvoiceModel>>.Fail(ex);
        }
        return result;
    }
}
