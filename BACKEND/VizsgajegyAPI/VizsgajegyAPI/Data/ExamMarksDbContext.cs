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
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=developerdb;Integrated Security=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            base.OnModelCreating(modelBuilder);
        }


    }
}
