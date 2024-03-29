namespace BusStation_API.Core.Domain.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Remove(T entity);

    }
}
