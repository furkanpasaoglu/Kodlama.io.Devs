using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities;

/// <summary>
/// Programlama dilini temsil eden sınıf.
/// </summary>
public class ProgrammingLanguage : Entity
{
    public string Name { get; set; }
    public virtual ICollection<ProgrammingTechnology> ProgrammingTechnologies { get; set; }

    public ProgrammingLanguage()
    {
     
    }

    public ProgrammingLanguage(int id, string name) :this()
    {
        Id = id;
        Name = name;
    }
}