using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext

    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext>options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Adress> Adresses { get; set; }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        //nazwa restuaracji jest wymagana

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(r => r.Email).IsRequired();
            modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired();

            modelBuilder.Entity<Restaurant>().Property(r => r.Name).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Dish>().Property(r => r.Name).IsRequired();
            modelBuilder.Entity<Dish>().Property(r => r.Price).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Adress>().Property(a=>a.City).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Adress>().Property(a => a.Street).IsRequired().HasMaxLength(50);

        }


    }
}
