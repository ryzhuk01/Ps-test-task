using Microsoft.EntityFrameworkCore;
using Plumsail.Core.Entities;

namespace Plumsail.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<FormSubmission> FormSubmissions => Set<FormSubmission>();
}
