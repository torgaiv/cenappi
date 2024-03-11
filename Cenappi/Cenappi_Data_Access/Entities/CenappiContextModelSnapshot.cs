﻿// <auto-generated />
using System;
using Cenappi.Cenappi_Data_Access.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cenappi.Entities
{
    [DbContext(typeof(CenappiContext))]
    partial class CenappiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.Day", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeTypeId")
                        .HasColumnType("int");

                    b.Property<int>("WeekId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("WeekId");

                    b.ToTable("Day");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.DayConfigurator", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime>("Days")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipeTypeId")
                        .HasColumnType("int");

                    b.Property<int>("WeekConfiguratorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WeekConfiguratorId");

                    b.ToTable("DayConfigurator");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.Ingredient", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("IngredientId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.Rations", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("QuantityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Rations");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.Recipe", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("CategoryKey")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Preparation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.Tags", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.Week", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime>("EndDay")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartingDay")
                        .HasColumnType("datetime2");

                    b.Property<int>("YearId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("YearId");

                    b.ToTable("Week");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.WeekConfigurator", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WeekConfigurator");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.Year", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Year");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.Day", b =>
                {
                    b.HasOne("Cenappi.Cenappi_Data_Access.Model.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cenappi.Cenappi_Data_Access.Model.Week", "Week")
                        .WithMany("Days")
                        .HasForeignKey("WeekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("Week");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.DayConfigurator", b =>
                {
                    b.HasOne("Cenappi.Cenappi_Data_Access.Model.WeekConfigurator", "WeekConfigurator")
                        .WithMany("Days")
                        .HasForeignKey("WeekConfiguratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WeekConfigurator");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.Ingredient", b =>
                {
                    b.HasOne("Cenappi.Cenappi_Data_Access.Model.Ingredient", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("IngredientId");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.Rations", b =>
                {
                    b.HasOne("Cenappi.Cenappi_Data_Access.Model.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cenappi.Cenappi_Data_Access.Model.Recipe", null)
                        .WithMany("Rations")
                        .HasForeignKey("RecipeId");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.Week", b =>
                {
                    b.HasOne("Cenappi.Cenappi_Data_Access.Model.Year", "Year")
                        .WithMany("Weeks")
                        .HasForeignKey("YearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Year");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.Ingredient", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.Recipe", b =>
                {
                    b.Navigation("Rations");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.Week", b =>
                {
                    b.Navigation("Days");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.WeekConfigurator", b =>
                {
                    b.Navigation("Days");
                });

            modelBuilder.Entity("Cenappi.Cenappi_Data_Access.Model.Year", b =>
                {
                    b.Navigation("Weeks");
                });
#pragma warning restore 612, 618
        }
    }
}
