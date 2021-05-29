using System;

namespace FinalProject.Server.Models
{
  public class Account : Profile
  {
    public new string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

  }
}