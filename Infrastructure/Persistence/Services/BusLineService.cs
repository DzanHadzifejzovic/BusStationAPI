using BusStation_API.Core.Domain.Entities;
using BusStation_API.Core.Domain.Interfaces;
using BusStation_API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BusStation_API.Infrastructure.Persistance.Services
{
    public class BusLineService : GenericService<BusLine>, IBusLineService
    {
        private readonly DataContext _context;

        public BusLineService(DataContext context) : base(context)
        {
            _context = context;
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
           .Where(user => user.BusLineUsers.Any(u => u.User.UserName == username)) //
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
        public async Task<BusLine> AddBusLine(BusLine busLine)
        {
            await _context.BusLines.AddAsync(busLine);
            return busLine;
        }
        public async Task<bool> DeleteBusLine(int id)
        {
            var result = await _context.BusLines.FindAsync(id);
            if (result == null)
                return false;

            try
            {
             var usersOnBusLine = await _context.BusLinesUsers
                .Where(blu => blu.BusLineId == id)
                .ToListAsync();

                _context.BusLinesUsers.RemoveRange(usersOnBusLine);

                _context.BusLines.Remove(result);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> EditBusLine(BusLine inputEditData)
        {
            if (inputEditData == null)
            {
                return false;
            }
            _context.BusLines.Update(inputEditData);

            return true;
        }


    }
}