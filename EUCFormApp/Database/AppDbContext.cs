using EUCFormApp.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace EUCFormApp.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Applicant> Applicants => Set<Applicant>();
    }
}
