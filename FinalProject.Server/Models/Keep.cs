using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Server.Models
{
  public class Keep
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    [Required]
    public string CreatorId { get; set; }
    // public string VaultId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public int Views { get; set; } = 0;
    public int Shares { get; set; } = 0;
    public int Keeps { get; set; } = 0;
    public Profile Creator { get; set; }
    public bool Published { get; internal set; }
  }
}