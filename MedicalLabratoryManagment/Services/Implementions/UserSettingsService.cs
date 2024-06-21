using MedicalLabratoryManagment.Data;
using MedicalLabratoryManagment.Models;
using MedicalLabratoryManagment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalLabratoryManagment.Services.Implementions;

// UserSettingsService.cs
public class UserSettingsService : IUserSettingsService
{
    private readonly ApplicationDbContext _context;

    public UserSettingsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public UserModel GetUserSettings(int userId)
    {
        return _context.Users.Find(userId);
    }

    public void UpdateUserSettings(UserModel userSettings)
    {
        _context.Entry(userSettings).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void CreateUserSettings(UserModel userSettings)
    {
        _context.Users.Add(userSettings);
        _context.SaveChanges();
    }

    public IEnumerable<UserModel> GetAllUserSettings()
    {
        return _context.Users.ToList();
    }
}

