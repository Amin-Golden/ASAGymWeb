using System.ComponentModel.DataAnnotations;

namespace Gym.Web.Models;

public class Attendance
{
    public long Id { get; set; }
    
    [Required]
    public long ClientId { get; set; }
    
    [Required]
    public long SessionId { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public Client Client { get; set; } = null!;
    public Session Session { get; set; } = null!;
}
