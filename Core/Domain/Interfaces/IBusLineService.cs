using BusStation_API.Core.Domain.Entities;

namespace BusStation_API.Core.Domain.Interfaces
{
    public interface IBusLineService:IGenericService<BusLine>
    {
        Task<List<BusLine>> GetAllBusLines();
        Task<List<BusLine>> GetAllBusLinesForWorker(string username);
        Task<BusLine?> GetBusLineById(int id);
        Task<List<int>> GetAllNumbersOfPlatforms();
        Task<BusLine> AddBusLine(BusLine busLineCreateDto);
        Task<bool> DeleteBusLine(int id);
        Task<bool> EditBusLine(BusLine inputEditData);
    }
}
