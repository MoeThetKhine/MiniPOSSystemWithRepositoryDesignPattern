﻿namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Admin;

public interface IAdminRepository
{
    Task<Result<IEnumerable<AdminModel>>> GetAdminAsync(int pageNo, int pageSize, CancellationToken cs);

    Task<Result<AdminRequestModel>> CreateAdminAsync(AdminRequestModel adminRequest, CancellationToken cs);
}
