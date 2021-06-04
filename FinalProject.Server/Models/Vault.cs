using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Server.Models
{
  public class Vault
  {
    [Required]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    //Vaultkeeps needs the CreatorId to be required in the Vaults Model; however, when I put the [Required] on the CreatorId in the Vaults Model, the POST VAULTS test fails. How can I fix that?
    public string CreatorId { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsPrivate { get; set; } = false;
    public Profile Creator { get; set; }

  }
}