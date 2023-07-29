using AutoMapper;
using BusinessLogic.Interfaces;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class GenericService<T>:IGenericService<T> where T : class
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GenericService(DataContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }  
        public async Task Add(T entity)=> await _context.Set<T>().AddAsync(entity);

        public IQueryable<T> GetAll() => _context.Set<T>().AsQueryable();
        public async Task<IEnumerable<T>> GetAllAsync()=> await _context.Set<T>().ToListAsync();
        public async Task<T> GetById(int id) => await _context.Set<T>().FindAsync(id);
        public void Remove(T entity) =>  _context.Set<T>().Remove(entity);
    }
}
