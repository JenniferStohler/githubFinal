using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Server.Models
{
  public class Keep
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string CreatorId { get; set; }

    public string Name { get; set; }
    [Required]
    public string Description { get; set; }

    public string Img { get; set; }
    [Required]
    public int Views { get; set; } = 0;
    [Required]
    public int Shares { get; set; } = 0;
    public int Keeps { get; set; } = 0;

    public Profile Creator { get; set; }

    public bool Published { get; internal set; }
  }
  public class VaultKeepViewModel : Keep
  {
    public int VaultKeepId { get; set; }
  }
}