using System.ComponentModel.DataAnnotations;

namespace Gym.Web.Models;

public class Instructor
{
    public long Id { get; set; }
    
    [Required]
    public long PackageId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;
    
    [StringLength(50)]
    public string? LastName { get; set; }
    
    [Required]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    public bool IsMale { get; set; }
    
    [Required]
    public float Salary { get; set; }
    
    [StringLength(50)]
    public string? Email { get; set; }
    
    [Required]
    public string Title { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    [Required]
    [StringLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;
    
    public string? ImagePath { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public Package Package { get; set; } = null!;
    public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    public ICollection<Session> Sessions { get; set; } = new List<Session>();
}
