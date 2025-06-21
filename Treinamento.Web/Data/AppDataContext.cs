using Microsoft.EntityFrameworkCore;
using Treinamento.Web.Models;

namespace Treinamento.Web.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        public DbSet<Linguagem> Linguagens { get; set; } 
        public DbSet<Informacao> Informacoes { get; set; } 


        // Opcional, mas boa prática para configurar relacionamentos e propriedades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura o relacionamento um-para-muitos
            modelBuilder.Entity<Informacao>()
                .HasOne(i => i.Linguagem) // Uma Informacao tem uma Linguagem
                .WithMany(l => l.Informacoes) // Uma Linguagem tem muitas Informacoes
                .HasForeignKey(i => i.LinguagemId); // A chave estrangeira está em Informacao

            // Você pode adicionar dados iniciais (seed data) aqui também
            modelBuilder.Entity<Linguagem>().HasData(
                new Linguagem { Id = 1, Nome = "Java" },
                new Linguagem { Id = 2, Nome = "C#" }
            );
        }
    }
}