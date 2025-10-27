using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Web.Models;

[Table("clients")]
public class Client
{
    [Column("id")]
    public long Id { get; set; }
    
    [Required]
    [StringLength(50)]
    [Column("fname")]
    public string FirstName { get; set; } = string.Empty;
    
    [StringLength(50)]
    [Column("lname")]
    public string? LastName { get; set; }
    
    [Required]
    [Column("dob")]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    [Column("is_male")]
    public bool IsMale { get; set; }
    
    [StringLength(50)]
    [Column("email")]
    public string? Email { get; set; }
    
    [Required]
    [StringLength(13)]
    [Column("phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [Required]
    [StringLength(10)]
    [Column("social_number")]
    public string SocialNumber { get; set; } = string.Empty;
    
    [Column("image_path")]
    public string? ImagePath { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("locker")]
    public int? Locker { get; set; }
    
    [Column("weight")]
    public float? Weight { get; set; }
    
    [Column("height")]
    public float? Height { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    public ICollection<GymSession> GymSessions { get; set; } = new List<GymSession>();
    public FaceEmbedding? FaceEmbedding { get; set; }
    public ICollection<AccessLog> AccessLogs { get; set; } = new List<AccessLog>();
}
