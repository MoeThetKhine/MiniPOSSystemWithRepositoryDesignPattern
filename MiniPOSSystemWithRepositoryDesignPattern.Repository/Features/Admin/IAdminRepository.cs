namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Admin;

public interface IAdminRepository
{
    Task<Result<List<AdminModel>>> LoginAdmin(int pageNo, int pageSize, CancellationToken cs);
}
