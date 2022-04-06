﻿// <auto-generated />
using System;
using BoxTrackLabel.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BoxTrackLabel.API.Migrations.BoxTrackLabelMigrations
{
    [DbContext(typeof(BoxTrackDbContext))]
    [Migration("20200525204758_usuarioGeneracionEtiqueta")]
    partial class usuarioGeneracionEtiqueta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BoxTrackLabel.API.Models.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Almacenamiento");

                    b.Property<int>("CantidadCigarros");

                    b.Property<string>("CodigoBarra");

                    b.Property<string>("CodigoQr");

                    b.Property<string>("DescripcionProducto");

                    b.Property<bool>("EsNula");

                    b.Property<DateTime>("FechaHoraAnulacion");

                    b.Property<DateTime>("FechaHoraCalendario");

                    b.Property<int>("ProduccionId");

                    b.Property<int>("Secuencia");

                    b.Property<int>("TextoEtiquetaId");

                    b.Property<string>("UsuarioAnulacion");

                    b.Property<string>("UsuarioGeneracion");

                    b.HasKey("Id");

                    b.HasIndex("ProduccionId");

                    b.HasIndex("TextoEtiquetaId");

                    b.ToTable("Etiqueta");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.LabelText", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Advertencia");

                    b.Property<string>("ClienteEspecifico");

                    b.Property<string>("Direccion");

                    b.Property<string>("IdPais");

                    b.Property<string>("TextoCantidad");

                    b.Property<string>("TextoPais");

                    b.HasKey("Id");

                    b.ToTable("TextoEtiqueta");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Module", b =>
                {
                    b.Property<string>("IdModulo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<bool>("EstaBorrado");

                    b.Property<DateTime?>("FechaHoraBorrado");

                    b.Property<DateTime?>("FechaHoraModificacion");

                    b.Property<DateTime>("FechaHoraRegistro")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdProceso");

                    b.Property<int>("NumeroModulo");

                    b.Property<string>("UsuarioEliminacion");

                    b.Property<string>("UsuarioModificacion");

                    b.Property<string>("UsuarioRegistro")
                        .IsRequired();

                    b.HasKey("IdModulo");

                    b.HasIndex("IdProceso");

                    b.ToTable("Modulo");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Process", b =>
                {
                    b.Property<string>("IdProceso")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<bool>("EstaBorrado");

                    b.Property<DateTime?>("FechaHoraBorrado");

                    b.Property<DateTime?>("FechaHoraModificacion");

                    b.Property<DateTime>("FechaHoraRegistro")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UsuarioEliminacion");

                    b.Property<string>("UsuarioModificacion");

                    b.Property<string>("UsuarioRegistro")
                        .IsRequired();

                    b.HasKey("IdProceso");

                    b.ToTable("Proceso");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Production", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaHoraAperturaTurno")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("FechaHoraCierreTurno");

                    b.Property<DateTime>("FechaProduccion")
                        .HasColumnType("Date");

                    b.Property<string>("IdModulo");

                    b.Property<string>("IdProceso");

                    b.Property<string>("IdProducto");

                    b.Property<string>("IdTurno");

                    b.Property<bool>("ProductoFinalizado");

                    b.Property<bool>("TurnoAbierto");

                    b.Property<string>("UsuarioAperturaTurno")
                        .IsRequired();

                    b.Property<string>("UsuarioCierreTurno");

                    b.HasKey("Id");

                    b.HasIndex("IdModulo");

                    b.HasIndex("IdProceso");

                    b.HasIndex("IdTurno");

                    b.ToTable("Produccion");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Schedule", b =>
                {
                    b.Property<DateTime>("FechaProduccion")
                        .HasColumnType("Date");

                    b.Property<string>("IdProceso");

                    b.Property<string>("IdModulo");

                    b.Property<string>("IdTurno");

                    b.Property<DateTime?>("FechaHoraFinalizado");

                    b.Property<DateTime>("FechaRegistro")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Finalizado");

                    b.Property<string>("IdProducto");

                    b.Property<string>("UsuarioFinalizado");

                    b.Property<string>("UsuarioProgramacion");

                    b.HasKey("FechaProduccion", "IdProceso", "IdModulo", "IdTurno");

                    b.HasIndex("IdModulo");

                    b.HasIndex("IdProceso");

                    b.HasIndex("IdTurno");

                    b.ToTable("Programacion");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Shift", b =>
                {
                    b.Property<string>("IdTurno")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<bool>("EstaBorrado");

                    b.Property<DateTime?>("FechaHoraBorrado");

                    b.Property<DateTime?>("FechaHoraModificacion");

                    b.Property<DateTime>("FechaHoraRegistro")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("HoraFin");

                    b.Property<TimeSpan>("HoraInicio");

                    b.Property<string>("LetraRepresentacion")
                        .IsRequired();

                    b.Property<string>("UsuarioBorrado");

                    b.Property<string>("UsuarioModificacion");

                    b.Property<string>("UsuarioRegistro")
                        .IsRequired();

                    b.HasKey("IdTurno");

                    b.ToTable("Turno");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Label", b =>
                {
                    b.HasOne("BoxTrackLabel.API.Models.Production", "Production")
                        .WithMany("Labels")
                        .HasForeignKey("ProduccionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BoxTrackLabel.API.Models.LabelText", "LabelText")
                        .WithMany("Labels")
                        .HasForeignKey("TextoEtiquetaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Module", b =>
                {
                    b.HasOne("BoxTrackLabel.API.Models.Process", "Process")
                        .WithMany("Modules")
                        .HasForeignKey("IdProceso");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Production", b =>
                {
                    b.HasOne("BoxTrackLabel.API.Models.Module", "Module")
                        .WithMany("Productions")
                        .HasForeignKey("IdModulo");

                    b.HasOne("BoxTrackLabel.API.Models.Process", "Process")
                        .WithMany("Productions")
                        .HasForeignKey("IdProceso");

                    b.HasOne("BoxTrackLabel.API.Models.Shift", "Shift")
                        .WithMany("Productions")
                        .HasForeignKey("IdTurno");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Schedule", b =>
                {
                    b.HasOne("BoxTrackLabel.API.Models.Module", "Module")
                        .WithMany("Schedules")
                        .HasForeignKey("IdModulo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BoxTrackLabel.API.Models.Process", "Process")
                        .WithMany("Schedules")
                        .HasForeignKey("IdProceso")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BoxTrackLabel.API.Models.Shift", "Shift")
                        .WithMany("Schedules")
                        .HasForeignKey("IdTurno")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
