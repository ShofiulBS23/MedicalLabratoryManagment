using MedicalLabratoryManagment.Models;

namespace MedicalLabratoryManagment.Services.Interfaces;
public interface IUserSettingsService
{
    UserModel GetUserSettings(int userId);
    void UpdateUserSettings(UserModel userSettings);
    void CreateUserSettings(UserModel userSettings);
    IEnumerable<UserModel> GetAllUserSettings();  // Assuming a method to fetch all settings if needed
    void DeleteUserSettings(int userId);
}
