using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories;

/// <summary>
/// Programlama dili teknolojileri için metotların bulunduğu repository sınıfıdır.
/// </summary>
public class ProgrammingLanguageTechnologyRepository : EfRepositoryBase<ProgrammingLanguageTechnology,BaseDbContext>, IProgrammingLanguageTechnologyRepository
{
    public ProgrammingLanguageTechnologyRepository(BaseDbContext context) : base(context)
    {
    }
}