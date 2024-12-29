﻿using MiniPOSSystemWithRepositoryDesignPattern.Models.Admin;

namespace MiniPOSSystemWithRepositoryDesignPattern.RestApi.Controllers.Admin;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly BL_Admin bL_Admin;

    public AdminController(BL_Admin bL_Admin)
    {
        this.bL_Admin = bL_Admin;
    }

    #region GetAdminAsync

    [HttpGet]
    public async Task<IActionResult>GetAdminAsync(int pageSize, int pageNo , CancellationToken cs)
    {
        var item = await bL_Admin.GetAdminAsync(pageSize, pageNo, cs);
        return Ok(item);
    }

    #endregion

    #region CreateAdminAsync

    [HttpPost]
    public async Task<IActionResult> CreateAdminAsync([FromForm]AdminRequestModel adminRequest , CancellationToken cs)
    {
        var item = await bL_Admin.CreateAdminAsync(adminRequest , cs);
        return Ok(item);
    }

    #endregion

    [HttpPatch]
    public async Task<IActionResult> UpdateAdminAsync(string name, AdminResponseModel adminResponse, CancellationToken cs)
    {
        var item = await bL_Admin.UpdateAdminAsync(name, adminResponse, cs);
        return Ok(item);
    }

}
