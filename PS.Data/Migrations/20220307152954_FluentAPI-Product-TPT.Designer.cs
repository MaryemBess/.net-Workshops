﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PS.Data;

namespace PS.Data.Migrations
{
    [DbContext(typeof(PSContext))]
    [Migration("20220307152954_FluentAPI-Product-TPT")]
    partial class FluentAPIProductTPT
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PS.Domain.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("MyCategories");
                });

            modelBuilder.Entity("PS.Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateProd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("ProductId1")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryFK");

                    b.HasIndex("ProductId1");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PS.Domain.Provider", b =>
                {
                    b.Property<int>("ProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProviderId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("ProductProvider", b =>
                {
                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProvidersProviderId")
                        .HasColumnType("int");

                    b.HasKey("ProductsProductId", "ProvidersProviderId");

                    b.HasIndex("ProvidersProviderId");

                    b.ToTable("Providings");
                });

            modelBuilder.Entity("PS.Domain.Biological", b =>
                {
                    b.HasBaseType("PS.Domain.Product");

                    b.Property<string>("Herbs")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("biological");
                });

            modelBuilder.Entity("PS.Domain.Chemical", b =>
                {
                    b.HasBaseType("PS.Domain.Product");

                    b.Property<string>("LabName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("chemical");
                });

            modelBuilder.Entity("PS.Domain.Product", b =>
                {
                    b.HasOne("PS.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PS.Domain.Product", null)
                        .WithMany("Products")
                        .HasForeignKey("ProductId1");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ProductProvider", b =>
                {
                    b.HasOne("PS.Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PS.Domain.Provider", null)
                        .WithMany()
                        .HasForeignKey("ProvidersProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PS.Domain.Biological", b =>
                {
                    b.HasOne("PS.Domain.Product", null)
                        .WithOne()
                        .HasForeignKey("PS.Domain.Biological", "ProductId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PS.Domain.Chemical", b =>
                {
                    b.HasOne("PS.Domain.Product", null)
                        .WithOne()
                        .HasForeignKey("PS.Domain.Chemical", "ProductId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.OwnsOne("PS.Domain.Adress", "Adress", b1 =>
                        {
                            b1.Property<int>("ChemicalProductId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StreetAdress")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ChemicalProductId");

                            b1.ToTable("chemical");

                            b1.WithOwner()
                                .HasForeignKey("ChemicalProductId");
                        });

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("PS.Domain.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PS.Domain.Product", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}