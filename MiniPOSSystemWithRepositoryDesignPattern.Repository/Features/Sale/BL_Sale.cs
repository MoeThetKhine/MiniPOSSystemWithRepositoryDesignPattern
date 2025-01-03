﻿namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Sale;

public class BL_Sale
{
    private readonly ISaleRepository _saleRepository;

    public BL_Sale(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    #region GetSaleListAsync

    public async Task<Result<IEnumerable<SaleModel>>> GetSaleListAsync(int pageSize, int pageNo, CancellationToken cs)
    {
        Result<IEnumerable<SaleModel>> result;

        try
        {
            result = await _saleRepository.GetSaleListAsync(pageSize, pageNo, cs);
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<SaleModel>>.Fail(ex);
        }
        return result;
    }

    #endregion

    #region CreateSaleAsync

    public async Task<Result<SaleRequestModel>> CreateSaleAsync(SaleRequestModel saleRequest, CancellationToken cancellationToken)
    {
        Result<SaleRequestModel> result;

        try
        {
            result = await _saleRepository.CreateSaleAsync(saleRequest, cancellationToken);
        }
        catch (Exception ex)
        {
            result = Result<SaleRequestModel>.Fail(ex);
        }
        return result;
    }

    #endregion
}
