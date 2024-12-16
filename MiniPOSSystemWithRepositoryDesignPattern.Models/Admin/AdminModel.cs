namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Admin
{
    public class AdminModel
    {
        public string UserId { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? PhNo { get; set; }

        public string UserRole { get; set; } = null!;

        public bool? IsFirstTime { get; set; }

        public bool? IsLocked { get; set; }

        public bool? IsDelete { get; set; }
    }
}
