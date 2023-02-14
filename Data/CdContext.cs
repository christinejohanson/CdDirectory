using CdDirectory.Models;
using Microsoft.EntityFrameworkCore;

namespace CdDirectory.Data
{
    public class CdContext : DbContext
    {
        //endast en konstruktor
        public CdContext(DbContextOptions<CdContext> options) : base(options)
        {

        }

        //knyta an till model
        public DbSet<Cd> Cd { get; set; }
        public DbSet<Cd> Artist { get; set; }
        //model för lender
        public DbSet<Cd> Lender { get; set; }
        public DbSet<CdDirectory.Models.Artist> Artist_1 { get; set; } = default!;
        public DbSet<CdDirectory.Models.Lender> Lender_1 { get; set; } = default!;

    }
}