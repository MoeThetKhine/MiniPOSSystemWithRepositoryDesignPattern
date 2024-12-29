﻿namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Product;

public class BL_Product
{
    private readonly IProductRepository _productRepository;

    public BL_Product(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    #region CreateProductAsync

    public async Task<Result<ProductRequestModel>> CreateProductAsync(ProductRequestModel productRequestModel, CancellationToken cancellationToken)
    {
        Result<ProductRequestModel> result;
        try
        {
            #region Validation

            if (productRequestModel.ProductName is null)
            {
                result = Result<ProductRequestModel>.Fail("Product Name Is Required.");
            }
            if (productRequestModel.Description is null)
            {
                result = Result<ProductRequestModel>.Fail("Description Is Required.");
            }
            if (productRequestModel.Price is null)
            {
                result = Result<ProductRequestModel>.Fail("Price Is Required.");
            }
            if (productRequestModel.ProductCategoryId is null)
            {
                result = Result<ProductRequestModel>.Fail("ProductCategoryId Is Required.");
            }

            #endregion

            result = await _productRepository.CreateProductAsync(productRequestModel, cancellationToken);
        }
        catch (Exception ex)
        {
            result = Result<ProductRequestModel>.Fail(ex);
        }
        return result;
    }

    #endregion

}
