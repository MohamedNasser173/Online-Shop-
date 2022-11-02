using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Models
{
    public class ProductTypes
    {
        public int Id { get; set; } 

        [Required]
        [Display(Name ="Product type")]
        public String ProductType { get; set; } 

    }
}
