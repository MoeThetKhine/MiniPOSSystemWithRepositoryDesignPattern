﻿namespace MiniPOSSystemWithRepositoryDesignPattern.Utils.Enums;

#region EnumStatusCode

public enum EnumStatusCode
{
    None,
    Success = 200,
    BadRequest = 400,
    Conflict = 409,
    NotFound = 404,
    InternalServerError = 500
}

#endregion
