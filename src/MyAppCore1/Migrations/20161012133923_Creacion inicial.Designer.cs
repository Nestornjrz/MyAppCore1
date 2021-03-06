﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyAppCore1.Entities;

namespace MyAppCore1.Migrations
{
    [DbContext(typeof(MyAppCore1DbContext))]
    [Migration("20161012133923_Creacion inicial")]
    partial class Creacioninicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyAppCore1.Entities.Restaurante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cosina");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.HasKey("Id");

                    b.ToTable("Restaurantes");
                });
        }
    }
}
