using System.ComponentModel.DataAnnotations;

namespace Domain.Security.Dtos
{
    public record RegisterUserRequestDto(
            string UserName,
            string Email,
            string Password,
            string FullName
        );
}
