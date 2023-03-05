using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Domain.Models;

namespace ProEventos.Persistence
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) 
        : base(options)
        {
            
        }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<Palestrante> Palestrante { get; set; }
        public DbSet<RedeSocial> RedeSocial { get; set; }
        public DbSet<PalestranteEvento> PalestranteEvento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

modelBuilder.Entity<PalestranteEvento>().HasKey(PE=> new {PE.EventoId, PE.PalestranteId});

        }

    }
}