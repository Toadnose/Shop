using System.Collections.Generic;
namespace Shop.DTO
{
    public class BuyProduct
    {
        public int Customers_id { get; set; }
        public List<int> product_ids { get; set; }
    }
}
