using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPOSSystemWithRepositoryDesignPattern.Models.Admin
{
    public class AdminResponseModel
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string PhNo { get; set; }
    }
}
