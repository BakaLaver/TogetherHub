namespace Domain.Security.Dtos
{
    public record IdentityUserRepsonseDto(
        string Username,
        string Email,
        string JwtToken
        );
}
