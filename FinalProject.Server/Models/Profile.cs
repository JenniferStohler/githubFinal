using System.ComponentModel.DataAnnotations;

namespace FinalProject.Server.Models
{
  public class Profile
  {
    [MinLength(1)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Img { get; set; } = "//placehold.it/150x150";

  }
}