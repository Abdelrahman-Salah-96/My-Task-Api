using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JuniorTaskApi.Models
{
    [Index(nameof(Name), IsUnique = true, Name = "UniqueName")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="please enter the name of product")]
        public string Name { get; set; }

        [Required(ErrorMessage ="please enter the price of product")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        public int Price { get; set; }


        private string _name = "/assets/images/smooth-nature-pic-full-hd-126695318.jpg";
        public string ProductImage
        {
            get { return _name; }
            set { }
        } 


        public virtual List<orderproduct> Orderproducts { get; set; }

    }
}

