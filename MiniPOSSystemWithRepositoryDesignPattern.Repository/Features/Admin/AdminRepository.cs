namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Admin;

public class AdminRepository : IAdminRepository
{
    private readonly AppDbContext _db;

    public AdminRepository(AppDbContext db)
    {
        _db = db;
    }

    

}
