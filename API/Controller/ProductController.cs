using JuniorTaskApi.DTO;
using JuniorTaskApi.Models;
using JuniorTaskApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JuniorTaskApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {



        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        //THIS FUNCTION IS USED IN THE TASK

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            List<Product> products = productRepository.GetAllProducts();
            if(products == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No Data Found")),
                    ReasonPhrase = "No Data Found"
                };
                return NotFound(resp.ReasonPhrase);
            }
            List<DTOforProduct> dtoproduct = new List<DTOforProduct>();
            foreach (var item in products)
            {
                DTOforProduct dTOforProduct = new DTOforProduct();
                dTOforProduct.ProductId = item.Id;
                dTOforProduct.ProductName = item.Name;
                dTOforProduct.productprice = item.Price;
                dTOforProduct.productimage= item.ProductImage;
                dtoproduct.Add(dTOforProduct);
            }
            return Ok(dtoproduct);
        }


        //ALL BELOW FUNCTIONS ARE NOT USED IN THE TASK

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProductsById(int id)
        {
            Product product = productRepository.GetProductsById(id);
            if(product == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"There Is No Product With ID={id}")),
                    ReasonPhrase = $"There Is No Product With ID={id}"
                };
                return NotFound(resp.ReasonPhrase);
            }
            DTOforProduct product1= new DTOforProduct();
            product1.ProductId = product.Id;
            product1.ProductName = product.Name;
            product1.productprice = product.Price;
            product1.productimage = product.ProductImage;

            return Ok(product1);
        }




        [HttpGet]
        [Route("{name:alpha}")]
        public IActionResult GetProductsByName(string name)
        {
            Product product = productRepository.GetProductsByName(name);
            if (product == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"There Is No Product With Name={name}")),
                    ReasonPhrase = $"There Is No Product With Name={name}"
                };
                return NotFound(resp.ReasonPhrase);
            }
            DTOforProduct product1 = new DTOforProduct();
            product1.ProductId = product.Id;
            product1.ProductName = product.Name;
            product1.productprice = product.Price;
            product1.productimage = product.ProductImage;
            return Ok(product1);
        }



        [HttpPost]
        public IActionResult AddNewProduct(Product newproduct)
        {
            if(ModelState.IsValid == true)
            {
                productRepository.AddNewProduct(newproduct);
                return Created("http://localhost:5283/api/Product" + newproduct.Id, newproduct);
            }

            var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(string.Format($"There Is Product With Name={newproduct.Name}")),
                ReasonPhrase = $"There Is Product With Name={newproduct.Name}"
            };
            return BadRequest(resp.ReasonPhrase);
        }




        [HttpPut]
        public IActionResult UpdateProduct([FromQuery] int id, [FromBody] Product product)
        {
            Product product1 = productRepository.GetProductsById(id);
            if(product1 == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"There Is No Product With ID={id}")),
                    ReasonPhrase = $"There Is No Product With ID={id}"
                };
                return NotFound(resp.ReasonPhrase);
            }
            productRepository.UpdateProduct(id, product);
            return Ok(product);
        }





        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteProductById(int id)
        {
            Product product = productRepository.GetProductsById(id);
            if(product == null) 
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"There Is No Product With ID={id}")),
                    ReasonPhrase = $"There Is No Product With ID={id}"
                };
                return NotFound(resp.ReasonPhrase);
            }
            productRepository.DeleteProductById(id);
            return Ok(product);
        }




        [HttpDelete]
        [Route("{name:alpha}")]
        public IActionResult DeleteProductByName(string name)
        {
            Product product = productRepository.GetProductsByName(name);
            if (product == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"There Is No Product With Name={name}")),
                    ReasonPhrase = $"There Is No Product With Name={name}"
                };
                return NotFound(resp.ReasonPhrase);
            }
            productRepository.DeleteProductByName(name);
            return Ok(product);
        }
    }
}
