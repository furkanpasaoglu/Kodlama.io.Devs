﻿namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;

/// <summary>
/// Getirilecek Programlama dili teknolojisini döndüren dto sınıfı.
/// </summary>
public class ProgrammingLanguageTechnologyGetByIdDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ProgrammingLanguageName { get; set; }
}