using AutoMapper;
using BusStation_API.Core.Domain.Interfaces;
using BusStation_API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BusStation_API.Infrastructure.Persistance.Services
{
    public class GenericService<T>:IGenericService<T> 
        where T : class
    {
        private readonly DataContext _context;

        public GenericService(DataContext context)
        {
           _context = context;
        }  
        public async Task Add(T entity)=> await _context.Set<T>().AddAsync(entity);

        public IQueryable<T> GetAll() => _context.Set<T>().AsQueryable();
        public async Task<IEnumerable<T>> GetAllAsync()=> await _context.Set<T>().ToListAsync();
        public async Task<T> GetById(int id) => await _context.Set<T>().FindAsync(id);
        public void Remove(T entity) =>  _context.Set<T>().Remove(entity);
    }
}
