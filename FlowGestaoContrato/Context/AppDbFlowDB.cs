using FlowGestaoContrato.Models;
using FlowGestaoContrato.Mapeamentos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowGestaoContrato.Context
{
    public class AppDbFlowDB : DbContext
    {
        // Cria construtor de contexto
        public DbSet<Funcao> Funcoes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public AppDbFlowDB(DbContextOptions<AppDbFlowDB> opcoes) : base(opcoes)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UsuarioMap());
            builder.ApplyConfiguration(new FuncaoMap());
        }
    }
}
