namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Product;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _db;

    public ProductRepository(AppDbContext db)
    {
        _db = db;
    }


    #region  CreateProductAsync

    public async Task<Result<ProductRequestModel>> CreateProductAsync(ProductRequestModel productRequestModel, CancellationToken cancellationToken)
    {
        Result<ProductRequestModel> result;

        try
        {
            var existingProduct = await _db.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProductName == productRequestModel.ProductName && !x.IsDelete,cancellationToken);

            if(existingProduct is not null)
            {
                result = Result<ProductRequestModel>.Conflict("Product is already created");
            }

            string productId = Ulid.NewUlid().ToString();

            var item = new Product
            {
                ProductId = productId,
                ProductCategoryId = productRequestModel.ProductCategoryId,
                ProductName = productRequestModel.ProductName,
                Description = productRequestModel.Description,
                Qty = productRequestModel.Qty,
                Price = productRequestModel.Price,
                CreatedDate = DateTime.UtcNow,
            };

            await _db.Products.AddAsync(item, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            result = Result<ProductRequestModel>.Success();


        }
        catch (Exception ex)
        {
            result = Result<ProductRequestModel>.Fail(ex.Message);
        }

    }

    #endregion

    #region GetProductAsync

    public async Task<Result<IEnumerable<ProductModel>>> GetProductAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        Result<IEnumerable<ProductModel>> result;

        try
        {
            var query = _db.Products
                .Where(x => x.IsDelete == false)
                .OrderBy(x => x.CreatedDate) 
                .Paginate(pageNo, pageSize) 
                .AsNoTracking();

            if(query is null)
            {
                result = Result<IEnumerable<ProductModel>>.NotFound();
            }

            var productList = await query.Select(x => new ProductModel
            {
                ProductCategoryId = x.ProductCategoryId,
                ProductName = x.ProductName,
                Description = x.Description,
                Qty = x.Qty,
                Price = x.Price,
                CreatedDate = x.CreatedDate,
            }).ToListAsync(cs);

            result = Result<IEnumerable<ProductModel>>.Success(productList);
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<ProductModel>>.Fail(ex.Message);
        }

        return result;
    }

    #endregion

}
