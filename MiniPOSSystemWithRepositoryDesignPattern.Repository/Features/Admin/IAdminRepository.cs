namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Admin;

public interface IAdminRepository
{
    Task<Result<IEnumerable<AdminModel>>> GetAdminAsync(int pageNo, int pageSize, CancellationToken cs);

    Task<Result<AdminRequestModel>> CreateAdminAsync(AdminRequestModel adminRequest, CancellationToken cs);
    Task<Result<AdminResponseModel>> UpdateAdminAsync(string name, AdminResponseModel adminResponse,CancellationToken cs);
    Task<Result<AdminModel>> DeleteAdminAsync(string name, CancellationToken cs);
    Task<Result<AdminModel>> ActivateAdminAsync(string name, CancellationToken cs);



}
