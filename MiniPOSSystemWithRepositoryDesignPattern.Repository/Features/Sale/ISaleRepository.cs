namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Sale
{
    public interface ISaleRepository
    {
        Task<Result<IEnumerable<SaleModel>>> GetSaleListAsync(int pageSize , int pageNo , CancellationToken cs);
    }
}
