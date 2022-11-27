﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StreetFood.DAL;

#nullable disable

namespace StreetFood.DAL.Migrations
{
    [DbContext(typeof(StreetFoodDbContext))]
    [Migration("20221117061303_AddPropertiesInIngredientTableAndPropertiesIntStockProductTable")]
    partial class AddPropertiesInIngredientTableAndPropertiesIntStockProductTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StreetFood.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DimensionType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("StreetFood.Entities.StockProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastRevisionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId")
                        .IsUnique();

                    b.ToTable("StockProducts");
                });

            modelBuilder.Entity("StreetFood.Entities.StockProduct", b =>
                {
                    b.HasOne("StreetFood.Entities.Ingredient", "Ingredient")
                        .WithOne("StockProduct")
                        .HasForeignKey("StreetFood.Entities.StockProduct", "IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("StreetFood.Entities.Ingredient", b =>
                {
                    b.Navigation("StockProduct")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
