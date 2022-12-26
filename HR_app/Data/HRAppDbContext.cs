using HR_app.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR_app.Data
{
    public class HRAppDbContext : DbContext
    {
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<ApplicantEntity> Applicants { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }

        public string DbPath { get; }

        public HRAppDbContext()
        {
            DbPath = BuildDbPath();
        }

        HRAppDbContext(DbContextOptions<HRAppDbContext> options) : base(options) 
        {
            DbPath = BuildDbPath();
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        private string BuildDbPath()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            return Path.Join(path, "hr_app.db");
        }
    }
}
