using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Web.Models;

[Table("sessions")]
public class Session
{
    [Column("id")]
    public long Id { get; set; }
    
    [Required]
    [Column("instructor_id")]
    public long InstructorId { get; set; }
    
    [Required]
    [Column("membership_id")]
    public long MembershipId { get; set; }
    
    [Required]
    [Column("destination_date")]
    public DateTime DestinationDate { get; set; }
    
    [Required]
    [Column("is_attended")]
    public bool IsAttended { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public Instructor Instructor { get; set; } = null!;
    public Membership Membership { get; set; } = null!;
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
