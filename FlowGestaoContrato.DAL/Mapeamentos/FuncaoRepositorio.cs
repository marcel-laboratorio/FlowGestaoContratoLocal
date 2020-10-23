using FlowGestaoContrato.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace FlowGestaoContrato.DAL.Mapeamentos
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
