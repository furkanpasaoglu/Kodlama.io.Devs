using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories;

/// <summary>
/// Programlama teknolojileri için metotların bulunduğu repository sınıfıdır.
/// </summary>
public class ProgrammingTechnologyRepository : EfRepositoryBase<ProgrammingTechnology,BaseDbContext>, IProgrammingTechnologyRepository
{
    public ProgrammingTechnologyRepository(BaseDbContext context) : base(context)
    {
    }
}