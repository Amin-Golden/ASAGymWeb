using System.ComponentModel.DataAnnotations;

namespace Gym.Web.Models;

public class Client
{
    public long Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;
    
    [StringLength(50)]
    public string? LastName { get; set; }
    
    [Required]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    public bool IsMale { get; set; }
    
    [StringLength(50)]
    public string? Email { get; set; }
    
    [Required]
    [StringLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [Required]
    [StringLength(10)]
    public string SocialNumber { get; set; } = string.Empty;
    
    public string? ImagePath { get; set; }
    public string? Description { get; set; }
    public int? Locker { get; set; }
    public float? Weight { get; set; }
    public float? Height { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    public ICollection<GymSession> GymSessions { get; set; } = new List<GymSession>();
}
