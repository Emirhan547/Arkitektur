namespace Arkitektur.WebUI.Services.TokenServices;

public interface ITokenService
{
    public string GetUserToken { get; }
    public string GetUserId { get; }
    public string GetUserRole { get; }
    public string GetUserName { get; }
    public string GetUserFullName { get; }
}