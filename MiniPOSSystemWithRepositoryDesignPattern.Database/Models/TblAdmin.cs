namespace MiniPOSSystemWithRepositoryDesignPattern.Database.Models;

#region TblAdmin

public partial class TblAdmin
{
    public string UserId { get; set; } = null!;

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? PhNo { get; set; }

    public string? UserRole { get; set; }

    public bool? IsDelete { get; set; }

    public bool? IsFirstTime { get; set; }

    public bool? IsLocked { get; set; }
}

#endregion