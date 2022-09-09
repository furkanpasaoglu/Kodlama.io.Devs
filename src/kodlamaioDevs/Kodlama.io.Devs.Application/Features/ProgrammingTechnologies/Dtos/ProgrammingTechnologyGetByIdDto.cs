namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;

/// <summary>
/// Programlama teknolojisi için dto
/// </summary>
public class ProgrammingTechnologyGetByIdDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ProgrammingLanguageName { get; set; }
}