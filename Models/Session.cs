using System.ComponentModel.DataAnnotations;

namespace Gym.Web.Models;

public class Session
{
    public long Id { get; set; }
    
    [Required]
    public long InstructorId { get; set; }
    
    [Required]
    public long MembershipId { get; set; }
    
    [Required]
    public DateTime DestinationDate { get; set; }
    
    [Required]
    public bool IsAttended { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public Instructor Instructor { get; set; } = null!;
    public Membership Membership { get; set; } = null!;
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
