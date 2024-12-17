using Azure;
using MiniPOSSystemWithRepositoryDesignPattern.Database.Models;
using MiniPOSSystemWithRepositoryDesignPattern.Models.Product;
using MiniPOSSystemWithRepositoryDesignPattern.Utils;

namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Product;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _db;

    public ProductRepository(AppDbContext db)
    {
        _db = db;
    }

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

}
