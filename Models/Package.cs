using System.ComponentModel.DataAnnotations;

namespace Gym.Web.Models;

public class Package
{
    public long Id { get; set; }
    
    [Required]
    public string PackageName { get; set; } = string.Empty;
    
    public string? ImagePath { get; set; }
    
    [Required]
    public string Duration { get; set; } = string.Empty;
    
    [Required]
    public long Price { get; set; }
    
    [Required]
    public long Days { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}
