using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Web.Models;

[Table("attendance")]
public class Attendance
{
    [Column("id")]
    public long Id { get; set; }
    
    [Required]
    [Column("client_id")]
    public long ClientId { get; set; }
    
    [Required]
    [Column("session_id")]
    public long SessionId { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public Client Client { get; set; } = null!;
    public Session Session { get; set; } = null!;
}
