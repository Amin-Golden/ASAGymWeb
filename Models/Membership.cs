using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Web.Models;

[Table("memberships")]
public class Membership
{
    [Column("id")]
    public long Id { get; set; }
    
    [Required]
    [Column("client_id")]
    public long ClientId { get; set; }
    
    [Required]
    [Column("package_id")]
    public long PackageId { get; set; }
    
    [Required]
    [Column("instructor_id")]
    public long InstructorId { get; set; }
    
    [Required]
    [Column("status")]
    public string MembershipStatus { get; set; } = string.Empty;
    
    [Required]
    [Column("start_date")]
    public DateTime StartDate { get; set; }
    
    [Required]
    [Column("end_date")]
    public DateTime EndDate { get; set; }
    
    [Required]
    [Column("payment_date")]
    public DateTime PaymentDate { get; set; }
    
    [Required]
    [Column("is_paid")]
    public bool IsPaid { get; set; }
    
    [Required]
    [Column("RemainSessions")]
    public int RemainSessions { get; set; } = 0;
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public Client Client { get; set; } = null!;
    public Package Package { get; set; } = null!;
    public Instructor Instructor { get; set; } = null!;
    public ICollection<Session> Sessions { get; set; } = new List<Session>();
}
