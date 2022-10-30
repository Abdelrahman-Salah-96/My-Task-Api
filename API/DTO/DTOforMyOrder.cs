namespace JuniorTaskApi.DTO
{
    public class DTOforMyOrder
    {
        
        public int grandtotal { get; set; }
       
        public List<productinorder> productsinorder { get; set; }
    }

    public class productinorder
    {
        public int orderid { get; set; }

        public int productid { get; set; }

        public int quantity { get; set; }

        public int totalprice { get; set; }
    }
}
