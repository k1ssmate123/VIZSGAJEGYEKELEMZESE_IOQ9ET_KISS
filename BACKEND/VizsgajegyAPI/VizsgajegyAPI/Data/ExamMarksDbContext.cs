using Microsoft.EntityFrameworkCore;

using VizsgajegyAPI.Models;

namespace VizsgajegyAPI.Data
{
    public class ExamMarksDbContext : DbContext
    {
        public DbSet<ExamMarks> ExamMarksList { get; set; }
        public ExamMarksDbContext()
        {
            Database.EnsureDeleted();
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
            modelBuilder.Entity<ExamMarks>().HasData(
                new ExamMarks { Id = 1, SubjectName = "Math" },
                                new ExamMarks { Id = 2, SubjectName = "Math" }
                                , new ExamMarks { Id = 3, SubjectName = "Math" }
                                , new ExamMarks { Id = 4, SubjectName = "Math" }
            );

            base.OnModelCreating(modelBuilder);
        }


    }
}
