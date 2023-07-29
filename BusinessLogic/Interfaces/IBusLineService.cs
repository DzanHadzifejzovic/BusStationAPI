using Data.Models;
using Mappings.DTOs.BusLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Task<bool> ChangeDepartureTime(int busLineId,DateTime dateTime);
        Task<bool> ChangeNumberOfReservedCards(int busLineId, int numOfCards);
        Task<bool> ChangeBusForBusLine(int busLineId, int busId);
        Task<bool> ChangeConductorForBusLine(int busLineId, string oldConductorId, string conductorId);
        Task<bool> ChangeDriverForBusLine(int busLineId, string oldDriverId, string driverId);
        
    }
}
