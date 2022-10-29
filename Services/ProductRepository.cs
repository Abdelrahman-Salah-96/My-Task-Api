using JuniorTaskApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JuniorTaskApi.Services
{
    public class ProductRepository : IProductRepository
    {


        TaskDatabase context;
        public ProductRepository(TaskDatabase _context)
        {
            context = _context;
        }



        public List<Product> GetAllProducts()
        {
            List<Product> products = context.Products.Include(s => s.Orderproducts).ToList();
            return products;
        }



        public Product GetProductsById(int id)
        {
            Product product = context.Products.Include(x => x.Orderproducts).FirstOrDefault(x => x.Id == id);
            return product;
        }



        public Product GetProductsByName(string name)
        {
            Product product = context.Products.Include(s => s.Orderproducts).FirstOrDefault(x => x.Name == name);
            return product;
        }



        public Product GetProductsByPrice(int price)
        {
            Product product = context.Products.Include(x => x.Orderproducts).FirstOrDefault(x => x.Price == price);
            return product;
        }



        public int AddNewProduct(Product product)
        {
            context.Products.Add(product);
            int row = context.SaveChanges();
            return row;
        }



        public Product UpdateProduct(int id, Product newproduct)
        {
            Product oldproduct = context.Products.FirstOrDefault(x => x.Id == id);
            if (oldproduct != null)
            {
                oldproduct.Name = newproduct.Name;
                oldproduct.Price = newproduct.Price;
                oldproduct.ProductImage = newproduct.ProductImage;
                context.SaveChanges();
            }

            return newproduct;
        }



        public Product DeleteProductById(int id)
        {
            Product deletedproduct = context.Products.FirstOrDefault(s => s.Id == id);
            if (deletedproduct != null)
            {
                context.Products.Remove(deletedproduct);
                context.SaveChanges();
            }
            return deletedproduct;
        }




        public Product DeleteProductByName(string name)
        {
            Product deletedproduct = context.Products.FirstOrDefault(s => s.Name == name);
            if (deletedproduct != null)
            {
                context.Products.Remove(deletedproduct);
                context.SaveChanges();
            }
            return deletedproduct;
        }

    }
}
