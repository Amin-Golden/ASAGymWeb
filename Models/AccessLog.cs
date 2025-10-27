using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Web.Models;

[Table("access_logs")]
public class AccessLog
{
    [Column("id")]
    public long Id { get; set; }
    
    [Column("client_id")]
    public long? ClientId { get; set; }
    
    [Required]
    [Column("access_granted")]
    public bool AccessGranted { get; set; }
    
    [Column("confidence")]
    public float? Confidence { get; set; }
    
    [Column("timestamp")]
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public Client? Client { get; set; }
}
