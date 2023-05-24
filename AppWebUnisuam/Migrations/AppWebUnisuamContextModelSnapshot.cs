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

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

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
#pragma warning restore 612, 618
        }
    }
}
