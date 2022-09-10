namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;

/// <summary>
/// Getirilecek Programlama teknolojisini döndüren dto sınıfı.
/// </summary>
public class ProgrammingTechnologyGetByIdDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ProgrammingLanguageName { get; set; }
}