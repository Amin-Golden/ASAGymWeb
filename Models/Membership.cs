using System.ComponentModel.DataAnnotations;

namespace Gym.Web.Models;

public class Membership
{
    public long Id { get; set; }
    
    [Required]
    public long ClientId { get; set; }
    
    [Required]
    public long PackageId { get; set; }
    
    [Required]
    public long InstructorId { get; set; }
    
    [Required]
    public string MembershipStatus { get; set; } = string.Empty;
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
    
    [Required]
    public DateTime PaymentDate { get; set; }
    
    [Required]
    public bool IsPaid { get; set; }
    
    [Required]
    public int RemainSessions { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public Client Client { get; set; } = null!;
    public Package Package { get; set; } = null!;
    public Instructor Instructor { get; set; } = null!;
    public ICollection<Session> Sessions { get; set; } = new List<Session>();
}
