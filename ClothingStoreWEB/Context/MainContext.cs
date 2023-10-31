using ClothingStoreWEB.Models;
using ClothingStoreWEB.Models.AuxiliaryModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreWEB.Context
{
    public class MainContext: IdentityDbContext<User>
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
            // замість Database.EnsureCreated(); треба спочатку створювати міграцію, а потім прописувати update-database
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(a => a.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(d => d.Manufacture)
                    .WithMany()
                    .HasForeignKey(a => a.ManufacturerId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Navigation(a => a.Category).AutoInclude();
                entity.Navigation(a => a.Manufacture).AutoInclude();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(a => a.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Status)
                    .WithMany(d => d.Orders)
                    .HasForeignKey(a => a.StatusId)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(d => d.Payment)
                    .WithMany(d => d.Orders)
                    .HasForeignKey(a => a.PaymentId)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(d => d.Delivery)
                    .WithMany(d => d.Orders)
                    .HasForeignKey(a => a.DeliveryId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Navigation(a => a.User).AutoInclude();
                entity.Navigation(a => a.Status).AutoInclude();
                entity.Navigation(a => a.Payment).AutoInclude();
                entity.Navigation(a => a.Delivery).AutoInclude();
            });

            modelBuilder.Entity<ItemOrder>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.HasOne(p => p.Item)
                    .WithMany(d => d.ItemOrders)
                    .HasForeignKey(a => a.ItemId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(p => p.Order)
                    .WithMany(d => d.ItemOrders)
                    .HasForeignKey(a => a.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Navigation(a => a.Item).AutoInclude();
                entity.Navigation(a => a.Order).AutoInclude();

            });

            modelBuilder.Entity<DeliveryAddress>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.HasOne(p => p.User)
                    .WithMany(d => d.DeliveryAddresses)
                    .HasForeignKey(x => x.UserId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(a => a.Id);
            });
            modelBuilder.Entity<Manufacture>(entity =>
            {
                entity.HasKey(a => a.Id);
            });
            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasKey(a => a.Id);
            });
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(a => a.Id);
            });
            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(a => a.Id);
            });
        }
/*        public virtual DbSet<User> Users { get; set; }*/
        public virtual DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ItemOrder> ItemOrders { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Manufacture> Manufactures { get; set; }
        public virtual DbSet<Delivery> DeliveryMethods { get; set; }
        public virtual DbSet<Payment> PaymentMethods { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
    }
}
