using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenMTB.Models;

namespace OpenMTB.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Competition> CompetitionSet { get; set; }
    public virtual DbSet<Participant> Participants { get; set; }
    public virtual DbSet<Result> Results { get; set; }
    public virtual DbSet<Series> Series{ get; set; }
}
