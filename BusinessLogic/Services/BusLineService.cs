using AutoMapper;
using BusinessLogic.Interfaces;
using Data;
using Data.Models;
using Mappings.DTOs.BusLine;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class BusLineService : GenericService<BusLine>, IBusLineService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<BaseUser> _userManager;

        public BusLineService(DataContext context, IMapper mapper, UserManager<BaseUser> userManager) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<BusLine>> GetAllBusLines() =>
            await _context.BusLines
           .Include(b1 => b1.Bus)
           .Include(bl => bl.BusLineUsers) // Uključuje sve povezane BaseUser objekte
                .ThenInclude(b1 => b1.User)
           .OrderByDescending(bl => bl.DepartureTime)
           .Where(b => b.Bus.DrivingCondition == true)
           .ToListAsync();

        public async Task<List<BusLine>> GetAllBusLinesForWorker(string username) =>
            await _context.BusLines
           .Include(b1 => b1.Bus)
           .Include(bl => bl.BusLineUsers) // Uključuje sve povezane BaseUser objekte
                .ThenInclude(b1 => b1.User)
           .OrderByDescending(bl => bl.DepartureTime)
           .Where(b => b.Bus.DrivingCondition == true)
           .Where(user => user.BusLineUsers.Any(u => u.User.UserName == username))
           .ToListAsync();

        public async Task<BusLine?> GetBusLineById(int id)
        {
            var busLine = await _context.BusLines
            .Include(b1 => b1.Bus)
            .Include(bl => bl.BusLineUsers)
                .ThenInclude(b1 => b1.User)
            .FirstOrDefaultAsync(bl => bl.Id == id);

            return busLine;
        }

        public async Task<List<int>> GetAllNumbersOfPlatforms() =>
            await _context.BusLines.Select(bl => bl.NumberOfPlatform).Distinct().ToListAsync();


        public async Task<BusLine> AddBusLine(BusLineCreateDTO busLineCreateDto)
        {
            var result = _mapper.Map<BusLine>(busLineCreateDto);

            var bus = await _context.Buses.FindAsync(busLineCreateDto.BusId);
            //result.Bus = bus;

            var conductor = await _userManager.FindByIdAsync(busLineCreateDto.ConductorId);
            result.BusLineUsers.Add(new BusLineUser { User = conductor });

            var driver = await _userManager.FindByIdAsync(busLineCreateDto.DriverId);
            result.BusLineUsers.Add(new BusLineUser { User = driver });

            await _context.BusLines.AddAsync(result);

            return result;
        }
        public async Task<bool> DeleteBusLine(int id)
        {
            var result = await _context.BusLines.FindAsync(id);
            if (result == null)
                return false;

            try
            {
                _context.BusLines.Remove(result);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> EditBusLine(BusLineInputForEditDTO inputEditData)
        {
            if (inputEditData.NumOfCards != null)
            {
               await ChangeNumberOfReservedCards(inputEditData.BusLineId, (int) inputEditData.NumOfCards);
            }
            if (inputEditData.DateTime != null)
            {
                await ChangeDepartureTime(inputEditData.BusLineId, (DateTime) inputEditData.DateTime);
            }
            if (inputEditData.BusId != null)
            {
                await ChangeBusForBusLine(inputEditData.BusLineId, (int)inputEditData.BusId);
            }
            if (inputEditData.ConductorId != null && inputEditData.OldConductorId != null)
            {
                await ChangeConductorForBusLine(inputEditData.BusLineId,inputEditData.OldConductorId,inputEditData.ConductorId);
            }
            if (inputEditData.DriverId != null && inputEditData.OldDriverId != null)
            {
                await ChangeDriverForBusLine(inputEditData.BusLineId,inputEditData.OldDriverId,inputEditData.DriverId);
            }

            return true;
        }

        /**/
        private async Task<bool> ChangeBusForBusLine(int busLineId, int busId)
        {
            var busLine = await GetBusLineById(busLineId);
            var bus = await _context.Buses.FindAsync(busId);

            if (busLine != null && bus != null)
            {
                busLine.BusId = busId;
                busLine.Bus = bus;

                return true;
            }
            return false;
        }
        private async Task<bool> ChangeConductorForBusLine(int busLineId, string oldConductorId, string conductorId)
        {
            var result = await GetBusLineById(busLineId);

            if (result == null)
                return false;

            var user = await _context.BusLinesUsers.FirstAsync(b => b.BusLineId == busLineId && b.UserId == oldConductorId);
            user.UserId = conductorId;

            return true;
        }
        private async Task<bool> ChangeDriverForBusLine(int busLineId, string oldDriverId, string driverId)
        {
            var result = await GetBusLineById(busLineId);

            if (result == null)
                return false;

            var user = await _context.BusLinesUsers.FirstAsync(b => b.BusLineId == busLineId && b.UserId == oldDriverId);
            user.UserId = driverId;

            return true;
        }
        private async Task<bool> ChangeDepartureTime(int busLineId, DateTime dateTime)
        {
            var result = await GetBusLineById(busLineId);
            if (result != null)
            {
                result.DepartureTime = dateTime;
                return true; 
            }
            return false;

        }
        private async Task<bool> ChangeNumberOfReservedCards(int busLineId, int numOfCards)
        {
            var result = await GetBusLineById(busLineId);
            var numOfSeats = result.Bus.NumberOfSeats; 

            if (result != null)
            {
                result.NumberOfReservedCards += numOfCards;
                if (result.NumberOfReservedCards<= numOfSeats)
                {
                    return true;
                }
            }
            return false;
        }



    }
}