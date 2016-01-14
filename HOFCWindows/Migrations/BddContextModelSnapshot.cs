using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using HOFCWindows.Models;

namespace HOFCWindows.Migrations
{
    [DbContext(typeof(BddContext))]
    partial class BddContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("HOFCWindows.Models.Actu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("ImageURL");

                    b.Property<int>("PostId");

                    b.Property<string>("Texte");

                    b.Property<string>("Titre");

                    b.Property<string>("URL");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("HOFCWindows.Models.Calendrier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Categorie");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Equipe1");

                    b.Property<string>("Equipe2");

                    b.Property<int?>("Score1");

                    b.Property<int?>("Score2");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("HOFCWindows.Models.Classement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Bc");

                    b.Property<int>("Bp");

                    b.Property<string>("Categorie");

                    b.Property<int>("Defaite");

                    b.Property<int>("Difference");

                    b.Property<string>("Equipe");

                    b.Property<int>("Joue");

                    b.Property<int>("Nul");

                    b.Property<int>("Points");

                    b.Property<int>("Victoire");

                    b.HasKey("Id");
                });
        }
    }
}
