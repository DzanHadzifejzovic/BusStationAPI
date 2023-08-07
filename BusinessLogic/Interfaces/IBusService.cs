using Data.Models;
using Mappings.DTOs.Bus;

namespace BusinessLogic.Interfaces
{
    public interface IBusService : IGenericService<Bus>
    {
        Task<Bus> AddBus(BusCreateDTO busCreateDTO);
        Task<bool> DeleteBus(int busId);
        Task<Bus> ChangeDrivingConditionToBus(int busId);
        Task<List<string>> GetNameOfBuses();

    }
}
