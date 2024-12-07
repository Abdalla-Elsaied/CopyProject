using DAL.Models;

namespace DAL;

public class Admin :ModelBase
{

    public string Name { get; set; } = string.Empty; 
    public string Email { get; set; } = string.Empty; 
    public string Password { get; set; } = string.Empty; 
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
  
}
