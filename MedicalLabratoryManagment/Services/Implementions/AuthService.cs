using MedicalLabratoryManagment.Data;
using MedicalLabratoryManagment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalLabratoryManagment.Services.Implementions;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;

    public AuthService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> AuthenticateUser(string username, string password, string userType)
    {
        var user = await _context.Users
                                  .FirstOrDefaultAsync(u => u.Username == username
                                                            && u.Password == password
                                                            && u.UserType == userType);
        if (user != null) {
            return user.UserType; // Return user type if authentication is successful
        }
        return null; // Return null if authentication fails
    }
}
