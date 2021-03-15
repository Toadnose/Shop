using System.ComponentModel.DataAnnotations;

namespace Shop.DTO
{
    public class AddCustomer
    {
        [Required]
        public string Customer_first_name { get; set; }
        [Required]
        public string Customer_last_name { get; set; }
        [Required]
        public int Customer_Id { get; set; }
        public string Customer_adress { get; set; }
        public string Customer_phone { get; set; }
    }
}
