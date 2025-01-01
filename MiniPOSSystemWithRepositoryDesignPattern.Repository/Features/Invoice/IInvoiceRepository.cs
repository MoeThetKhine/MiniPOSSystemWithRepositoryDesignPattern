namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Invoice;

#region IInvoiceRepository

public interface IInvoiceRepository
{
    Task<Result<IEnumerable<InvoiceModel>>> GetInvoiceListAsync(int pageNo, int pageSize, CancellationToken cs);
}

#endregion
