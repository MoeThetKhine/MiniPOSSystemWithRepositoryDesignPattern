﻿namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Admin;

#region AdminRequestModel

public class AdminRequestModel
{
    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? PhNo { get; set; }
}

#endregion