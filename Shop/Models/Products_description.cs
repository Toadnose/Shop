using System.ComponentModel.DataAnnotations;
namespace Shop.Models
{
    public class Products_description
    {
        [Key]
        public int Id { get; set; }
        public string product_description {get; set;}
        public string product_name {get; set;}
        public decimal price {get; set;}

    }
}
