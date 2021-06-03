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
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Img { get; set; }
    [Required]
    public int Views { get; set; } = 0;
    [Required]
    public int Shares { get; set; } = 0;
    public int Keeps { get; set; } = 0;
    [Required]
    public Profile Creator { get; set; }
    [Required]
    public bool Published { get; internal set; }
  }
}