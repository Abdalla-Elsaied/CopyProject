using DAL.Models;

namespace DAL;

public class Company :ModelBase
{
   
    public string Name { get; set; } = string.Empty; 
    public string Email { get; set; } = string.Empty; 

    public string Password { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true; 
    public ICollection<Travel> Travels { get; set; } = new List<Travel>(); // Travels created by the company
}
