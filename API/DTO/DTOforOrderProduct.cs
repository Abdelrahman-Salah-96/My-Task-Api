using JuniorTaskApi.Models;

namespace JuniorTaskApi.DTO
{
    public class DTOforOrderProduct
    {
        
        public int OrderId { get; set; }

        public string productname { get; set; }

        public int productprice { get; set; }
       
        public string productimage { get; set; }

        public int quantity { get; set; }   

        public int totalprice { get; set; }
    }
}
