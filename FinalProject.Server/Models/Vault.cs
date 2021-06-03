using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Server.Models
{
  public class Vault
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string CreatorId { get; set; }
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }

    public bool IsPrivate { get; set; } = false;
    public Profile Creator { get; set; }

  }
}