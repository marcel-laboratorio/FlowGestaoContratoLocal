using FlowGestaoContrato.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowGestaoContrato.Mapeamentos
{
    public class FuncaoMap : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            builder.Property(f => f.Id).ValueGeneratedOnAdd(); // Gerado pelo banco de dados
            builder.Property(f => f.Descricao).IsRequired().HasMaxLength(30); // tamanho maximo

            builder.HasData(
                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Gestor",
                    NormalizedName = "GESTOR",
                    Descricao = "Gestor do Flow"
                },

                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Fornecedor",
                    NormalizedName = "FORNECEDOR",
                    Descricao = "Fornecedor Eneva"
                },

                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR",
                    Descricao = "Administrador do Flow"
                });

            builder.ToTable("Funcoes");
        }
    }
}
