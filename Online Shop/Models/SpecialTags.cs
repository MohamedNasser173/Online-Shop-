using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Models
{
    public class SpecialTags
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "special tag")]
        public String  specialTag { get; set; }

    }
}
