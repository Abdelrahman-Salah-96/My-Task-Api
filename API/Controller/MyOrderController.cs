using JuniorTaskApi.DTO;
using JuniorTaskApi.Models;
using JuniorTaskApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JuniorTaskApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyOrderController : ControllerBase
    {


        private readonly IMyOrderRepository myOrderRepository;
        public MyOrderController(IMyOrderRepository myOrderRepository)
        {
            this.myOrderRepository = myOrderRepository;    
        }



       //THIS FUNCTION IS RESPONSIBLE FOR PURCHASE BUTTON WHICH ENABLE USERS TO MAKE THEIR ORDERS  

        [HttpPost]
        public IActionResult insert(DTOforMyOrder myOrder)
        {
           if(ModelState.IsValid == true)
            {
                myOrderRepository.AddNewOrder(myOrder);
                return Ok( myOrder);
            }
            return BadRequest();

        }
    }
}
