using BusStation_API.Core.Domain.Entities;

namespace BusStation_API.Core.Domain.Interfaces
{
    public interface IBusService : IGenericService<Bus>
    {
        Task<Bus> AddBus(Bus busCreateDTO); //BusCreateDTO
        Task<bool> DeleteBus(int busId);
        Task<Bus> ChangeDrivingConditionToBus(int busId);
        Task<List<string>> GetNameOfBuses();

    }
}
