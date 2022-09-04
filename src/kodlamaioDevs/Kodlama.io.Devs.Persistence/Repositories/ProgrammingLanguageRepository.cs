using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories;

/// <summary>
/// Programlama dilleri için metotların bulunduğu repository sınıfıdır.
/// </summary>
public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage,BaseDbContext>, IProgrammingLanguageRepository
{
    public ProgrammingLanguageRepository(BaseDbContext context) : base(context)
    {
    }
}