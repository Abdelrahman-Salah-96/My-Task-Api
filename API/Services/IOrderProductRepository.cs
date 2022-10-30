using JuniorTaskApi.Models;

namespace JuniorTaskApi.Services
{
    public interface IOrderProductRepository
    {
        List<orderproduct> getall();
        List<orderproduct> Getbyid(int id);
        List<orderproduct> SearchForOrderByName(string name);
        List<orderproduct> SearchForOrderByPrice(int PriceFrom, int PriceTo);
        List<orderproduct> SearchForOrderByPriceAndName(int PriceFrom, int PriceTo, string name);
    }
}