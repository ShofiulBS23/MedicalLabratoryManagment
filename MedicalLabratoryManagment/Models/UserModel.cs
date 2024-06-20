using System.ComponentModel.DataAnnotations;

namespace MedicalLabratoryManagment.Models;

public class UserModel
{
    [Key]
    public int UserId { get; set; }
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
    [Required]
    [MaxLength(50)]
    public string Password { get; set; }
    [Required]
    public string UserType { get; set; } 
}

