namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Admin;

public class AdminRepository : IAdminRepository
{
    private readonly AppDbContext _db;

    public AdminRepository(AppDbContext db)
    {
        _db = db;
    }

    #region GetAdminAsync

    public async Task<Result<IEnumerable<AdminModel>>> GetAdminAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        Result<IEnumerable<AdminModel>> result;

        try
        {
            var admin =  _db.TblAdmins
                .AsNoTracking()
                .Where(x => !x.IsDelete && !x.IsLocked && x.UserRole == "Admin");

            var lst = await admin.Select(x => new AdminModel
            {
                UserName = x.UserName,
                Email = x.Email,
                PhNo =x.PhNo,
                UserRole = x.UserRole,  
                IsFirstTime = x.IsFirstTime
            }).ToListAsync(cs);

            result = Result<IEnumerable<AdminModel>>.Success(lst);
        }
        catch(Exception ex)
        {
            result = Result<IEnumerable<AdminModel>>.Fail(ex);
        }
        return result;
    }

    #endregion
}
