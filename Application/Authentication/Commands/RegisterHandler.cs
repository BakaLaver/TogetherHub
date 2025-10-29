using Api.Security.Services;
using Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands
{
    public class RegisterHandler(
    UserManager<CustomIdentityUser> userManager,
    IJwtSecurityService jwtSecurityService)
    : ICommandHandler<RegisterUserCommand, RegisterResult>
    {
        public async Task<RegisterResult> Handle(
            RegisterUserCommand request,
            CancellationToken cancellationToken)
        {
            if (await userManager.FindByEmailAsync(request.Dto.Email) != null)
                throw new BadRequestException("A user with this email already exists");

            if (await userManager.FindByNameAsync(request.Dto.UserName) != null)
                throw new BadRequestException("A user with this UserName already exists");

            var user = new CustomIdentityUser
            {
                Email = request.Dto.Email,
                UserName = request.Dto.UserName
            };

            IdentityResult result = await userManager
                .CreateAsync(user, request.Dto.Password);

            if (!result.Succeeded)
                throw new BadRequestException(
                    string.Join(";", result.Errors.Select(e => e.Description)));

            var response = new UserResponseDto(
                   user.UserName,
                   user.Email,
                   jwtSecurityService.CreateToken(user));

            return new RegisterResult(response);
        }
    }
}
