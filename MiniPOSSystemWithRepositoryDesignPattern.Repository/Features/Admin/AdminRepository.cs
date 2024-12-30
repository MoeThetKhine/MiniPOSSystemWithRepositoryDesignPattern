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

    #region UpdateAdminAsync

    public async Task<Result<AdminResponseModel>> UpdateAdminAsync(string name, AdminResponseModel adminResponse, CancellationToken cs)
    {
        Result<AdminResponseModel> result;

        try
        {
            var admin = _db.TblAdmins.FirstOrDefault(x => x.UserName == name && !x.IsDelete);

            if(admin is null)
            {
                result = Result<AdminResponseModel>.NotFound("Admin does not exist.");
            }

            #region Validation

            if (!string.IsNullOrEmpty(adminResponse.UserName))
            {
                admin.UserName = adminResponse.UserName;
            }
            if(!string.IsNullOrEmpty(adminResponse.Password))
            {
                admin.Password = adminResponse.Password;
            }
            if (!string.IsNullOrEmpty(adminResponse.PhNo))
            {
                admin.PhNo = adminResponse.PhNo;
            }

            #endregion

            _db.TblAdmins.Attach(admin);
            _db.Entry(admin).State = EntityState.Modified;
            await _db.SaveChangesAsync(cs);

            result = Result<AdminResponseModel>.Success( adminResponse);

        }
        catch(Exception ex)
        {
            result = Result<AdminResponseModel>.Fail(ex);
        }
        return result;
    }

    #endregion

    public async Task<Result<AdminModel>> DeleteAdminAsync(string name , CancellationToken cs)
    {
        Result<AdminModel> result;

        try
        {
            var admin = await _db.TblAdmins
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserName == name);

            if(admin is null)
            {
                return Result<AdminModel>.NotFound("Admin does not exist.");
            }

            admin.IsDelete = true;

            _db.TblAdmins.Attach(admin);
            _db.Entry (admin).State = EntityState.Modified;
            await _db.SaveChangesAsync(cs);

            result = Result<AdminModel>.Success();
        }
        catch(Exception ex)
        {
            result = Result<AdminModel>.Fail(ex);
        }
        return result;
    }

}
