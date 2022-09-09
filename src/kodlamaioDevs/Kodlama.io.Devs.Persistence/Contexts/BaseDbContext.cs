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
    public DbSet<ProgrammingTechnology> ProgrammingTechnologies { get; set; }

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
            p.HasMany(x => x.ProgrammingTechnologies);
        });

        modelBuilder.Entity<ProgrammingTechnology>(p =>
        {
            p.ToTable("ProgrammingTechnologies").HasKey(x => x.Id);
            p.Property(x => x.Id).HasColumnName("Id");
            p.Property(x=>x.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
            p.Property(x => x.Name).HasColumnName("Name");
            p.HasOne(x => x.ProgrammingLanguage);
        });

        //Programlama dilleri tablosuna varsayılan kayıtları ekler. (Seeds)
        ProgrammingLanguage[] programmingLanguageEntitySeeds =
        {
            new(1, "C#"),
            new(2, "Java"),
            new(3, "Javascript"),
        };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);
        
        //Programlama teknolojileri tablosuna varsayılan kayıtları ekler. (Seeds)
        ProgrammingTechnology[] programmingTechnologyEntitySeeds =
        {
            new (1, 1,"ASP.NET Core"),
            new (2, 1,"Wpf"),
            new (3, 2,"Spring"),
            new (4, 2,"Jsp"),
            new (5, 3,"Vue"),
            new (6, 3,"React")
        };
        modelBuilder.Entity<ProgrammingTechnology>().HasData(programmingTechnologyEntitySeeds);
    }
}