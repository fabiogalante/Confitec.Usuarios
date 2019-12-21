using Confitec.Usuarios.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Usuarios.API.Data
{
    public class UsuariosDbContex : DbContext
    {
        public UsuariosDbContex(DbContextOptions<UsuariosDbContex> options) : base(options) { }

        public virtual DbSet<Models.Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().Property(s => s.Id).HasColumnName("Id").IsRequired();
        }


    }
}
