﻿using MiniPOSSystemWithRepositoryDesignPattern.Models.Admin;
using MiniPOSSystemWithRepositoryDesignPattern.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Admin
{
    public interface IAdminRepository
    {
        Task<Result<List<AdminModel>>> GetAdminList(int pageNo, int pageSize, CancellationToken cs);
    }
}