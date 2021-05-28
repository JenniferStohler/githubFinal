using System.ComponentModel.DataAnnotations;

namespace FinalProject.Server.Models
{
  public class Vaultkeep
  {
    public int Id { get; set; }
    [Required]
    public string CreatorId { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }
  }
}