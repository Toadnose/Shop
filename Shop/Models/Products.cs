using System.ComponentModel.DataAnnotations;
namespace Shop.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public decimal price { get; set; }
        public string name { get; set; }
    }
}
