using BusinessLogic.Interfaces;

namespace BusinessLogic.UnitOfWork
{
    //it's connection layer between the WebApi project(Mediator in my case) and the repositories
    public interface IUnitOfWork : IDisposable 
    {
        IBusLineService BusLineService { get; }
        IBusService BusService { get; }
        Task<int> SaveAsync();
    }
}
