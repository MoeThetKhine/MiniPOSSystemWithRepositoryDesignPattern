namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Sale;

#region ISaleRepository

public interface ISaleRepository
{
    Task<Result<IEnumerable<SaleModel>>> GetSaleListAsync(int pageSize , int pageNo , CancellationToken cs);

    Task<Result<SaleRequestModel>> CreateSaleAsync(SaleRequestModel saleRequest, CancellationToken cancellationToken);

}

#endregion