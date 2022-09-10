using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;

/// <summary>
/// Programlama dilini için geri dönüş modeli
/// </summary>
public class ProgrammingLanguageGetByIdDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ProgrammingLanguageTechnologyListDto> ProgrammingTechnologies { get; set; }
}