namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Invoice
{
    public interface IInvoiceRepository
    {
        Task<Result<IEnumerable<InvoiceModel>>> GetInvoiceListAsync(int pageNo, int pageSize, CancellationToken cs);
    }
}
