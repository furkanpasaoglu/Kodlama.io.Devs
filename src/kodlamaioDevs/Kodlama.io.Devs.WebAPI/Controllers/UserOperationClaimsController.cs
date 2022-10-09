using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaimByDynamic;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

/// <summary>
/// Kullanıcı Operasyon Claim için kontrolcüler.
/// </summary>
public class UserOperationClaimsController : BaseController
{
    /// <summary>
    /// Kullanıcı Operasyon Claim ekleme işlemi.
    /// </summary>
    /// <param name="createUserOperationClaimCommand">Eklenecek kullanıcı operasyon claim bilgileri.</param>
    /// <returns>Eklenen kullanıcı operasyon claim bilgileri.</returns>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
    {
        var result = await Mediator!.Send(createUserOperationClaimCommand);
        return Created("", result);
    }
    
    /// <summary>
    /// Kullanıcı Operasyon Claim güncelleme işlemi.
    /// </summary>
    /// <param name="updateUserOperationClaimCommand">Güncellenecek kullanıcı operasyon claim bilgileri.</param>
    /// <returns>Güncellenen kullanıcı operasyon claim bilgileri.</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
    {
        var result = await Mediator!.Send(updateUserOperationClaimCommand);
        return Ok(result);
    }
    
    /// <summary>
    /// Kullanıcı Operasyon Claim silme işlemi.
    /// </summary>
    /// <param name="deleteUserOperationClaimCommand">Silinecek kullanıcı operasyon claim bilgileri.</param>
    /// <returns>Silinen kullanıcı operasyon claim bilgileri.</returns>
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
    {
        var result = await Mediator!.Send(deleteUserOperationClaimCommand);
        return Ok(result);
    }
    
    /// <summary>
    /// Kullanıcı Operasyon Claim bilgilerini getirme işlemi.
    /// </summary>
    /// <param name="getByIdUserOperationClaimQuery">Getirilecek kullanıcı operasyon claim bilgileri.</param>
    /// <returns>Getirilen kullanıcı operasyon claim bilgileri.</returns>
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdUserOperationClaimQuery  getByIdUserOperationClaimQuery)
    {
        var result = await Mediator!.Send(getByIdUserOperationClaimQuery);
        return Ok(result);
    }
    
    /// <summary>
    /// Kullanıcı Operasyon Claimleri getirme işlemi.
    /// </summary>
    /// <param name="pageRequest">Sayfalama bilgileri.</param>
    /// <returns>Getirilen kullanıcı operasyon claim bilgileri.</returns>
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest  pageRequest)
    {
        GetListUserOperationClaimQuery getListUserOperationClaimQuery = new() { PageRequest = pageRequest };
        var result = await Mediator!.Send(getListUserOperationClaimQuery);
        return Ok(result);
    }
    
    /// <summary>
    /// Kullanıcı Operasyon Claimleri getirme işlemi dinamik sorgu ile.
    /// </summary>
    /// <param name="pageRequest">Sayfalama bilgileri.</param>
    /// <param name="dynamic">Dinamik sorgu bilgileri.</param>
    /// <returns>Getirilen kullanıcı operasyon claim bilgileri.</returns>
    [HttpPost("GetList/ByDynamic")]
    public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
    {
        var getListByDynamicUserOperationClaimQuery = new GetListUserOperationClaimByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
        var result = await Mediator!.Send(getListByDynamicUserOperationClaimQuery);
        return Ok(result);
    }
}