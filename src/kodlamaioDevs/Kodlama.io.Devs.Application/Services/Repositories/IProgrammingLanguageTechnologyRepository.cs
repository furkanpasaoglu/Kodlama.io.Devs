using Core.Persistence.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories;

/// <summary>
/// Programlama dili teknolojileri için metotların imzalarını tutar.
/// </summary>
public interface IProgrammingLanguageTechnologyRepository : IAsyncRepository<ProgrammingLanguageTechnology>, IRepository<ProgrammingLanguageTechnology>
{
    
}