using AuthApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TaskJob> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(e =>
            {
                e.ToTable("accounts");
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).HasColumnName("id");
                e.Property(x => x.Username).HasColumnName("username").HasMaxLength(255).IsRequired();
                e.Property(x => x.Fullname).HasColumnName("fullname").HasMaxLength(255).IsRequired();
                e.Property(x => x.Password).HasColumnName("password").HasMaxLength(255).IsRequired();
            });

            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("categories");
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).HasColumnName("id");
                e.Property(x => x.Name).HasColumnName("name").HasMaxLength(255).IsRequired();
            });

            modelBuilder.Entity<TaskJob>(e =>
            {
                e.ToTable("tasks");
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).HasColumnName("id");
                e.Property(x => x.Name).HasColumnName("name").HasMaxLength(255).IsRequired();
                e.Property(x => x.Description).HasColumnName("description").HasMaxLength(500).IsRequired();
                e.Property(x => x.CategoryId).HasColumnName("category_id").IsRequired();
                e.Property(x => x.AccountId).HasColumnName("account_id").IsRequired();

                e.HasOne(x => x.Category)
                    .WithMany(c => c.Tasks)
                    .HasForeignKey(x => x.CategoryId);
                e.HasOne(x => x.Account)
                    .WithMany(a => a.Tasks)
                    .HasForeignKey(x => x.AccountId);
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
