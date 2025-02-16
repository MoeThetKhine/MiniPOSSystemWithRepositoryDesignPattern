﻿namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Sale;

public class SaleRepository : ISaleRepository
{
    private readonly AppDbContext _appDbContext;

    public SaleRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    #region CreateSaleAsync

    public async Task<Result<SaleRequestModel>> CreateSaleAsync(SaleRequestModel saleRequest, CancellationToken cancellationToken)
    {
        Result<SaleRequestModel> result;

        try
        {
            string saleId = Ulid.NewUlid().ToString();

            var product = _appDbContext.TblProducts.FirstOrDefaultAsync(x => x.ProductId == saleRequest.ProductId);
            var invoice = _appDbContext.TblInvoices.FirstOrDefaultAsync(x => x.InvoiceId == saleRequest.InvoiceId);

             if (product is null)
             {
                 result = Result<SaleRequestModel>.NotFound("Product does not exist.");
             }

             if (invoice is null)
             {
                 result = Result<SaleRequestModel>.NotFound("Invoice does not exist.");
             }

            var item = new TblSale()
            {
                SaleId = saleId,
                ProductId = saleRequest.ProductId,
                InvoiceId = saleRequest.InvoiceId,
                UnitPrice = saleRequest.UnitPrice,
                CreateDate = DateTime.Now,
            };

            await _appDbContext.TblSales.AddAsync(item, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            result = Result<SaleRequestModel>.Success();
        }
        catch (Exception ex)
        {
            result = Result<SaleRequestModel>.Fail(ex);
        }
        return result;
    }

    #endregion

    #region GetSaleListAsync

    public async Task<Result<IEnumerable<SaleModel>>> GetSaleListAsync(int pageSize, int pageNo, CancellationToken cs)
    {
        Result<IEnumerable<SaleModel>> result;

        try
        {
            var sale = _appDbContext.TblSales.AsNoTracking();

            var lst = await sale.Select(x => new SaleModel()
            {
                SaleId = x.SaleId,
                ProductId = x.ProductId,
                InvoiceId = x.InvoiceId,
                UnitPrice = x.UnitPrice,
                CreateDate = x.CreateDate,
            }).ToListAsync();

            result = Result<IEnumerable<SaleModel>>.Success(lst);
        }
        catch (Exception ex)
        {
            result =  Result<IEnumerable<SaleModel>>.Fail(ex);
        }
        return result;
    }

    #endregion
}
