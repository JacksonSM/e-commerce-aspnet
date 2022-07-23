﻿// <auto-generated />
using System;
using AspStore.Infra.Data.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspStore.Infra.Data.Migrations
{
    [DbContext(typeof(AspStoreDbContext))]
    [Migration("20220723195433_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspStore.Domain.Entities.ConjuntoCarrinho.Carrinho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Carrinho");
                });

            modelBuilder.Entity("AspStore.Domain.Entities.ConjuntoCarrinho.ProdutoCarrinho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarrinhoId")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId");

                    b.HasIndex("ProdutoId")
                        .IsUnique();

                    b.ToTable("ProdutoCarrinho");
                });

            modelBuilder.Entity("AspStore.Domain.Entities.ConjuntoPedido.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("TipoEndereco")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("AspStore.Domain.Entities.ConjuntoPedido.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<bool>("PedidoConfirmado")
                        .HasColumnType("bit");

                    b.Property<double>("ValorEnvio")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.Property<double>("ValorTotal")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("AspStore.Domain.Entities.ConjuntoPedido.ProdutoPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<double>("PrecoUnidade")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId")
                        .IsUnique();

                    b.ToTable("ProdutoPedido");
                });

            modelBuilder.Entity("AspStore.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Preco")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("AspStore.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("AspStore.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("AspStore.Domain.Entities.ConjuntoCarrinho.Carrinho", b =>
                {
                    b.HasOne("AspStore.Entities.Cliente", "Cliente")
                        .WithOne("Carrinho")
                        .HasForeignKey("AspStore.Domain.Entities.ConjuntoCarrinho.Carrinho", "ClienteId")
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("AspStore.Domain.Entities.ConjuntoCarrinho.ProdutoCarrinho", b =>
                {
                    b.HasOne("AspStore.Domain.Entities.ConjuntoCarrinho.Carrinho", "Carrinho")
                        .WithMany("ProdutoCarrinho")
                        .HasForeignKey("CarrinhoId")
                        .IsRequired();

                    b.HasOne("AspStore.Domain.Entities.Produto", "Produto")
                        .WithOne()
                        .HasForeignKey("AspStore.Domain.Entities.ConjuntoCarrinho.ProdutoCarrinho", "ProdutoId")
                        .IsRequired();

                    b.Navigation("Carrinho");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("AspStore.Domain.Entities.ConjuntoPedido.Endereco", b =>
                {
                    b.HasOne("AspStore.Entities.Cliente", null)
                        .WithMany("Endereco")
                        .HasForeignKey("ClienteId")
                        .IsRequired();

                    b.OwnsOne("AspStore.Entities.ValueObjects.CEP", "CEP", b1 =>
                        {
                            b1.Property<int>("EnderecoId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Numero")
                                .HasColumnType("int");

                            b1.HasKey("EnderecoId");

                            b1.ToTable("Endereco");

                            b1.WithOwner()
                                .HasForeignKey("EnderecoId");
                        });

                    b.Navigation("CEP");
                });

            modelBuilder.Entity("AspStore.Domain.Entities.ConjuntoPedido.Pedido", b =>
                {
                    b.HasOne("AspStore.Entities.Cliente", "Cliente")
                        .WithMany("Pedido")
                        .HasForeignKey("ClienteId")
                        .IsRequired();

                    b.HasOne("AspStore.Domain.Entities.ConjuntoPedido.Endereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("AspStore.Domain.Entities.ConjuntoPedido.Pedido", "EnderecoId")
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("AspStore.Domain.Entities.ConjuntoPedido.ProdutoPedido", b =>
                {
                    b.HasOne("AspStore.Domain.Entities.ConjuntoPedido.Pedido", null)
                        .WithMany("ProdutoPedido")
                        .HasForeignKey("PedidoId")
                        .IsRequired();

                    b.HasOne("AspStore.Domain.Entities.Produto", "Produto")
                        .WithOne()
                        .HasForeignKey("AspStore.Domain.Entities.ConjuntoPedido.ProdutoPedido", "ProdutoId")
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("AspStore.Domain.Entities.Produto", b =>
                {
                    b.HasOne("AspStore.Entities.Categoria", "Categoria")
                        .WithMany("Produto")
                        .HasForeignKey("CategoriaId")
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("AspStore.Entities.Cliente", b =>
                {
                    b.OwnsOne("AspStore.Entities.ValueObjects.CPF", "CPF", b1 =>
                        {
                            b1.Property<int>("ClienteId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("NumeroCPF")
                                .IsRequired()
                                .HasMaxLength(12)
                                .HasColumnType("nvarchar(12)");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Cliente");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.Navigation("CPF");
                });

            modelBuilder.Entity("AspStore.Domain.Entities.ConjuntoCarrinho.Carrinho", b =>
                {
                    b.Navigation("ProdutoCarrinho");
                });

            modelBuilder.Entity("AspStore.Domain.Entities.ConjuntoPedido.Pedido", b =>
                {
                    b.Navigation("ProdutoPedido");
                });

            modelBuilder.Entity("AspStore.Entities.Categoria", b =>
                {
                    b.Navigation("Produto");
                });

            modelBuilder.Entity("AspStore.Entities.Cliente", b =>
                {
                    b.Navigation("Carrinho");

                    b.Navigation("Endereco");

                    b.Navigation("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}
