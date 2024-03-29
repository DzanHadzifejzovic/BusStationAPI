using BusStation_API.Core.Domain.Interfaces;
using BusStation_API.Infrastructure.Persistence;

namespace BusStation_API.Infrastructure.Persistance.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
            BusService = new BusService(_context);
            BusLineService = new BusLineService(_context);
        }
        public IBusLineService BusLineService { get; private set; }

        public IBusService BusService { get; private set; }
        
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
