
using Domain.Security.Dtos;
using MediatR;
using Microsoft.Exchange.WebServices.Data;

namespace Application.Authentication.Commands
{
    public record RegisterUserCommand(RegisterUserRequestDto Dto)
    : ICommand<RegisterResult>;
}
