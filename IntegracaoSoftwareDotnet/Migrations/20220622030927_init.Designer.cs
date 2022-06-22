﻿// <auto-generated />
using System;
using IntegracaoSoftwareDotnet.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IntegacaoSoftwareDotnet.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220622030927_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IntegacaoSoftwareDotnet.Models.CharacterAvailable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("activeSpecRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("itemLevelEquipped")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CharactersAvailable");
                });

            modelBuilder.Entity("IntegracaoSoftwareDotnet.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("activeSpecName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("activeSpecRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("faction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("itemLevelEquipped")
                        .HasColumnType("int");

                    b.Property<string>("region")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("IntegracaoSoftwareDotnet.Models.Party", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Party");
                });

            modelBuilder.Entity("IntegracaoSoftwareDotnet.Models.Character", b =>
                {
                    b.HasOne("IntegracaoSoftwareDotnet.Models.Party", "Party")
                        .WithMany("Characters")
                        .HasForeignKey("GroupId");

                    b.Navigation("Party");
                });

            modelBuilder.Entity("IntegracaoSoftwareDotnet.Models.Party", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
