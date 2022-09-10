using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;

/// <summary>
/// Tüm Programlama dilinin döndüren dto sınıfı.
/// </summary>
public class ProgrammingLanguageListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ProgrammingTechnologyListDto> ProgrammingTechnologies { get; set; }
}