using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBibliotecaCsharpNET.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIBibliotecaCsharpNET.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Livro> livros { get; set; }
        public DbSet<Emprestimo> emprestimos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emprestimo>()
                .Property(e => e.DataEmprestimo)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Emprestimo>()
                .Property(e => e.DataDevolucao)
                .HasColumnType("datetime2");
        }
    }
}