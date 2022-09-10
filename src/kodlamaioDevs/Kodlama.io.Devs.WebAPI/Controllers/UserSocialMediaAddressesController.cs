using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Commands.CreateUserSocialMediaAddress;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Commands.DeleteUserSocialMediaAddress;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Commands.UpdateUserSocialMediaAddress;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Queries.GetByIdUserSocialMediaAddress;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddress;
using Kodlama.io.Devs.Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddressByDynamic;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

/// <summary>
/// Kullanıcı Sosyal Medya Adresi için kontrolcüler.
/// </summary>
public class UserSocialMediaAddressesController : BaseController
{
    /// <summary>
    /// Kullanıcı Sosyal Medya Adresi ekleme işlemi.
    /// </summary>
    /// <param name="createUserSocialMediaAddressCommand">Eklenecek kullanıcı sosyal medya adresi bilgileri.</param>
    /// <returns>Eklenen kullanıcı sosyal medya adresi bilgileri.</returns>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserSocialMediaAddressCommand createUserSocialMediaAddressCommand)
    {
        var result = await Mediator!.Send(createUserSocialMediaAddressCommand);
        return Created("", result);
    }
    
    /// <summary>
    /// Kullanıcı Sosyal Medya Adresi güncelleme işlemi.
    /// </summary>
    /// <param name="updateUserSocialMediaAddressCommand">Güncellenecek kullanıcı sosyal medya adresi bilgileri.</param>
    /// <returns>Güncellenen kullanıcı sosyal medya adresi bilgileri.</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserSocialMediaAddressCommand updateUserSocialMediaAddressCommand)
    {
        var result = await Mediator!.Send(updateUserSocialMediaAddressCommand);
        return Ok(result);
    }
    
    /// <summary>
    /// Kullanıcı Sosyal Medya Adresi silme işlemi.
    /// </summary>
    /// <param name="deleteUserSocialMediaAddressCommand">Silinecek kullanıcı sosyal medya adresi bilgileri.</param>
    /// <returns>Silinen kullanıcı sosyal medya adresi bilgileri.</returns>
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteUserSocialMediaAddressCommand deleteUserSocialMediaAddressCommand)
    {
        var result = await Mediator!.Send(deleteUserSocialMediaAddressCommand);
        return Ok(result);
    }
    
    /// <summary>
    /// Kullanıcı Sosyal Medya Adresi bilgilerini getirme işlemi.
    /// </summary>
    /// <param name="getByIdUserSocialMediaAddressQuery">Getirilecek pkullanıcı sosyal medya adresi bilgileri.</param>
    /// <returns>Getirilen kullanıcı sosyal medya adresi bilgileri.</returns>
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdUserSocialMediaAddressQuery  getByIdUserSocialMediaAddressQuery)
    {
        var result = await Mediator!.Send(getByIdUserSocialMediaAddressQuery);
        return Ok(result);
    }
    
    /// <summary>
    /// Kullanıcı Sosyal Medya Adresi getirme işlemi.
    /// </summary>
    /// <param name="pageRequest">Sayfalama bilgileri.</param>
    /// <returns>Getirilen kullanıcı sosyal medya adresi bilgileri.</returns>
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest  pageRequest)
    {
        GetListUserSocialMediaAddressQuery getListUserSocialMediaAddressQuery = new() { PageRequest = pageRequest };
        var result = await Mediator!.Send(getListUserSocialMediaAddressQuery);
        return Ok(result);
    }
    
    /// <summary>
    /// Kullanıcı Sosyal Medya Adresi getirme işlemi dinamik sorgu ile.
    /// </summary>
    /// <param name="pageRequest">Sayfalama bilgileri.</param>
    /// <param name="dynamic">Dinamik sorgu bilgileri.</param>
    /// <returns>Getirilen kullanıcı sosyal medya adresi bilgileri.</returns>
    [HttpPost("GetList/ByDynamic")]
    public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
    {
        var getListByDynamicUserSocialMediaAddressQuery = new GetListUserSocialMediaAddressByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
        var result = await Mediator!.Send(getListByDynamicUserSocialMediaAddressQuery);
        return Ok(result);

    }
}