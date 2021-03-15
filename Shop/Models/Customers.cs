using System.ComponentModel.DataAnnotations;
namespace Shop.Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
    }
}
