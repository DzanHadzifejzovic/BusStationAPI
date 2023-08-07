using BusinessLogic.Interfaces;

namespace BusinessLogic.UnitOfWork
{
    public interface IUnitOfWork : IDisposable 
    {
        IBusLineService BusLineService { get; }
        IBusService BusService { get; }
        Task<int> SaveAsync();
    }
}
