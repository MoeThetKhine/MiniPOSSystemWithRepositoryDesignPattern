using MiniPOSSystemWithRepositoryDesignPattern.Models.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Sale
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _appDbContext;

        public SaleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

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
    }
}
