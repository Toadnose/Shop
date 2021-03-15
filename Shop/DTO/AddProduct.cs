using System.ComponentModel.DataAnnotations;

namespace Shop.DTO
{
    public class AddProduct
    {
        [Required]
        public int Product_Id { get; set; }
        [Required]
        public string Product_name { get; set; }
        [Required]
        public decimal Product_price { get; set; }
        [Required]
        public string Product_description { get; set; }
    }
}
