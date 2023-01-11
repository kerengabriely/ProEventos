
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contextos
{
    public class ProEventosContext : DbContext
    {   
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options){ }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestrantesEventos> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestrantesEventos>().HasKey(PE => new {PE.EventoId, PE.PalestranteId});

            modelBuilder.Entity<Evento>().HasMany(E => E.RedesSociais).WithOne(RS => RS.Evento).OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Palestrante>().HasMany(E => E.RedesSociais).WithOne(RS => RS.Palestrante).OnDelete(DeleteBehavior.Cascade);
        }
    }
}