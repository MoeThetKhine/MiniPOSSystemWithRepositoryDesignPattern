namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Admin;

public class BL_Admin
{
    private readonly IAdminRepository _adminRepository;

    public BL_Admin(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }
    public async Task<Result<IEnumerable<AdminModel>>> GetAdminAsync(int pageNo, int pageSize, CancellationToken cs)
    {
        Result<IEnumerable<AdminModel>> result;

        try
        {
            result = await _adminRepository.GetAdminAsync(pageNo, pageSize, cs);
        }
        catch (Exception ex)
        {
            result = Result<IEnumerable<AdminModel>>.Fail(ex);
        }
        return result;
    }
}
