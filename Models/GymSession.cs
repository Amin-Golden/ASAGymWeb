using System.ComponentModel.DataAnnotations;

namespace Gym.Web.Models;

public class GymSession
{
    public long Id { get; set; }
    
    [Required]
    public long ClientId { get; set; }
    
    [Required]
    public DateTime EntranceTime { get; set; }
    
    public DateTime? ExitTime { get; set; }
    
    public int? LockerNumber { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public Client Client { get; set; } = null!;
}
