﻿// <auto-generated />
using System;
using GreenThumb.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenThumb.Migrations
{
    [DbContext(typeof(GreenThumbDbContext))]
    partial class GreenThumbDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GreenThumb.Models.GardenModel", b =>
                {
                    b.Property<int>("GardenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GardenId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("GardenId");

                    b.ToTable("Gardens");

                    b.HasData(
                        new
                        {
                            GardenId = 1,
                            Name = "usergarden"
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.InstructionModel", b =>
                {
                    b.Property<int>("InstructionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructionId"), 1L, 1);

                    b.Property<int>("PlantId")
                        .HasColumnType("int")
                        .HasColumnName("plant_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("text");

                    b.HasKey("InstructionId");

                    b.HasIndex("PlantId");

                    b.ToTable("Instructions");

                    b.HasData(
                        new
                        {
                            InstructionId = 1,
                            PlantId = 1,
                            Text = "Ensure correct lighting."
                        },
                        new
                        {
                            InstructionId = 2,
                            PlantId = 1,
                            Text = "Water cactus."
                        },
                        new
                        {
                            InstructionId = 3,
                            PlantId = 2,
                            Text = "Ensure correct lighting."
                        },
                        new
                        {
                            InstructionId = 4,
                            PlantId = 2,
                            Text = "Use well-draining soil."
                        },
                        new
                        {
                            InstructionId = 5,
                            PlantId = 2,
                            Text = "Water rose."
                        },
                        new
                        {
                            InstructionId = 6,
                            PlantId = 3,
                            Text = "Use well-draining soil."
                        },
                        new
                        {
                            InstructionId = 7,
                            PlantId = 3,
                            Text = "Plant in a sunny location."
                        },
                        new
                        {
                            InstructionId = 8,
                            PlantId = 3,
                            Text = "Water Sunflower."
                        },
                        new
                        {
                            InstructionId = 9,
                            PlantId = 4,
                            Text = "Plant in a bright location."
                        },
                        new
                        {
                            InstructionId = 10,
                            PlantId = 4,
                            Text = "Avoid placing in direct sunlight for extended periods of time."
                        },
                        new
                        {
                            InstructionId = 11,
                            PlantId = 4,
                            Text = "Ensure a tempereature between 60 - 80 degrees Fahrenheit (15 - 27 degrees celsius) during the day, and slightly cooler during night-time."
                        },
                        new
                        {
                            InstructionId = 12,
                            PlantId = 4,
                            Text = "Water Orchid, but allow the top inch of the potting mix to dry before watering again'."
                        },
                        new
                        {
                            InstructionId = 13,
                            PlantId = 5,
                            Text = "Plant Maple Tree."
                        },
                        new
                        {
                            InstructionId = 14,
                            PlantId = 5,
                            Text = "Apply a layer of organic mulch, such as wood chips or bark, around the base of the tree."
                        },
                        new
                        {
                            InstructionId = 15,
                            PlantId = 5,
                            Text = "Water Maple Tree. Consistent moisture and deep watering is crucial here. Aim for deep penetration rather than shallow watering."
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.PlantGarden", b =>
                {
                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.Property<int>("GardenId")
                        .HasColumnType("int");

                    b.HasKey("PlantId", "GardenId");

                    b.HasIndex("GardenId");

                    b.ToTable("PlantGardens");
                });

            modelBuilder.Entity("GreenThumb.Models.PlantModel", b =>
                {
                    b.Property<int>("PlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("PlantId");

                    b.ToTable("Plants");

                    b.HasData(
                        new
                        {
                            PlantId = 1,
                            Description = "Resilient succulent plants adapted to arid climates, are known for their unique appearance featuring fleshy stems and spines.",
                            Name = "Cactus"
                        },
                        new
                        {
                            PlantId = 2,
                            Description = "Renowned for its exquisite flowers and fragrant aroma, the rose is a symbol of love and beauty, cultivated in various colors and varieties worldwide.",
                            Name = "Rose"
                        },
                        new
                        {
                            PlantId = 3,
                            Description = "Recognizable for its large, yellow flower head, the sunflower is not only visually striking but also known for its heliotropic behavior, following the sun's movement.",
                            Name = "Sunflower"
                        },
                        new
                        {
                            PlantId = 4,
                            Description = "Boasting a vast and diverse family, orchids are prized for their intricate and exotic blooms, making them popular choices in the world of ornamental plants and horticulture.",
                            Name = "Orchid"
                        },
                        new
                        {
                            PlantId = 5,
                            Description = "Iconic for its vibrant autumn foliage, the maple tree is appreciated for its diverse species, including those valued for timber, syrup production, and ornamental landscaping.",
                            Name = "Maple Tree"
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int?>("GardenId")
                        .HasColumnType("int")
                        .HasColumnName("garden_id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("UserId");

                    b.HasIndex("GardenId")
                        .IsUnique()
                        .HasFilter("[garden_id] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            GardenId = 1,
                            Password = "BETzSRAPc3/w6srQ6jx5bw==",
                            Username = "user"
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.InstructionModel", b =>
                {
                    b.HasOne("GreenThumb.Models.PlantModel", "Plant")
                        .WithMany("Instructions")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GreenThumb.Models.PlantGarden", b =>
                {
                    b.HasOne("GreenThumb.Models.GardenModel", "Garden")
                        .WithMany("PlantGardens")
                        .HasForeignKey("GardenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenThumb.Models.PlantModel", "Plant")
                        .WithMany("PlantGardens")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Garden");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GreenThumb.Models.UserModel", b =>
                {
                    b.HasOne("GreenThumb.Models.GardenModel", "Garden")
                        .WithOne("User")
                        .HasForeignKey("GreenThumb.Models.UserModel", "GardenId");

                    b.Navigation("Garden");
                });

            modelBuilder.Entity("GreenThumb.Models.GardenModel", b =>
                {
                    b.Navigation("PlantGardens");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GreenThumb.Models.PlantModel", b =>
                {
                    b.Navigation("Instructions");

                    b.Navigation("PlantGardens");
                });
#pragma warning restore 612, 618
        }
    }
}
