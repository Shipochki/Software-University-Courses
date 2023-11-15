namespace P01_StudentSystem.Data
{
	using Microsoft.EntityFrameworkCore;

	public class StudentSystemDbContext : DbContext
	{
        public StudentSystemDbContext()
        {
            
        }

        public StudentSystemDbContext(DbContextOptions<StudentSystemDbContext> options)
            : base(options)
        {
            
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
