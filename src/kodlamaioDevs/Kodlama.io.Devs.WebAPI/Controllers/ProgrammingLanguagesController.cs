using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

/// <summary>
/// Programlama dilleri için kontrolcüler.
/// </summary>
public class ProgrammingLanguagesController : BaseController
{
    /// <summary>
    /// Programlama dili ekleme işlemi.
    /// </summary>
    /// <param name="createProgrammingLanguageCommand">Eklenecek programlama dili bilgileri.</param>
    /// <returns>Eklenen programlama dili bilgileri.</returns>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
    {
        var result = await Mediator!.Send(createProgrammingLanguageCommand);
        return Created("", result);
    }
    
    /// <summary>
    /// Programlama dili güncelleme işlemi.
    /// </summary>
    /// <param name="updateProgrammingLanguageCommand">Güncellenecek programlama dili bilgileri.</param>
    /// <returns>Güncellenen programlama dili bilgileri.</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
    {
        var result = await Mediator!.Send(updateProgrammingLanguageCommand);
        return Ok(result);
    }
    
    /// <summary>
    /// Programlama dili silme işlemi.
    /// </summary>
    /// <param name="deleteProgrammingLanguageCommand">Silinecek programlama dili bilgileri.</param>
    /// <returns>Silinen programlama dili bilgileri.</returns>
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
    {
        var result = await Mediator!.Send(deleteProgrammingLanguageCommand);
        return Ok(result);
    }
    
    /// <summary>
    /// Programlama dili bilgilerini getirme işlemi.
    /// </summary>
    /// <param name="getByIdProgrammingLanguageQuery">Getirilecek programlama dili bilgileri.</param>
    /// <returns>Getirilen programlama dili bilgileri.</returns>
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery  getByIdProgrammingLanguageQuery)
    {
        var result = await Mediator!.Send(getByIdProgrammingLanguageQuery);
        return Ok(result);
    }
    
    /// <summary>
    /// Programlama dillerini getirme işlemi.
    /// </summary>
    /// <param name="pageRequest">Sayfalama bilgileri.</param>
    /// <returns>Getirilen programlama dilleri bilgileri.</returns>
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest  pageRequest)
    {
        GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
        var result = await Mediator!.Send(getListProgrammingLanguageQuery);
        return Ok(result);
    }
    
}