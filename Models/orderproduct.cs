using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JuniorTaskApi.Models
{
    public class orderproduct
    { 
      
        public int id { get; set; }

        public int orderId { get; set; }

        public MyOrder order { get; set; }
        
        public int productId { get; set; }
        
        public Product product { get; set; }

        [Required(ErrorMessage ="please enter the quantity of product")]
        [Range(minimum:1, maximum:10, ErrorMessage = " Quantity must be between 1 and 10")]
        public int Quantity { get; set; }


        [Required(ErrorMessage ="please enter the total price")]
        [Range(minimum:1, maximum:int.MaxValue, ErrorMessage = "Total price must be greater than zero")]
        public int Totalprice { get; set; }
        


    }
}
