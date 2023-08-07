using Data.Models;
using Mappings.DTOs.BusLine;

namespace BusinessLogic.Interfaces
{
    public interface IBusLineService:IGenericService<BusLine>
    {
        Task<List<BusLine>> GetAllBusLines();
        Task<List<BusLine>> GetAllBusLinesForWorker(string username);
        Task<BusLine?> GetBusLineById(int id);
        Task<List<int>> GetAllNumbersOfPlatforms();
        Task<BusLine> AddBusLine(BusLineCreateDTO busLineCreateDto);
        Task<bool> DeleteBusLine(int id);
        Task<bool> EditBusLine(BusLineInputForEditDTO inputEditData);
        
    }
}
