using JC_BlueTec.Infra.Mappings;
using JC_BlueTec.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace JC_BlueTec.Infra.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClienteMap());
            builder.ApplyConfiguration(new UserMap());
        }
    }
}