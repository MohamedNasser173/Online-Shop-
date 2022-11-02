using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Models
{
    public class Products
    {
       
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public String  Image { get; set; }
        [Display(Name ="product Color")]
        public String ProductColor { get; set; }
        [Required]
        [Display(Name = "Availabe")]
        public String IsAvailable { get; set; }

        [Display(Name = "product type")]
        [Required]
        public int ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductTypes productTypes { get; set; }

        [Display(Name = "special tag")]
        [Required]
        public int SpecialTagId { get; set; }
        [ForeignKey("SpecialTagId")]
        public SpecialTags specialTags { get; set; }



    }
}
