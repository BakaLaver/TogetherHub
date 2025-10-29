
using Domain.Security.Dtos;
using Microsoft.AspNetCore.Identity.Data;

namespace Application.Topics.Queries.LoginUser
{
    public record LoginUserQuery(LoginRequest LoginRequest)
        : IQuery<LoginResult>;
}
