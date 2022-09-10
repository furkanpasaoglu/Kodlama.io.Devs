namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;

/// <summary>
/// Getirilecek Tüm Programlama teknolojisini döndüren dto sınıfı.
/// </summary>
public class ProgrammingTechnologyListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ProgrammingLanguageName { get; set; }
}