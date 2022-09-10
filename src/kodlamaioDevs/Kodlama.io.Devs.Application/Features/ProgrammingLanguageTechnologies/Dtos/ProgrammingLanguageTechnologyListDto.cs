namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;

/// <summary>
/// Getirilecek Tüm Programlama dili teknolojisini döndüren dto sınıfı.
/// </summary>
public class ProgrammingLanguageTechnologyListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ProgrammingLanguageName { get; set; }
}