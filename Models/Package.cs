using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Web.Models;

[Table("packages")]
public class Package
{
    [Column("id")]
    public long Id { get; set; }
    
    [Required]
    [Column("package_name")]
    public string PackageName { get; set; } = string.Empty;
    
    [Column("image_path")]
    public string? ImagePath { get; set; }
    
    [Required]
    [Column("duration")]
    public string Duration { get; set; } = string.Empty;
    
    [Required]
    [Column("price")]
    public int Price { get; set; }
    
    [Required]
    [Column("days")]
    public int Days { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}
