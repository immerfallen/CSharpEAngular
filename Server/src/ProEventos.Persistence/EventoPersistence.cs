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
    public class EventoPersistence : IEventoPersistence
    {

        private readonly ProEventosContext _context;
        public EventoPersistence(ProEventosContext context)
        {
            _context = context;

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

        


    }
}