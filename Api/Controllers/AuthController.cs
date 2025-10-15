﻿using Api.Security.Services;
using Domain.Security;
using Domain.Security.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(UserManager<CustomIdentityUser> manager, IJwtSecurityService jwtSecurityService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IResult> login(LoginRequest dto)
        {
            var user = await manager.FindByEmailAsync(dto.Email);

            if (user is null)
            {
                return Results.Unauthorized();
            }

            var result = await manager.CheckPasswordAsync(user, dto.Password);

            if (result)
            {
                var response = new IdentityUserRepsonseDto(user.UserName!, user.Email!, jwtSecurityService.CreateToken(user));

                return Results.Ok(new { result = response });
            }
            return Results.Unauthorized();
        }

    [HttpPost("register")]
        public async Task<IResult> Register(RegisterUserRequestDto dto)
        {
            if (await manager.Users.AnyAsync(u => u.UserName == dto.UserName))
            {
                return Results.BadRequest("Username занят");
            }

            if(await manager.Users.AnyAsync(u =>u.Email == dto.Email)) 
            {
                return Results.BadRequest("Email занят");
            }

            var user = new CustomIdentityUser
            {
                FullName = dto.UserName,
                Email = dto.Email,
                UserName = dto.UserName,
                About = String.Empty
            };

            var result = await manager.CreateAsync(user, dto.Password!);

            if (result.Succeeded) 
            {
                var response = new IdentityUserRepsonseDto(
                    user.UserName!, user.Email!, jwtSecurityService.CreateToken(user)
                    );
                return Results.Ok(new { result = response });
            }

            return Results.BadRequest(result.Errors);
        }
    }
}
