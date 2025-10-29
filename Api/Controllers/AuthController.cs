using Api.Security.Services;
using Application.Authentication.Commands;
using Application.Topics.Queries.LoginUser;
using Domain.Security;
using Domain.Security.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IResult> login(LoginRequest dto)
        {

            return Results.Ok(await mediator.Send(new LoginUserQuery(dto)));
        }

    [HttpPost("register")]
        public async Task<IResult> Register(RegisterUserRequestDto dto)
        {
            return Results.Ok(await mediator.Send(new RegisterUserCommand(dto)));
        }
    }
}
