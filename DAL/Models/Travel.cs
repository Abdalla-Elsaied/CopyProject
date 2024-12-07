

namespace DAL;

public class Travel
{
    public int Id { get; set; } // Primary Key
    public string Title { get; set; } = string.Empty; // Travel Title
    public string Description { get; set; } = string.Empty; // Description of the travel
    public decimal Price { get; set; } // Price of the travel
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
    public int CompanyId { get; set; }
  
    public Company? Company { get; set; } 
}
