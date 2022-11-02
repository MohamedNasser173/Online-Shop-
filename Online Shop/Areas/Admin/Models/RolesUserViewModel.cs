using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Areas.Admin.Models
{
    public class RolesUserViewModel
    {
        [Required]
        [Display(Name ="User")]
        public String  UserId { get; set; }

        [Required]
        [Display(Name = "Role")]
        public String RoleId { get; set; }  
    }
}
