using Api.Security.Services;
using Domain.Security;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Topics.Queries.LoginUser
{
    public class LoginHandler(
    UserManager<CustomIdentityUser> userManager,
    IJwtSecurityService jwtSecurityService)
    : IQueryHandler<LoginUserQuery, LoginResult>
    {
        public async Task<LoginResult> Handle(
            LoginUserQuery request,
            CancellationToken cancellationToken)
        {
            CustomIdentityUser? user = await userManager.Users
                .FirstOrDefaultAsync(
                  u => request.LoginRequest.Email.ToUpper() == u.NormalizedEmail
                    || request.LoginRequest.Email.ToUpper() == u.NormalizedUserName,
                  cancellationToken);

            if (user == null)
                throw new UnauthorizedException();

            bool result = await userManager
                .CheckPasswordAsync(user, request.LoginRequest.Password);

            if (!result)
                throw new UnauthorizedException();

            UserResponseDto response = new UserResponseDto(
                    user.UserName,
                    user.Email,
                    jwtSecurityService.CreateToken(user));

            return new LoginResult(response);
        }
    }
}
