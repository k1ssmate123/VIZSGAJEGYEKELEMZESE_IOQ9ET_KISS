using Microsoft.EntityFrameworkCore;

using VizsgajegyAPI.Models;

namespace VizsgajegyAPI.Data
{
    public class ExamMarksDbContext : DbContext
    {
        public DbSet<ExamMarks> ExamMarksList { get; set; }
        public ExamMarksDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=examdb;Integrated Security=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<ExamMarks>()
            .Property(e => e.Marks)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());


         

            base.OnModelCreating(modelBuilder);
        }


    }
}
