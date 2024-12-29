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

    #region CreateAdminAsync

    public async Task<Result<AdminRequestModel>> CreateAdminAsync(AdminRequestModel adminRequest, CancellationToken cs)
    {
        Result<AdminRequestModel> result;
        try
        {
            var existingAdmin = _db.TblAdmins.AsNoTracking().FirstOrDefaultAsync(x => x.Email == adminRequest.Email && !x.IsDelete && x.PhNo == adminRequest.PhNo);

            if(existingAdmin is not null)
            {
                result = Result<AdminRequestModel>.Conflict("Admin already exist.");
            }
            string adminId = Ulid.NewUlid().ToString();

            var item = new TblAdmin()
            {
                UserId = adminId,
                UserName = adminRequest.UserName,
                Password = adminRequest.Password,
                Email = adminRequest.Email,
                PhNo = adminRequest.PhNo,
                UserRole = "Admin",
                IsDelete = false,
                IsFirstTime = true,
                IsLocked = false
            };

            await _db.TblAdmins.AddAsync(item, cs);
            await _db.SaveChangesAsync(cs);

            result = Result<AdminRequestModel>.Success();
        }
        catch(Exception ex)
        {
            result = Result<AdminRequestModel>.Fail(ex);
        }
        return result;
    }

    #endregion

}
