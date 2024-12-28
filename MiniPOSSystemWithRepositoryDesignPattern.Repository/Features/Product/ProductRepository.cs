namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Product;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _db;

    public ProductRepository(AppDbContext db)
    {
        _db = db;
    }


    
}
