using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BusinessLogic.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<BaseUser> _userManager;


        public UnitOfWork(DataContext context,IMapper mapper,UserManager<BaseUser> userManager)
        {
            _context = context;
            _mapper = mapper;            
            _userManager = userManager;
            BusService = new BusService(_context,_mapper);
            BusLineService = new BusLineService(_context, _mapper,_userManager);
        }
        public IBusLineService BusLineService { get; private set; }

        public IBusService BusService { get; private set; }
        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    }
}
