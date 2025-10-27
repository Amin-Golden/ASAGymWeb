using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Web.Models;

[Table("admins")]
public class Admin
{
    [Column("id")]
    public long Id { get; set; }
    
    [Required]
    [StringLength(50)]
    [Column("adminID")]
    public string AdminId { get; set; } = string.Empty;
    
    [Required]
    [StringLength(50)]
    [Column("fname")]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [StringLength(50)]
    [Column("lname")]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [Column("dob")]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    [Column("is_male")]
    public bool IsMale { get; set; }
    
    [Required]
    [Column("password")]
    public string Password { get; set; } = string.Empty;
    
    [Required]
    [StringLength(13)]
    [Column("phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
