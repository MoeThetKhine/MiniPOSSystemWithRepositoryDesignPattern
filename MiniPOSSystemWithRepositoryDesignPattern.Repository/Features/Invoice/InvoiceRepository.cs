namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Invoice;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly AppDbContext _db;

    public InvoiceRepository(AppDbContext appDbContext)
    {
        _db = appDbContext;
    }

    #region GetInvoiceListAsync

    public async Task<Result<IEnumerable<InvoiceModel>>> GetInvoiceListAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        Result<IEnumerable<InvoiceModel>> result;

        try
        {
            var invoice = _db.TblInvoices.AsNoTracking();

            var lst = await invoice.Select(x => new InvoiceModel()
            {
                InvoiceId = x.InvoiceId,
                InvoiceDate = x.InvoiceDate,
                TotalAmount = x.TotalAmount,
                IsDelete = x.IsDelete
            }).ToListAsync();

            result = Result<IEnumerable<InvoiceModel>>.Success(lst);
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<InvoiceModel>>.Fail(ex);
        }
        return result;
    }

    #endregion

}
