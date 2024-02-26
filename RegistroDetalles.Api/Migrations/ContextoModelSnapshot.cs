﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroDetalles.Api.DAL;

#nullable disable

namespace RegistroDetalles.Api.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Library.Models.Tickets", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Asunto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prioridad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sistema")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SolicitadoPor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TicketId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Library.Models.TicketsDetalles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Emisor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TicketId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketsDetalles");
                });

            modelBuilder.Entity("Library.Models.TicketsDetalles", b =>
                {
                    b.HasOne("Library.Models.Tickets", null)
                        .WithMany("TicketsDetalle")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Models.Tickets", b =>
                {
                    b.Navigation("TicketsDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
