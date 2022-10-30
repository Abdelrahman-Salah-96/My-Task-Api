using JuniorTaskApi.Models;

namespace JuniorTaskApi.Services
{
    public interface IProductRepository
    {
        int AddNewProduct(Product product);
        Product DeleteProductById(int id);
        Product DeleteProductByName(string name);
        List<Product> GetAllProducts();
        Product GetProductsById(int id);
        Product GetProductsByName(string name);
        Product GetProductsByPrice(int price);
        Product UpdateProduct(int id, Product newproduct);
    }
}