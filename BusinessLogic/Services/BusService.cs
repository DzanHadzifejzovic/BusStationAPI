using AutoMapper;
using BusinessLogic.Interfaces;
using Data;
using Data.Models;
using Mappings.DTOs.Bus;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class BusService : GenericService<Bus>, IBusService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public BusService(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Bus> AddBus(BusCreateDTO busCreateDTO)
        {
            var result = _mapper.Map<Bus>(busCreateDTO);

            await _context.Buses.AddAsync(result);
            return result;
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
