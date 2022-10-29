using JuniorTaskApi.DTO;
using JuniorTaskApi.Models;
using JuniorTaskApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace JuniorTaskApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {



        private readonly IOrderProductRepository orderProductRepository;
        public OrderProductController(IOrderProductRepository orderProductRepository)
        {
            this.orderProductRepository = orderProductRepository;
        }


        //THIS FUNCTION MAKES THE SEARCH FOR MY ORDERS WORK CLIENT SIDE 

        [HttpGet]
        public IActionResult getall()
        {
            List<orderproduct> myOrders = orderProductRepository.getall();

            List<DTOforOrderProduct> products = new List<DTOforOrderProduct>();

            foreach (var item in myOrders)
            {
                DTOforOrderProduct product = new DTOforOrderProduct();
                product.OrderId = item.orderId;
                product.productname = item.product.Name;
                product.productprice = item.product.Price;
                product.productimage = item.product.ProductImage;
                product.quantity = item.Quantity;
                product.totalprice = item.Totalprice;
                products.Add(product);
            }
            return Ok(products);
        }




        //THOSE THREE FUCTIONS BELOW MAKE SEARCH FOR MY ORDER WORK SERVER SIDE 
        



        [HttpGet]
        [Route("{name}")]
        public IActionResult getbyname(string name)
        {
            List<orderproduct> myOrders = orderProductRepository.SearchForOrderByName(name);

            List<DTOforOrderProduct> products = new List<DTOforOrderProduct>();

            foreach (var item in myOrders)
            {
                DTOforOrderProduct product = new DTOforOrderProduct();
                product.OrderId = item.orderId;
                product.productname = item.product.Name;
                product.productprice = item.product.Price;
                product.productimage = item.product.ProductImage;
                product.quantity = item.Quantity;
                product.totalprice = item.Totalprice;
                products.Add(product);
            }
            return Ok(products);

        }



        [HttpGet]
        [Route("{pricefrom}/{priceto}")]
        public IActionResult getbyprice(int pricefrom, int priceto)
        {
            List<orderproduct> myOrders = orderProductRepository.SearchForOrderByPrice(pricefrom, priceto);

            List<DTOforOrderProduct> products = new List<DTOforOrderProduct>();

            foreach (var item in myOrders)
            {
                DTOforOrderProduct product = new DTOforOrderProduct();
                product.OrderId = item.orderId;
                product.productname = item.product.Name;
                product.productprice = item.product.Price;
                product.productimage = item.product.ProductImage;
                product.quantity = item.Quantity;
                product.totalprice = item.Totalprice;
                products.Add(product);
            }
            return Ok(products);
        }



        [HttpGet]
        [Route("{pricefrom}/{priceto}/{name}")]
        public IActionResult getbypriceandname(int pricefrom, int priceto, string name)
        {
            List<orderproduct> myOrders = orderProductRepository.SearchForOrderByPriceAndName(pricefrom, priceto, name);

            List<DTOforOrderProduct> products = new List<DTOforOrderProduct>();

            foreach (var item in myOrders)
            {
                DTOforOrderProduct product = new DTOforOrderProduct();
                product.OrderId = item.orderId;
                product.productname = item.product.Name;
                product.productprice = item.product.Price;
                product.productimage = item.product.ProductImage;
                product.quantity = item.Quantity;
                product.totalprice = item.Totalprice;
                products.Add(product);
            }
            return Ok(products);

        }
         

        
    }
}
