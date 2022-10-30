using Microsoft.EntityFrameworkCore;

namespace JuniorTaskApi.Models
{
    public class TaskDatabase:DbContext
    {
        public DbSet<MyOrder> MyOrders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<orderproduct> Orderproducts { get; set; }  

        public TaskDatabase()
        {
        }


        public TaskDatabase(DbContextOptions options):base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=juniortask;Integrated Security=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<orderproduct>()
                .HasOne(x => x.product)
                .WithMany(x => x.Orderproducts)
                .HasForeignKey(x => x.productId);
            modelBuilder.Entity<orderproduct>()
                .HasOne(x=>x.order)
                .WithMany(x=>x.Orderproducts)
                .HasForeignKey(x=>x.orderId);
        }
    }
}
