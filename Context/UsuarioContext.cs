using CrudUsuarioBackend.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CrudUsuarioBackend.Context
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext() { }

        public UsuarioContext(DbContextOptions<UsuarioContext> opcoes) : base(opcoes) { }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.IdUsuario);

        }
    }
}
