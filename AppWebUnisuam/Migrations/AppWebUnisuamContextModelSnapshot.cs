﻿// <auto-generated />
using System;
using AppWebUnisuam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppWebUnisuam.Migrations
{
    [DbContext(typeof(AppWebUnisuamContext))]
    partial class AppWebUnisuamContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AppWebUnisuam.Models.Cadastro", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Perfil")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cadastro");
                });

            modelBuilder.Entity("AppWebUnisuam.Models.Produtos", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Categoria")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descrição")
                        .HasColumnType("longtext");

                    b.Property<string>("Disponibilidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Estoque")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Imagem")
                        .HasColumnType("longtext");

                    b.Property<string>("Marca")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Preco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("AppWebUnisuam.Models.Vendas", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataDaVenda")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Desconto")
                        .HasColumnType("longtext");

                    b.Property<string>("FormaDePagamento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Funcionario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Observacoes")
                        .HasColumnType("longtext");

                    b.Property<string>("PrecoUnitario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Produto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Quantidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ValorDaVenda")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}
