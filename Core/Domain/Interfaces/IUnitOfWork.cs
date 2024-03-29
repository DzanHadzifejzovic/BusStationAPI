namespace BusStation_API.Core.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable 
    {
        IBusLineService BusLineService { get; }
        IBusService BusService { get; }
        Task<int> SaveAsync();
    }
}
