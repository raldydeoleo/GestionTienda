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
    [Migration("20210520171522_DataMatrix_006")]
    partial class DataMatrix_006
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BoxTrackLabel.API.Models.Access", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Expiracion");

                    b.Property<DateTime>("FechaHoraAcceso");

                    b.Property<DateTime>("FechaHoraRefresh");

                    b.Property<string>("Token");

                    b.Property<string>("Usuario");

                    b.HasKey("Id");

                    b.ToTable("Acceso");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Code", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CisType");

                    b.Property<string>("CodeValue")
                        .IsRequired();

                    b.Property<DateTime?>("ConfirmDate");

                    b.Property<DateTime?>("DropoutDate");

                    b.Property<bool>("IsConfirmed");

                    b.Property<bool>("IsDropout");

                    b.Property<bool>("IsPrinted");

                    b.Property<int>("LabelId");

                    b.Property<int>("OrderId");

                    b.Property<DateTime?>("PrintDate");

                    b.Property<string>("UserConfirm");

                    b.Property<string>("UserDropout");

                    b.Property<string>("UserPrint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("DataMatrix_Code");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.ConfigurationValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo");

                    b.Property<bool>("EstaBorrado");

                    b.Property<DateTime?>("FechaHoraBorrado");

                    b.Property<DateTime?>("FechaHoraModificacion");

                    b.Property<DateTime>("FechaHoraRegistro")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TextoConfiguracion");

                    b.Property<string>("UsuarioEliminacion");

                    b.Property<string>("UsuarioModificacion");

                    b.Property<string>("UsuarioRegistro");

                    b.Property<string>("ValorConfiguracion");

                    b.HasKey("Id");

                    b.HasIndex("Codigo");

                    b.ToTable("ConfiguracionValor");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Almacenamiento");

                    b.Property<int>("CantidadCigarros");

                    b.Property<int>("CantidadImpresa");

                    b.Property<string>("CodigoBarra");

                    b.Property<string>("CodigoQr");

                    b.Property<int>("ConfiguracionEtiquetaId");

                    b.Property<string>("DescripcionProducto");

                    b.Property<DateTime>("FechaHoraCalendario");

                    b.Property<int>("ProduccionId");

                    b.Property<int>("SecuenciaInicial");

                    b.Property<string>("UsuarioGeneracion");

                    b.HasKey("Id");

                    b.HasIndex("ConfiguracionEtiquetaId");

                    b.HasIndex("ProduccionId");

                    b.ToTable("Etiqueta");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.LabelConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Advertencia");

                    b.Property<string>("ClienteEspecifico");

                    b.Property<string>("Direccion");

                    b.Property<string>("IdPais");

                    b.Property<bool>("LlevaLogo");

                    b.Property<bool>("LlevaTextoInferior");

                    b.Property<string>("TextoCantidad");

                    b.Property<string>("TextoPais");

                    b.Property<string>("TipoEtiqueta");

                    b.HasKey("Id");

                    b.ToTable("ConfiguracionEtiqueta");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo");

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<bool>("EstaBorrado");

                    b.Property<DateTime?>("FechaHoraBorrado");

                    b.Property<DateTime?>("FechaHoraModificacion");

                    b.Property<DateTime>("FechaHoraRegistro")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdProceso");

                    b.Property<string>("NumeroModulo");

                    b.Property<string>("TextoModulo");

                    b.Property<string>("UsuarioEliminacion");

                    b.Property<string>("UsuarioModificacion");

                    b.Property<string>("UsuarioRegistro")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Codigo");

                    b.HasIndex("IdProceso");

                    b.ToTable("Modulo");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CisType")
                        .IsRequired();

                    b.Property<DateTime?>("CloseDate");

                    b.Property<string>("ContactPerson");

                    b.Property<string>("CreateMethodType")
                        .IsRequired();

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ExpectedCompleteTimestamp");

                    b.Property<DateTime?>("ExpectedStartDate")
                        .HasColumnType("Date");

                    b.Property<string>("FactoryAddress");

                    b.Property<string>("FactoryCountry")
                        .IsRequired();

                    b.Property<int>("FactoryId");

                    b.Property<string>("FactoryName")
                        .IsRequired();

                    b.Property<string>("Gtin")
                        .IsRequired();

                    b.Property<bool>("IsClosed");

                    b.Property<bool>("IsPrintAuthorized");

                    b.Property<string>("Mrp")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("0000");

                    b.Property<string>("OrderId");

                    b.Property<int?>("PoNumber");

                    b.Property<DateTime?>("PrintAuthorizedDate");

                    b.Property<string>("ProductCode")
                        .IsRequired();

                    b.Property<string>("ProductDescription")
                        .IsRequired();

                    b.Property<int>("ProductionLineId");

                    b.Property<string>("ProductionOrderId");

                    b.Property<int>("Quantity");

                    b.Property<string>("ReleaseMethodType")
                        .IsRequired();

                    b.Property<string>("Remark");

                    b.Property<string>("SerialNumberType")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ServiceProviderId");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Creada");

                    b.Property<int?>("StickerId");

                    b.Property<int>("TemplateId");

                    b.Property<string>("UserClose");

                    b.Property<string>("UserCreate");

                    b.Property<string>("UserPrintAuthorized");

                    b.HasKey("Id");

                    b.ToTable("DataMatrix_Order");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.OrderSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConnectionId")
                        .IsRequired();

                    b.Property<string>("ContactPerson")
                        .IsRequired();

                    b.Property<string>("CreateMethodType")
                        .IsRequired();

                    b.Property<string>("FactoryAddress")
                        .IsRequired();

                    b.Property<string>("FactoryCountry")
                        .IsRequired();

                    b.Property<int>("FactoryId");

                    b.Property<string>("FactoryName")
                        .IsRequired();

                    b.Property<string>("OmsId")
                        .IsRequired();

                    b.Property<string>("OmsUrl")
                        .IsRequired();

                    b.Property<int>("ProductionLineId");

                    b.Property<string>("ReleaseMethodType")
                        .IsRequired();

                    b.Property<string>("Token")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("DataMatrix_OrderSetting");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Process", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo");

                    b.Property<int>("CodigoPermiso");

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

                    b.HasKey("Id");

                    b.HasIndex("Codigo");

                    b.ToTable("Proceso");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Production", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DataMatrixOrderId");

                    b.Property<DateTime>("FechaHoraAperturaTurno")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("FechaHoraCierreTurno");

                    b.Property<DateTime>("FechaProduccion")
                        .HasColumnType("Date");

                    b.Property<int>("IdModulo");

                    b.Property<int>("IdProceso");

                    b.Property<string>("IdProducto");

                    b.Property<int>("IdTurno");

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FechaHoraFinalizado");

                    b.Property<DateTime>("FechaProduccion")
                        .HasColumnType("Date");

                    b.Property<DateTime>("FechaRegistro")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Finalizado");

                    b.Property<int>("IdModulo");

                    b.Property<int>("IdProceso");

                    b.Property<string>("IdProducto");

                    b.Property<int>("IdTurno");

                    b.Property<string>("UsuarioFinalizado");

                    b.Property<string>("UsuarioProgramacion");

                    b.HasKey("Id");

                    b.HasIndex("IdModulo");

                    b.HasIndex("IdProceso");

                    b.HasIndex("IdTurno");

                    b.ToTable("Programacion");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo");

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

                    b.HasKey("Id");

                    b.HasIndex("Codigo");

                    b.ToTable("Turno");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired();

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<bool>("EstaBorrado");

                    b.Property<DateTime?>("FechaHoraBorrado");

                    b.Property<DateTime?>("FechaHoraModificacion");

                    b.Property<DateTime>("FechaHoraRegistro")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UsuarioBorrado");

                    b.Property<string>("UsuarioModificacion");

                    b.Property<string>("UsuarioRegistro")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Codigo");

                    b.ToTable("Almacenamiento");
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Code", b =>
                {
                    b.HasOne("BoxTrackLabel.API.Models.Order", "Order")
                        .WithMany("Codes")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Label", b =>
                {
                    b.HasOne("BoxTrackLabel.API.Models.LabelConfig", "LabelConfig")
                        .WithMany("Labels")
                        .HasForeignKey("ConfiguracionEtiquetaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BoxTrackLabel.API.Models.Production", "Production")
                        .WithMany("Labels")
                        .HasForeignKey("ProduccionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Module", b =>
                {
                    b.HasOne("BoxTrackLabel.API.Models.Process", "Process")
                        .WithMany("Modules")
                        .HasForeignKey("IdProceso")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BoxTrackLabel.API.Models.Production", b =>
                {
                    b.HasOne("BoxTrackLabel.API.Models.Module", "Module")
                        .WithMany("Productions")
                        .HasForeignKey("IdModulo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BoxTrackLabel.API.Models.Process", "Process")
                        .WithMany("Productions")
                        .HasForeignKey("IdProceso")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BoxTrackLabel.API.Models.Shift", "Shift")
                        .WithMany("Productions")
                        .HasForeignKey("IdTurno")
                        .OnDelete(DeleteBehavior.Cascade);
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