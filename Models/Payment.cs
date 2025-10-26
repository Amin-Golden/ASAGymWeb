using System.ComponentModel.DataAnnotations;

namespace Gym.Web.Models;

public class Payment
{
    public long Id { get; set; }
    
    [Required]
    public long ClientId { get; set; }
    
    [Required]
    [StringLength(10)]
    public string PaymentType { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public Client Client { get; set; } = null!;
}
