using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

/// <summary>
/// Operasyon Claim için kontrolcüler.
/// </summary>
public class OperationClaimsController : BaseController
{
    /// <summary>
    /// Operasyon Claim ekleme işlemi.
    /// </summary>
    /// <param name="createOperationClaimCommand">Eklenecek operasyon claim bilgileri.</param>
    /// <returns>Eklenen operasyon claim bilgileri.</returns>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
    {
        var result = await Mediator!.Send(createOperationClaimCommand);
        return Created("", result);
    }
    
    /// <summary>
    /// Operasyon Claim güncelleme işlemi.
    /// </summary>
    /// <param name="updateOperationClaimCommand">Güncellenecek operasyon claim bilgileri.</param>
    /// <returns>Güncellenen operasyon claim bilgileri.</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
    {
        var result = await Mediator!.Send(updateOperationClaimCommand);
        return Ok(result);
    }
    
    /// <summary>
    /// Operasyon Claim silme işlemi.
    /// </summary>
    /// <param name="deleteOperationClaimCommand">Silinecek operasyon claim bilgileri.</param>
    /// <returns>Silinen operasyon claim bilgileri.</returns>
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteOperationClaimCommand deleteOperationClaimCommand)
    {
        var result = await Mediator!.Send(deleteOperationClaimCommand);
        return Ok(result);
    }
    
    /// <summary>
    /// Operasyon Claim bilgilerini getirme işlemi.
    /// </summary>
    /// <param name="getByIdOperationClaimQuery">Getirilecek operasyon claim bilgileri.</param>
    /// <returns>Getirilen operasyon claim bilgileri.</returns>
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdOperationClaimQuery  getByIdOperationClaimQuery)
    {
        var result = await Mediator!.Send(getByIdOperationClaimQuery);
        return Ok(result);
    }
    
    /// <summary>
    /// Operasyon Claimleri getirme işlemi.
    /// </summary>
    /// <param name="pageRequest">Sayfalama bilgileri.</param>
    /// <returns>Getirilen operasyon claim bilgileri.</returns>
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest  pageRequest)
    {
        GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
        var result = await Mediator!.Send(getListOperationClaimQuery);
        return Ok(result);
    }
}