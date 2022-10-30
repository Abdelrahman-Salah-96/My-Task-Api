using JuniorTaskApi.DTO;

namespace JuniorTaskApi.Services
{
    public interface IMyOrderRepository
    {
        int AddNewOrder(DTOforMyOrder order);
    }
}