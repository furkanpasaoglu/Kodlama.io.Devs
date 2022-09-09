using Core.Persistence.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories;

/// <summary>
/// Programlama teknolojileri için metotların imzalarını tutar.
/// </summary>
public interface IProgrammingTechnologyRepository : IAsyncRepository<ProgrammingTechnology>, IRepository<ProgrammingTechnology>
{
    
}