using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }
        public int Id { get; set; }
        [Display(Name = "Order No")]
        public String OrderNo { get; set; }
        [Required]
        public String Name { get; set; }
        [Display(Name = "Phone No")]
        [Required]
        public String PhoneNo { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public String Address { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }


    }
}
