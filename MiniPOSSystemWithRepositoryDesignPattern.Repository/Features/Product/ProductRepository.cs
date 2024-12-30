
namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Product;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _db;

    public ProductRepository(AppDbContext db)
    {
        _db = db;
    }

    #region CreateProductAsync

    public async Task<Result<ProductRequestModel>> CreateProductAsync(ProductRequestModel productRequestModel, CancellationToken cancellationToken)
    {
        Result<ProductRequestModel> result;

        try
        {
            var existingProduct = await _db.TblProducts.AsNoTracking().FirstOrDefaultAsync(x => x.ProductName == productRequestModel.ProductName && !x.IsDelete,cancellationToken);

            if(existingProduct is not null)
            {
                result = Result<ProductRequestModel>.Conflict("Produt is already created.");
            }
            string productId = Ulid.NewUlid().ToString();

            var item = new TblProduct
            {
                ProductId = productId,
                ProductName = productRequestModel.ProductName,
                Description = productRequestModel.Description,
                Price = productRequestModel.Price,
                ProductCategoryId = productRequestModel.ProductCategoryId,
                CreatedDate = DateTime.Now,
                IsDelete = false
            };

            await _db.TblProducts.AddAsync(item, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            result = Result<ProductRequestModel>.Success();
        }
        catch (Exception ex)
        {
            result = Result<ProductRequestModel>.Fail(ex.Message);
        }
        return result;
    }

    #endregion

    public async Task<Result<IEnumerable<ProductModel>>> GetProductAsync(CancellationToken cs)
    {
        Result<IEnumerable<ProductModel>> result;

        try
        {
            var product = _db.TblProducts.AsNoTracking().Where(x => !x.IsDelete);

            var lst = await product.Select(x => new ProductModel()
            {
                ProductId =x.ProductId,
                ProductName = x.ProductName,
                Description = x.Description,
                Price = x.Price,
                ProductCategoryId = x.ProductCategoryId,
                CreatedDate = x.CreatedDate,
            }).ToListAsync(cs);

            result = Result<IEnumerable<ProductModel>>.Success(lst);
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<ProductModel>>.Fail(ex);
        }
        return result;
       
    }

}
