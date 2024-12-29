﻿namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Admin;

public class BL_Admin
{
    private readonly IAdminRepository _adminRepository;

    public BL_Admin(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    #region GetAdminAsync

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

    #endregion

    public async Task<Result<AdminRequestModel>> CreateAdminAsync(AdminRequestModel adminRequest, CancellationToken cs)
    {
        Result<AdminRequestModel> result;

        try
        {
            result = await _adminRepository.CreateAdminAsync(adminRequest, cs);
        }
        catch(Exception ex)
        {
            result = Result<AdminRequestModel>.Fail(ex);
        }
        return result;
    }
}
