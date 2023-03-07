using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Interfaces;
using ProEventos.Persistence.Context;

namespace ProEventos.Persistence.Services
{
    public class GeralPersistence : IGeralPersistence
    {

        private readonly ProEventosContext _context;
        public GeralPersistence(ProEventosContext context)
        {
            _context = context;

        }


        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entities) where T : class
        {
            _context.RemoveRange(entities);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }       


    }
}