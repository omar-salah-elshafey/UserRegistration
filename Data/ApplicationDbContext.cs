using Microsoft.EntityFrameworkCore;

namespace UserRegistration.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Governorate>().HasData(
                new Governorate { Id = 1, Name = "Cairo" },
                new Governorate { Id = 2, Name = "Alexandria" },
                new Governorate { Id = 3, Name = "Giza" },
                new Governorate { Id = 4, Name = "Port Said" },
                new Governorate { Id = 5, Name = "Suez" },
                new Governorate { Id = 6, Name = "Luxor" },
                new Governorate { Id = 7, Name = "Aswan" }
            );

            modelBuilder.Entity<City>().HasData(
                // Cairo Governorate
                new City { Id = 1, Name = "Maadi", GovernorateId = 1 },
                new City { Id = 2, Name = "Heliopolis", GovernorateId = 1 },
                new City { Id = 3, Name = "Nasr City", GovernorateId = 1 },
                new City { Id = 4, Name = "Shubra", GovernorateId = 1 },

                // Alexandria Governorate
                new City { Id = 5, Name = "Sidi Gaber", GovernorateId = 2 },
                new City { Id = 6, Name = "Montaza", GovernorateId = 2 },
                new City { Id = 7, Name = "Mansheya", GovernorateId = 2 },

                // Giza Governorate
                new City { Id = 8, Name = "6th of October", GovernorateId = 3 },
                new City { Id = 9, Name = "Haram", GovernorateId = 3 },
                new City { Id = 10, Name = "Dokki", GovernorateId = 3 },
                new City { Id = 11, Name = "Agouza", GovernorateId = 3 },

                // Port Said Governorate
                new City { Id = 12, Name = "Al Arab", GovernorateId = 4 },
                new City { Id = 13, Name = "Al Manakh", GovernorateId = 4 },
                new City { Id = 14, Name = "Al Zohour", GovernorateId = 4 },

                // Suez Governorate
                new City { Id = 15, Name = "Arbaeen", GovernorateId = 5 },
                new City { Id = 16, Name = "Ganayen", GovernorateId = 5 },
                new City { Id = 17, Name = "Suez City Center", GovernorateId = 5 },

                // Luxor Governorate
                new City { Id = 18, Name = "Luxor City", GovernorateId = 6 },
                new City { Id = 19, Name = "Armant", GovernorateId = 6 },
                new City { Id = 20, Name = "Esna", GovernorateId = 6 },

                // Aswan Governorate
                new City { Id = 21, Name = "Aswan City", GovernorateId = 7 },
                new City { Id = 22, Name = "Edfu", GovernorateId = 7 },
                new City { Id = 23, Name = "Kom Ombo", GovernorateId = 7 }
            );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
