using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities;

/// <summary>
/// Programlama teknolojisini temsil eder.
/// </summary>
public class ProgrammingLanguageTechnology : Entity
{
    public int ProgrammingLanguageId { get; set; }
    public string Name { get; set; }
    public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

    public ProgrammingLanguageTechnology()
    {
        
    }

    public ProgrammingLanguageTechnology(int id, int programmingLanguageId, string name) : this()
    {
        Id = id;
        ProgrammingLanguageId = programmingLanguageId;
        Name = name;
    }
}