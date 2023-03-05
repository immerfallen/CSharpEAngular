using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {

        private readonly ProEventosContext _context;
        public ProEventosPersistence(ProEventosContext context)
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

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Evento.Include(e => e.Lote).Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query.Include(e => e.PalestrantesEventos).ThenInclude(p => p.Palestrante);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Evento.Include(e => e.Lote).Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query.Include(e => e.PalestrantesEventos).ThenInclude(p => p.Palestrante);
            }

            query = query.OrderBy(e => e.Id);

            query.Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Evento.Include(e => e.Lote).Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query.Include(e => e.PalestrantesEventos).ThenInclude(p => p.Palestrante);
            }

            query = query.OrderBy(e => e.Id);

            query.Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
            throw new NotImplementedException();
        }

        public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            throw new NotImplementedException();
        }



        public Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            throw new NotImplementedException();
        }


    }
}