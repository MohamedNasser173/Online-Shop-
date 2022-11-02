using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Areas.Admin.Models
{
    public class UserRoleMapping
    {
        public String UserId { get; set; }
        public String RoleId { get; set; }
        public String UserName { get; set; }
        public String RoleName { get; set; }
    }
}
