using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities;

/// <summary>
/// Programlama teknolojisini temsil eder.
/// </summary>
public class ProgrammingTechnology : Entity
{
    public int ProgrammingLanguageId { get; set; }
    public string Name { get; set; }
    public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

    public ProgrammingTechnology()
    {
        
    }

    public ProgrammingTechnology(int id, int programmingLanguageId, string name) : this()
    {
        Id = id;
        ProgrammingLanguageId = programmingLanguageId;
        Name = name;
    }
}