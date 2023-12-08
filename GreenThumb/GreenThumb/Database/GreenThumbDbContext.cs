using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb.Database
{
    public class GreenThumbDbContext : DbContext
    {
        private readonly IEncryptionProvider _provider;
        public GreenThumbDbContext()
        {
            _provider = new GenerateEncryptionProvider("oooooooooooooooooooooooo");
        }
        public DbSet<PlantModel> Plants { get; set; }
        public DbSet<InstructionModel> Instructions { get; set; }
        public DbSet<GardenModel> Gardens { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PlantGarden> PlantGardens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumbDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PlantModel>()
                .HasMany(p => p.Instructions)
                .WithOne(p => p.Plant)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlantGarden>()
                .HasKey(pg => new { pg.PlantId, pg.GardenId });

            modelBuilder.UseEncryption(_provider);

            modelBuilder.Entity<PlantModel>().HasData(
                new PlantModel
                {
                    PlantId = 1,
                    Name = "Cactus",
                    Description = "Resilient succulent plants adapted to arid climates, are known for their unique appearance featuring fleshy stems and spines.",
                },
                new PlantModel
                {
                    PlantId = 2,
                    Name = "Rose",
                    Description = "Renowned for its exquisite flowers and fragrant aroma, the rose is a symbol of love and beauty, cultivated in various colors and varieties worldwide.",
                },
                new PlantModel
                {
                    PlantId = 3,
                    Name = "Sunflower",
                    Description = "Recognizable for its large, yellow flower head, the sunflower is not only visually striking but also known for its heliotropic behavior, following the sun's movement.",
                },
                new PlantModel
                {
                    PlantId = 4,
                    Name = "Orchid",
                    Description = "Boasting a vast and diverse family, orchids are prized for their intricate and exotic blooms, making them popular choices in the world of ornamental plants and horticulture.",
                },
                new PlantModel
                {
                    PlantId = 5,
                    Name = "Maple Tree",
                    Description = "Iconic for its vibrant autumn foliage, the maple tree is appreciated for its diverse species, including those valued for timber, syrup production, and ornamental landscaping.",
                });

            modelBuilder.Entity<InstructionModel>().HasData(
                new InstructionModel
                {
                    InstructionId = 1,
                    Text = "Ensure correct lighting.",
                    PlantId = 1
                },
                new InstructionModel
                {
                    InstructionId = 2,
                    Text = "Water cactus.",
                    PlantId = 1
                },
                new InstructionModel
                {
                    InstructionId = 3,
                    Text = "Ensure correct lighting.",
                    PlantId = 2
                },
                new InstructionModel
                {
                    InstructionId = 4,
                    Text = "Use well-draining soil.",
                    PlantId = 2
                },
                new InstructionModel
                {
                    InstructionId = 5,
                    Text = "Water rose.",
                    PlantId = 2
                },
                new InstructionModel
                {
                    InstructionId = 6,
                    Text = "Use well-draining soil.",
                    PlantId = 3
                },
                new InstructionModel
                {
                    InstructionId = 7,
                    Text = "Plant in a sunny location.",
                    PlantId = 3
                },
                new InstructionModel
                {
                    InstructionId = 8,
                    Text = "Water Sunflower.",
                    PlantId = 3
                },
                new InstructionModel
                {
                    InstructionId = 9,
                    Text = "Plant in a bright location.",
                    PlantId = 4
                },
                new InstructionModel
                {
                    InstructionId = 10,
                    Text = "Avoid placing in direct sunlight for extended periods of time.",
                    PlantId = 4
                },
                new InstructionModel
                {
                    InstructionId = 11,
                    Text = "Ensure a tempereature between 60 - 80 degrees Fahrenheit (15 - 27 degrees celsius) during the day, and slightly cooler during night-time.",
                    PlantId = 4
                },
                new InstructionModel
                {
                    InstructionId = 12,
                    Text = "Water Orchid, but allow the top inch of the potting mix to dry before watering again'.",
                    PlantId = 4
                },
                new InstructionModel
                {
                    InstructionId = 13,
                    Text = "Plant Maple Tree.",
                    PlantId = 5
                },
                new InstructionModel
                {
                    InstructionId = 14,
                    Text = "Apply a layer of organic mulch, such as wood chips or bark, around the base of the tree.",
                    PlantId = 5
                },
                new InstructionModel
                {
                    InstructionId = 15,
                    Text = "Water Maple Tree. Consistent moisture and deep watering is crucial here. Aim for deep penetration rather than shallow watering.",
                    PlantId = 5
                });

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel
                {
                    UserId = 1,
                    Username = "user",
                    Password = "password",
                    GardenId = 1
                });
            modelBuilder.Entity<GardenModel>().HasData(
                new GardenModel
                {
                    GardenId = 1,
                    Name = "usergarden",
                });

        }
    }
}
