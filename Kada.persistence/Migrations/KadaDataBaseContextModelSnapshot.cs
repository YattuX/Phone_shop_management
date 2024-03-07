﻿// <auto-generated />
using System;
using Kada.persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kada.persistence.Migrations
{
    [DbContext(typeof(KadaDataBaseContext))]
    partial class KadaDataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kada.Domain.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Capacite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CaracteristiqueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CouleurId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EtatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Imei")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NombreDeSim")
                        .HasColumnType("int");

                    b.Property<Guid?>("ParticulariteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Processeurs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Puissance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qualite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("StockageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TailleEcran")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CaracteristiqueId");

                    b.HasIndex("CouleurId");

                    b.HasIndex("EtatId");

                    b.HasIndex("ParticulariteId");

                    b.HasIndex("StockageId");

                    b.HasIndex("TypeId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Kada.Domain.Caracteristique", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasCapacite")
                        .HasColumnType("bit");

                    b.Property<bool>("HasCaracteristic")
                        .HasColumnType("bit");

                    b.Property<bool>("HasCouleur")
                        .HasColumnType("bit");

                    b.Property<bool>("HasDescription")
                        .HasColumnType("bit");

                    b.Property<bool>("HasEtat")
                        .HasColumnType("bit");

                    b.Property<bool>("HasImei")
                        .HasColumnType("bit");

                    b.Property<bool>("HasNombreDeSim")
                        .HasColumnType("bit");

                    b.Property<bool>("HasParticularite")
                        .HasColumnType("bit");

                    b.Property<bool>("HasPosition")
                        .HasColumnType("bit");

                    b.Property<bool>("HasProcesseurs")
                        .HasColumnType("bit");

                    b.Property<bool>("HasPuissance")
                        .HasColumnType("bit");

                    b.Property<bool>("HasQualite")
                        .HasColumnType("bit");

                    b.Property<bool>("HasRam")
                        .HasColumnType("bit");

                    b.Property<bool>("HasStockage")
                        .HasColumnType("bit");

                    b.Property<bool>("HasTailleEcran")
                        .HasColumnType("bit");

                    b.Property<bool>("HasType")
                        .HasColumnType("bit");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Caracteristique");
                });

            modelBuilder.Entity("Kada.Domain.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identifiant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsClientEnGros")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("WhatsappNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Kada.Domain.Couleur", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodeCouleur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Couleur");
                });

            modelBuilder.Entity("Kada.Domain.Etat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Etat");
                });

            modelBuilder.Entity("Kada.Domain.Fournisseur", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identifiant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("WhatsappNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fournisseur");
                });

            modelBuilder.Entity("Kada.Domain.Marque", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("TypeArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TypeArticleId");

                    b.ToTable("Marque");
                });

            modelBuilder.Entity("Kada.Domain.Model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MarqueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MarqueId");

                    b.ToTable("Modele");
                });

            modelBuilder.Entity("Kada.Domain.Particularite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Particularite");
                });

            modelBuilder.Entity("Kada.Domain.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantite")
                        .HasColumnType("float");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("Kada.Domain.Stockage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Stockage");
                });

            modelBuilder.Entity("Kada.Domain.TypeArticle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TypeArticle");
                });

            modelBuilder.Entity("Kada.Domain.Type_", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Type_");
                });

            modelBuilder.Entity("Kada.Domain.Article", b =>
                {
                    b.HasOne("Kada.Domain.Caracteristique", "Caracteristique")
                        .WithMany()
                        .HasForeignKey("CaracteristiqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kada.Domain.Couleur", "Couleur")
                        .WithMany()
                        .HasForeignKey("CouleurId");

                    b.HasOne("Kada.Domain.Etat", "Etat")
                        .WithMany()
                        .HasForeignKey("EtatId");

                    b.HasOne("Kada.Domain.Particularite", "Particularite")
                        .WithMany()
                        .HasForeignKey("ParticulariteId");

                    b.HasOne("Kada.Domain.Stockage", "Stockage")
                        .WithMany()
                        .HasForeignKey("StockageId");

                    b.HasOne("Kada.Domain.Type_", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Caracteristique");

                    b.Navigation("Couleur");

                    b.Navigation("Etat");

                    b.Navigation("Particularite");

                    b.Navigation("Stockage");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Kada.Domain.Caracteristique", b =>
                {
                    b.HasOne("Kada.Domain.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Kada.Domain.Marque", b =>
                {
                    b.HasOne("Kada.Domain.TypeArticle", "TypeArticle")
                        .WithMany()
                        .HasForeignKey("TypeArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeArticle");
                });

            modelBuilder.Entity("Kada.Domain.Model", b =>
                {
                    b.HasOne("Kada.Domain.Marque", "Marque")
                        .WithMany()
                        .HasForeignKey("MarqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marque");
                });

            modelBuilder.Entity("Kada.Domain.Stock", b =>
                {
                    b.HasOne("Kada.Domain.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });
#pragma warning restore 612, 618
        }
    }
}
