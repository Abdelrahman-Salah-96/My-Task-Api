using JuniorTaskApi.DTO;
using JuniorTaskApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JuniorTaskApi.Services
{
    public class MyOrderRepository : IMyOrderRepository
    {


        TaskDatabase context;
        public MyOrderRepository(TaskDatabase _context)
        {
            context = _context;
        }



        public int AddNewOrder(DTOforMyOrder order)
        {
            MyOrder neworder = new MyOrder();
            neworder.Grandtotal = order.grandtotal;
            context.MyOrders.Add(neworder);
            context.SaveChanges();
            order.productsinorder.ForEach(item =>
            {

                orderproduct orderproduct = new orderproduct();
                orderproduct.orderId = neworder.Id;
                orderproduct.productId = item.productid;
                orderproduct.Quantity = item.quantity;
                orderproduct.Totalprice = item.totalprice;
                context.Orderproducts.Add(orderproduct);
            });
            int row = context.SaveChanges();
            return row;
        }
    }
}
