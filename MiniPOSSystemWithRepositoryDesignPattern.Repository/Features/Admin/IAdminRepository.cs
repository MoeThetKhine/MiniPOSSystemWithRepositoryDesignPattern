﻿using MiniPOSSystemWithRepositoryDesignPattern.Models.Admin;
using MiniPOSSystemWithRepositoryDesignPattern.Utils;

namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Admin;

public interface IAdminRepository
{
    Task<Result<List<AdminModel>>> GetAdminList(int pageNo, int pageSize, CancellationToken cs);
}
