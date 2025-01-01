using MiniPOSSystemWithRepositoryDesignPattern.Models.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Sale
{
    public interface ISaleRepository
    {
        Task<Result<IEnumerable<SaleModel>>> GetSaleListAsync(int pageSize , int pageNo , CancellationToken cs);
    }
}
