using System.ComponentModel.DataAnnotations;
using System;

namespace Shop.Models
{
    public class Customers_description
    {
        [Key]
        public int Id { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string first_name { get; set; }
        public string phone_number { get; set; }
    }
}