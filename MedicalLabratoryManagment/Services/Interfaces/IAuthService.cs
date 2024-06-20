namespace MedicalLabratoryManagment.Services.Interfaces;

public interface IAuthService
{
    Task<string> AuthenticateUser(string username, string password, string userType);
}
