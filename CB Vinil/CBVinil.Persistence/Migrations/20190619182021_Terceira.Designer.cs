﻿// <auto-generated />
using System;
using CBVinil.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CBVinil.Persistence.Migrations
{
    [DbContext(typeof(CBVinilContext))]
    [Migration("20190619182021_Terceira")]
    partial class Terceira
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CBVinil.Domain.Entities.CashbackParametro", b =>
                {
                    b.Property<int>("IdCaskbackParametro");

                    b.Property<int>("IdDiaSemana");

                    b.Property<int>("IdGeneroMusical");

                    b.Property<decimal>("Percentual");

                    b.HasKey("IdCaskbackParametro");

                    b.HasIndex("IdDiaSemana");

                    b.HasIndex("IdGeneroMusical");

                    b.ToTable("CashbackParametro");
                });

            modelBuilder.Entity("CBVinil.Domain.Entities.DiaSemana", b =>
                {
                    b.Property<int>("IdDiaSemana");

                    b.Property<int>("DiaDaSemana");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("IdDiaSemana");

                    b.ToTable("DiaSemana");
                });

            modelBuilder.Entity("CBVinil.Domain.Entities.Disco", b =>
                {
                    b.Property<int>("IdDisco")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Artistas")
                        .IsRequired()
                        .HasMaxLength(512);

                    b.Property<string>("CodSpotify")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("IdGeneroMusical");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<decimal>("Preco");

                    b.HasKey("IdDisco");

                    b.HasIndex("IdGeneroMusical");

                    b.ToTable("Disco");
                });

            modelBuilder.Entity("CBVinil.Domain.Entities.GeneroMusical", b =>
                {
                    b.Property<int>("IdGeneroMusical");

                    b.Property<string>("Descricao")
                        .HasMaxLength(32);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("IdGeneroMusical");

                    b.ToTable("GeneroMusical");
                });

            modelBuilder.Entity("CBVinil.Domain.Entities.ItemVenda", b =>
                {
                    b.Property<int>("IdItemVenda")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdDisco");

                    b.Property<int>("IdVenda");

                    b.Property<decimal>("PercentualCashback");

                    b.Property<decimal>("PrecoUnitario");

                    b.Property<int>("Quantidade");

                    b.Property<decimal>("ValorCashback");

                    b.Property<decimal>("ValorEfetivo");

                    b.Property<decimal>("ValorTotal");

                    b.HasKey("IdItemVenda");

                    b.HasIndex("IdDisco");

                    b.HasIndex("IdVenda");

                    b.ToTable("ItemVenda");
                });

            modelBuilder.Entity("CBVinil.Domain.Entities.Venda", b =>
                {
                    b.Property<int>("IdVenda")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataVenda");

                    b.Property<decimal>("ValorCashback");

                    b.Property<decimal>("ValorEfetivo");

                    b.Property<decimal>("ValorTotal");

                    b.HasKey("IdVenda");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("CBVinil.Domain.Entities.CashbackParametro", b =>
                {
                    b.HasOne("CBVinil.Domain.Entities.DiaSemana", "DiaSemana")
                        .WithMany("CashbackParametros")
                        .HasForeignKey("IdDiaSemana")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CBVinil.Domain.Entities.GeneroMusical", "GeneroMusical")
                        .WithMany("CashbackParametros")
                        .HasForeignKey("IdGeneroMusical")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CBVinil.Domain.Entities.Disco", b =>
                {
                    b.HasOne("CBVinil.Domain.Entities.GeneroMusical", "GeneroMusical")
                        .WithMany("Discos")
                        .HasForeignKey("IdGeneroMusical")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CBVinil.Domain.Entities.ItemVenda", b =>
                {
                    b.HasOne("CBVinil.Domain.Entities.Disco", "Disco")
                        .WithMany("ItensVenda")
                        .HasForeignKey("IdDisco")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CBVinil.Domain.Entities.Venda", "Venda")
                        .WithMany("ItensVenda")
                        .HasForeignKey("IdVenda")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
