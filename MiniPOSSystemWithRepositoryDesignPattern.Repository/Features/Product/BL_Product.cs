namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Product;

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

    #region GetProductAsync

    public async Task<Result<IEnumerable<ProductModel>>> GetProductAsync(CancellationToken cs)
    {
        Result<IEnumerable<ProductModel>> result;

        try
        {
            result = await _productRepository.GetProductAsync(cs);
        }
        catch(Exception ex)
        {
            result = Result<IEnumerable<ProductModel>>.Fail(ex);
        }
        return result;
    }

    #endregion

    public async Task<Result<IEnumerable<ProductModel>>> GetProductByCategoryIdAsync(string categoryId, CancellationToken cs)
    {
        Result<IEnumerable<ProductModel>> result;

        try
        {
            result = await _productRepository.GetProductByCategoryIdAsync(categoryId , cs);
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<ProductModel>>.Fail(ex);
        }
        return result;
    }
}
