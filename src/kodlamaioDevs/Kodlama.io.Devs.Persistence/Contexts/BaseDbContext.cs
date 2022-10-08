using Core.Security.Entities;
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
    public DbSet<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<UserSocialMediaAddress> UserSocialMediaAddresses { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    
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
            p.HasMany(x => x.ProgrammingLanguageTechnologies);
        });

        modelBuilder.Entity<ProgrammingLanguageTechnology>(p =>
        {
            p.ToTable("ProgrammingLanguageTechnologies").HasKey(x => x.Id);
            p.Property(x => x.Id).HasColumnName("Id");
            p.Property(x=>x.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
            p.Property(x => x.Name).HasColumnName("Name");
            p.HasOne(x => x.ProgrammingLanguage);
        });
        
        modelBuilder.Entity<UserSocialMediaAddress>(p =>
        {
            p.ToTable("UserSocialMediaAddresses").HasKey(x => x.Id);
            p.Property(x => x.Id).HasColumnName("Id");
            p.Property(x => x.UserId).HasColumnName("UserId");
            p.Property(x => x.GithubUrl).HasColumnName("GithubUrl");
            p.HasOne(x => x.User);
        });
        
        modelBuilder.Entity<User>(p =>
        {
            p.ToTable("Users").HasKey(u => u.Id);
            p.Property(u => u.Id).HasColumnName("Id");
            p.Property(u => u.FirstName).HasColumnName("FirstName");
            p.Property(u => u.LastName).HasColumnName("LastName");
            p.Property(u => u.Email).HasColumnName("Email");
            p.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
            p.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
            p.Property(u => u.Status).HasColumnName("Status");
            p.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType");
            p.HasMany(c => c.UserOperationClaims);
            p.HasMany(c => c.RefreshTokens);
        });
        
        modelBuilder.Entity<OperationClaim>(p =>
        {
            p.ToTable("OperationClaims").HasKey(o => o.Id);
            p.Property(o => o.Id).HasColumnName("Id");
            p.Property(o => o.Name).HasColumnName("Name");
        });
        
        modelBuilder.Entity<UserOperationClaim>(p =>
        {
            p.ToTable("UserOperationClaims").HasKey(u => u.Id);
            p.Property(u => u.Id).HasColumnName("Id");
            p.Property(u => u.UserId).HasColumnName("UserId");
            p.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId");
            p.HasOne(u => u.User);
            p.HasOne(u => u.OperationClaim);
        });
        
        modelBuilder.Entity<RefreshToken>(a =>
        {
            a.ToTable("RefreshTokens").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.UserId).HasColumnName("UserId");
            a.Property(p => p.Token).HasColumnName("Token");
            a.Property(p => p.Expires).HasColumnName("Expires");
            a.Property(p => p.Created).HasColumnName("Created");
            a.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
            a.Property(p => p.Revoked).HasColumnName("Revoked");
            a.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
            a.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
            a.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
            a.HasOne(p => p.User);
        });

        //Programlama dilleri tablosuna varsayılan kayıtları ekler. (Seeds)
        ProgrammingLanguage[] programmingLanguageEntitySeeds =
        {
            new(1, "C#"),
            new(2, "Java"),
            new(3, "Javascript"),
        };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);
        
        //Programlama dili teknolojileri tablosuna varsayılan kayıtları ekler. (Seeds)
        ProgrammingLanguageTechnology[] programmingLanguageTechnologyEntitySeeds =
        {
            new (1, 1,"ASP.NET Core"),
            new (2, 1,"Wpf"),
            new (3, 2,"Spring"),
            new (4, 2,"Jsp"),
            new (5, 3,"Vue"),
            new (6, 3,"React")
        };
        modelBuilder.Entity<ProgrammingLanguageTechnology>().HasData(programmingLanguageTechnologyEntitySeeds);
        
        //Operasyon yetki tablosuna varsayılan kayıtları ekler. (Seeds)
        OperationClaim[] operationClaimsEntitySeeds =
        {
            new(1, "Admin"), 
            new(2, "User")
        };
        modelBuilder.Entity<OperationClaim>().HasData(operationClaimsEntitySeeds);
            
        //Kullanıcı Sosyal Medya Adresi tablosuna varsayılan kayıtları ekler. (Seeds)
        //Not: İlk User Kayıt Olduktan Sonra Bu İşlem Yapılmalıdır.
        // UserSocialMediaAddress[] userSocialMediaAddressEntitySeeds =
        // {
        //     new(1,1,"https://github.com/furkanpasaoglu")
        // };
        // modelBuilder.Entity<UserSocialMediaAddress>().HasData(userSocialMediaAddressEntitySeeds);
    }
}