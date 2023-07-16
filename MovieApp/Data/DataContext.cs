using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Data {
    public class DataContext : DbContext {
        public DbSet<Movie>? Movies { get; set; }

        public DbSet<Session>? Sessions { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Session>()
                .HasOne(s => s.Movie)
                .WithMany(c => c.Sessions)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
    }
}