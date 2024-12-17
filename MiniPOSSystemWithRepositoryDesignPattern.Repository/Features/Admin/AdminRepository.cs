namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Admin;

public class AdminRepository : IAdminRepository
{
    private readonly AppDbContext _db;

    public AdminRepository(AppDbContext db)
    {
        _db = db;
    }

    #region Get Admin Async

    public async Task<Result<List<AdminModel>>> GetAdminAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        Result<List<AdminModel>> result;

        try
        {
            var query = _db.Admins
                .Where(x => x.IsDelete == false)
                .Paginate(pageNo, pageSize);

            var lst = await query.Select(x => new AdminModel()
            {
                UserName = x.UserName,
                Email = x.Email,
                PhNo = x.PhNo,
                UserRole = x.UserRole,
                IsFirstTime = x.IsFirstTime,
                IsLocked = x.IsLocked,
            }).ToListAsync();

            result = Result<List<AdminModel>>.Success();
        }
        catch (Exception ex)
        {
            result = Result<List<AdminModel>>.Fail(ex);
        }
        return result;
    }

    #endregion

}
