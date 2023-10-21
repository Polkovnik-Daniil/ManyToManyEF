using ManyToManyEF.Entity;
using Microsoft.EntityFrameworkCore;

namespace ManyToManyEF
{
    public class AppDbContext : DbContext
    {
        #region Fields
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DESKTOP-47QEB4O\\SQLEXPRESS;Initial Catalog=DB; Integrated Security=True; trustservercertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>().HasKey(Book => Book.Id);
            builder.Entity<Book>().HasIndex(Book => Book.Id).IsUnique();
            builder.Entity<Book>().HasIndex(Book => Book.Name).IsUnique();
            builder.Entity<Genre>().HasKey(Book => Book.Id);
            builder.Entity<Genre>().HasIndex(Book => Book.Id).IsUnique();
            builder.Entity<Genre>().HasIndex(Book => Book.Name).IsUnique();
            //builder.Entity<Book>().HasMany(b => b.Genres).WithMany(g => g.Genres);
            base.OnModelCreating(builder);
        }
    }
}
