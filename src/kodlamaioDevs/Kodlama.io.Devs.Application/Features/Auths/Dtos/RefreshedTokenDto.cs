﻿using Core.Security.Entities;
using Core.Security.JWT;

namespace Kodlama.io.Devs.Application.Features.Auths.Dtos;

/// <summary>
/// Token bilgileri
/// </summary>
public class RefreshedTokenDto
{
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
}