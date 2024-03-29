using AutoMapper;
using BusStation_API.Core.Domain.Entities;
using BusStation_API.Core.Domain.Interfaces;
using BusStation_API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BusStation_API.Infrastructure.Persistance.Services
{
    public class BusService : GenericService<Bus>, IBusService
    {
        private readonly DataContext _context;
        
        public BusService(DataContext context) : base(context)
        {
            _context = context;
        } 

        public async Task<Bus> AddBus(Bus bus)
        {
            await _context.Buses.AddAsync(bus);
            return bus;
        }

        public async Task<Bus> ChangeDrivingConditionToBus(int busId)
        {
            var result = await _context.Buses.FindAsync(busId);
            var ans = result.DrivingCondition == true ? false : true;
            result.DrivingCondition = ans;

            return result;
        }

        public async Task<bool> DeleteBus(int busId)
        {
            var result = await _context.Buses.FindAsync(busId);
            if (result == null)
                return false;

            try
            {
                _context.Buses.Remove(result);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<string>> GetNameOfBuses()
        {
            var res = await _context.Buses.Where(b=>b.DrivingCondition==true).Select(bus => bus.Name).ToListAsync();
            return res;
        }
    }
}
