using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetByIdProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologyByDynamic;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

/// <summary>
/// Programlama teknolojileri için kontrolcüler.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProgrammingTechnologiesController : BaseController
{
    /// <summary>
    /// Programlama teknolojisi ekleme işlemi.
    /// </summary>
    /// <param name="createProgrammingTechnologyCommand">Eklenecek programlama dili bilgileri.</param>
    /// <returns>Eklenen programlama dili bilgileri.</returns>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProgrammingTechnologyCommand createProgrammingTechnologyCommand)
    {
        var result = await Mediator!.Send(createProgrammingTechnologyCommand);
        return Created("", result);
    }
    
    /// <summary>
    /// Programlama teknolojisi güncelleme işlemi.
    /// </summary>
    /// <param name="updateProgrammingTechnologyCommand">Güncellenecek programlama teknolojisi bilgileri.</param>
    /// <returns>Güncellenen programlama teknolojisi bilgileri.</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProgrammingTechnologyCommand updateProgrammingTechnologyCommand)
    {
        var result = await Mediator!.Send(updateProgrammingTechnologyCommand);
        return Ok(result);
    }
    
    /// <summary>
    /// Programlama teknolojisi silme işlemi.
    /// </summary>
    /// <param name="deleteProgrammingTechnologyCommand">Silinecek programlama teknolojisi bilgileri.</param>
    /// <returns>Silinen programlama teknolojisi bilgileri.</returns>
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingTechnologyCommand deleteProgrammingTechnologyCommand)
    {
        var result = await Mediator!.Send(deleteProgrammingTechnologyCommand);
        return Ok(result);
    }
    
    /// <summary>
    /// Programlama teknolojisi bilgilerini getirme işlemi.
    /// </summary>
    /// <param name="getByIdProgrammingTechnologyQuery">Getirilecek programlama teknolojisi bilgileri.</param>
    /// <returns>Getirilen programlama teknolojisi bilgileri.</returns>
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingTechnologyQuery  getByIdProgrammingTechnologyQuery)
    {
        var result = await Mediator!.Send(getByIdProgrammingTechnologyQuery);
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
        GetListProgrammingTechnologyQuery getListProgrammingTechnologyQuery = new() { PageRequest = pageRequest };
        var result = await Mediator!.Send(getListProgrammingTechnologyQuery);
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
        var getListByDynamicProgrammingTechnologyQuery = new GetListProgrammingTechnologyByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
        var result = await Mediator!.Send(getListByDynamicProgrammingTechnologyQuery);
        return Ok(result);

    }
}