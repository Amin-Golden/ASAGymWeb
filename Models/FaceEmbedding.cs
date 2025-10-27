using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Web.Models;

[Table("face_embeddings")]
public class FaceEmbedding
{
    [Column("id")]
    public long Id { get; set; }
    
    [Required]
    [Column("client_id")]
    public long ClientId { get; set; }
    
    [Required]
    [Column("embedding")]
    public byte[] Embedding { get; set; } = Array.Empty<byte>();
    
    [Column("confidence")]
    public float? Confidence { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public Client Client { get; set; } = null!;
}
