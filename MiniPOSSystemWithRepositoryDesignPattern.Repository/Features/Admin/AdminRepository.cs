using Microsoft.EntityFrameworkCore;
using MiniPOSSystemWithRepositoryDesignPattern.Database.Models;
using MiniPOSSystemWithRepositoryDesignPattern.Models.Admin;
using MiniPOSSystemWithRepositoryDesignPattern.Utils;
using MiniPOSSystemWithRepositoryDesignPattern.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPOSSystemWithRepositoryDesignPattern.Repository.Features.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _db;

        public AdminRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Result<List<AdminModel>>> GetAdminList(int pageNo, int pageSize, CancellationToken cs)
        {
            Result<List<AdminModel>> result;

            try
            {
                //var query = _context.TblBlogs
                //.Where(x => x.IsActive == true)
                //.Paginate(pageNo, pageSize);

                //var lst = await query.Select(x => new BlogModel()
                //{
                //    BlogId = x.BlogId,
                //    BlogTitle = x.BlogTitle,
                //    BlogAuthor = x.BlogAuthor,
                //    BlogContent = x.BlogContent,
                //    IsActive = true

                //}).ToListAsync(cs);

                //result = Result<List<BlogModel>>.Success(lst);

                var query = _db.Admins
                    .Where(x => x.IsDelete == false)
                    .Paginate(pageNo, pageSize);

                var lst = await query.Select(x => new AdminModel()
                {

                }).ToListAsync();

            }
            catch (Exception ex)
            {
                result = Result<List<AdminModel>>.Fail(ex);
            }
            return result;
        }
    }
}
