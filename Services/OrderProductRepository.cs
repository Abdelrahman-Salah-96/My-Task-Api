using JuniorTaskApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JuniorTaskApi.Services
{
    public class OrderProductRepository : IOrderProductRepository
    {


        TaskDatabase context;
        public OrderProductRepository(TaskDatabase _context)
        {
            context = _context;
        }



        public List<orderproduct> getall()
        {
            List<orderproduct> orderproducts = context.Orderproducts.Include(s => s.product).ToList();
            return orderproducts;
        }



        public List<orderproduct> Getbyid(int id)
        {
            List<orderproduct> orderproducts = context.Orderproducts.Include(s => s.product)
                                                 .Where(s => s.orderId == id).ToList();
            return orderproducts;
        }



        public List<orderproduct> SearchForOrderByName(string name)
        {
            List<orderproduct> orderproducts = context.Orderproducts.Include(s => s.product)
                                               .Where(s => s.product.Name == name).ToList();

            return orderproducts;
        }



        public List<orderproduct> SearchForOrderByPrice(int PriceFrom, int PriceTo)
        {
            List<orderproduct> orderproducts = context.Orderproducts.Include(s => s.product)
                                              .Where(s => s.Totalprice >= PriceFrom && s.Totalprice <= PriceTo)
                                              .ToList();

            return orderproducts;
        }



        public List<orderproduct> SearchForOrderByPriceAndName(int PriceFrom, int PriceTo, string name)
        {
            List<orderproduct> orderproducts = context.Orderproducts.Include(s => s.product)
                   .Where(s => (s.Totalprice >= PriceFrom && s.Totalprice <= PriceTo && s.product.Name == name))
                   .ToList();
            return orderproducts;
        }

    }
}
