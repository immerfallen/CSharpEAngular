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
    public class PalestrantePersistence : IPalestrantePersistence
    {

        private readonly ProEventosContext _context;
        public PalestrantePersistence(ProEventosContext context)
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

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos =false)
        {
           IQueryable<Palestrante> query = _context.Palestrante.Include(e => e.RedesSociais);

            if (includeEventos)
            {
                query.Include(e => e.PalestrantesEventos).ThenInclude(p => p.Evento);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrante.Include(e => e.RedesSociais);

            if (includeEventos)
            {
                query.Include(e => e.PalestrantesEventos).ThenInclude(p => p.Evento);
            }

            query = query.OrderBy(e => e.Id).Where(p=> p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }



        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
           IQueryable<Palestrante> query = _context.Palestrante.Include(e => e.RedesSociais);

            if (includeEventos)
            {
                query.Include(e => e.PalestrantesEventos).ThenInclude(p => p.Evento);
            }

            query = query.OrderBy(e => e.Id).Where(p=>p.Id == palestranteId);               
            

            return await query.FirstOrDefaultAsync();
        }


    }
}