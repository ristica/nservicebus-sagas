using System.ComponentModel.DataAnnotations;

namespace Nsb.Client.Models
{
    public class Order
    {
        [Required]
        public string Article { get; set; }  

        public string Description { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int Price { get; set; }
    }
}