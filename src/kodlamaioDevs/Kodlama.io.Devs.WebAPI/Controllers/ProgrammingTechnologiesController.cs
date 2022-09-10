using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnologyByDynamic;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

/// <summary>
/// Programlama teknolojileri için kontrolcüler.
/// </summary>
public class ProgrammingTechnologiesController : BaseController
{
    /// <summary>
    /// Programlama teknolojisi ekleme işlemi.
    /// </summary>
    /// <param name="createProgrammingLanguageTechnologyCommand">Eklenecek programlama dili bilgileri.</param>
    /// <returns>Eklenen programlama dili bilgileri.</returns>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageTechnologyCommand createProgrammingLanguageTechnologyCommand)
    {
        var result = await Mediator!.Send(createProgrammingLanguageTechnologyCommand);
        return Created("", result);
    }
    
    /// <summary>
    /// Programlama teknolojisi güncelleme işlemi.
    /// </summary>
    /// <param name="updateProgrammingLanguageTechnologyCommand">Güncellenecek programlama teknolojisi bilgileri.</param>
    /// <returns>Güncellenen programlama teknolojisi bilgileri.</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageTechnologyCommand updateProgrammingLanguageTechnologyCommand)
    {
        var result = await Mediator!.Send(updateProgrammingLanguageTechnologyCommand);
        return Ok(result);
    }
    
    /// <summary>
    /// Programlama teknolojisi silme işlemi.
    /// </summary>
    /// <param name="deleteProgrammingLanguageTechnologyCommand">Silinecek programlama teknolojisi bilgileri.</param>
    /// <returns>Silinen programlama teknolojisi bilgileri.</returns>
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageTechnologyCommand deleteProgrammingLanguageTechnologyCommand)
    {
        var result = await Mediator!.Send(deleteProgrammingLanguageTechnologyCommand);
        return Ok(result);
    }
    
    /// <summary>
    /// Programlama teknolojisi bilgilerini getirme işlemi.
    /// </summary>
    /// <param name="getByIdProgrammingLanguageTechnologyQuery">Getirilecek programlama teknolojisi bilgileri.</param>
    /// <returns>Getirilen programlama teknolojisi bilgileri.</returns>
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageTechnologyQuery  getByIdProgrammingLanguageTechnologyQuery)
    {
        var result = await Mediator!.Send(getByIdProgrammingLanguageTechnologyQuery);
        return Ok(result);
    }
    
    /// <summary>
    /// Programlama teknolojilerini getirme işlemi.
    /// </summary>
    /// <param name="pageRequest">Sayfalama bilgileri.</param>
    /// <returns>Getirilen programlama dilleri bilgileri.</returns>
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest  pageRequest)
    {
        GetListProgrammingLanguageTechnologyQuery getListProgrammingLanguageTechnologyQuery = new() { PageRequest = pageRequest };
        var result = await Mediator!.Send(getListProgrammingLanguageTechnologyQuery);
        return Ok(result);
    }
    
    /// <summary>
    /// Programlama teknolojilerini getirme işlemi dinamik sorgu ile.
    /// </summary>
    /// <param name="pageRequest">Sayfalama bilgileri.</param>
    /// <param name="dynamic">Dinamik sorgu bilgileri.</param>
    /// <returns>Getirilen programlama teknolojileri bilgileri.</returns>
    [HttpPost("GetList/ByDynamic")]
    public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
    {
        var getListByDynamicProgrammingTechnologyQuery = new GetListProgrammingLanguageTechnologyByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
        var result = await Mediator!.Send(getListByDynamicProgrammingTechnologyQuery);
        return Ok(result);

    }
}