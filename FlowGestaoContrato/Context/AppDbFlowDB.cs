using FlowGestaoContrato.Mapeamentos;
using FlowGestaoContrato.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//  public class AppDbFlowDB : DbContext
namespace FlowGestaoContrato.Context
{
    public class AppDbFlowDB : IdentityDbContext<Usuario, Funcao, string>
    {
        // Cria construtor de contexto
        public DbSet<Funcao> Funcoes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Processo> Processos { get; set; }

        public DbSet<ContatoFornecedor> ContatosFornecedor { get; set; }

        public AppDbFlowDB(DbContextOptions<AppDbFlowDB> opcoes) : base(opcoes)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UsuarioMap());
            builder.ApplyConfiguration(new FuncaoMap());

            builder.Entity<ContatoFornecedor>(entity =>
            {
                entity.HasNoKey();
            });

            // builder.ApplyConfiguration(new ProcessoMap());

            //builder.Entity<Processo>(entity =>
            //{
            //    entity.HasNoKey();
            //});

            //builder.Entity<Usuario>(entity =>
            //{
            //    entity.HasNoKey();
            //});

            //builder.Entity<Funcao>(entity =>
            //{
            //    entity.HasNoKey();
            //});


        }
    }
}
