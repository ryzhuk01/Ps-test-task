using Microsoft.EntityFrameworkCore;
using Ps.Core.Entities;

namespace Ps.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<FormSubmission> FormSubmissions => Set<FormSubmission>();
}
