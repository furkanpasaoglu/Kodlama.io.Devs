using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.Devs.Persistence.Contexts;

/// <summary>
/// Veritabanı ayarlarını yapar.
/// </summary>
public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProgrammingLanguage>(p =>
        {
            p.ToTable("ProgrammingLanguages").HasKey(x=>x.Id);
            p.Property(x => x.Id).HasColumnName("Id");
            p.Property(x => x.Name).HasColumnName("Name");
        });

        //Programlama dilleri tablosuna varsayılan kayıtları ekler. (Seeds)
        ProgrammingLanguage[] programmingLanguageEntitySeeds =
        {
            new(1, "C#"),
            new(2, "Java"),
            new(3, "Python"),
        };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);
    }
}