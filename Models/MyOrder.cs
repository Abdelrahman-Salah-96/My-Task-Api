using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JuniorTaskApi.Models
{
    public class MyOrder 
    {

        public int Id { get; set; }

        [Required]
        [Range(minimum:1, maximum: double.MaxValue, ErrorMessage = "must be greater than 0")]
        public int Grandtotal { get; set; }
       
       
        public virtual List<orderproduct> Orderproducts { get; set; }
    }
}
