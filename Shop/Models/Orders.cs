using System;
using System.ComponentModel.DataAnnotations;
namespace Shop.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public int Product_id { get; set; }
    }
}
