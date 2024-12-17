namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Admin;

public interface IAdminRepository
{
    Task<Result<List<AdminModel>>> GetAdminAsync(int pageNo, int pageSize, CancellationToken cs);
}
